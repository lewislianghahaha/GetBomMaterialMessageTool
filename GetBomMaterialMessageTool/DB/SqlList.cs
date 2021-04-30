namespace GetBomMaterialMessageTool.DB
{
    public class SqlList
    {
        //根据SQLID返回对应的SQL语句  
        private string _result;

        /// <summary>
        /// 初始化获取BOM明细信息
        /// </summary>
        /// <returns></returns>
        public string Get_Bomdtl()
        {

            _result = $@"
                            SELECT A.FMATERIALID 表头物料ID,A.FNUMBER 'BOM编号',
	                               b.FMATERIALID 表体物料ID,c.FNUMBER 物料编码,d.FNAME 物料名称,
                                   CASE E.FERPCLSID WHEN 1 THEN '外购' WHEN 2 THEN '自制' ELSE '其它' END 物料属性,
                                   cast(b.FNUMERATOR/b.FDENOMINATOR*(1+b.FSCRAPRATE/100) as nvarchar(250)) 用量,
                                   b.FNUMERATOR 分子,b.FDENOMINATOR 分母,b.FSCRAPRATE 变动损耗率,c.F_YTC_DECIMAL8 物料单价,
                                   G.FNAME 父项物料单位

                            FROM T_ENG_BOM A
                            INNER JOIN dbo.T_ENG_BOMCHILD b ON a.FID=b.FID

                            INNER JOIN dbo.T_BD_MATERIAL C ON B.FMATERIALID=C.FMATERIALID
                            INNER JOIN dbo.T_BD_MATERIAL_L D ON C.FMATERIALID=D.FMATERIALID
                            INNER JOIN dbo.T_BD_MATERIALBASE E ON D.FMATERIALID=E.FMATERIALID

                            INNER JOIN dbo.T_BD_UNIT_L g ON a.FUNITID=g.FUNITID AND g.FLOCALEID <>1033

                            WHERE /*A.FFORBIDSTATUS='A' --BOM禁用状态:否
                            AND*/ A.FDOCUMENTSTATUS='C' --BOM审核状态:已审核
                            AND C.FDOCUMENTSTATUS='C' --物料审核状态:已审核
                            AND C.FFORBIDSTATUS='A'   --物料禁用状态:否
                            AND D.FLOCALEID='2052'
                            AND CONVERT(varchar(100), a.FMODIFYDATE, 20)= (
												                            SELECT CONVERT(varchar(100), MAX(A1.FMODIFYDATE), 20)
												                            FROM T_ENG_BOM A1
												                            WHERE A1.FMATERIALID=A.FMATERIALID
                                                                            AND a1.FFORBIDSTATUS='A'   --BOM禁用状态:否
																			AND a1.FDOCUMENTSTATUS='C' --BOM审核状态:已审核
											                               )  --获取最大的‘修改日期’记录
                            --检测获取最大的BOM编码
							AND A.FNUMBER= (
											SELECT  MAX(X.FNUMBER)
											FROM T_ENG_BOM X
											WHERE X.FMATERIALID=A.FMATERIALID
											AND X.FFORBIDSTATUS='A'     --BOM禁用状态:否
											AND x.FDOCUMENTSTATUS='C'   --BOM审核状态:已审核
										)
                            --AND A.FMATERIALID='136357'
                            --AND A.FNUMBER='QQ-G5-0001_V1.7'
                            ORDER BY a.FMATERIALID,e.FERPCLSID--,a.FMODIFYDATE DESC
                        ";

            return _result;
        }

        /// <summary>
        /// 获取物料基础信息(导入EXCEL转换时使用)
        /// </summary>
        /// <returns></returns>
        public string SearchMaterial()
        {
            _result = $@"
                                SELECT a.FMATERIALID,a.FNUMBER 物料编码

                                FROM dbo.T_BD_MATERIAL a
								INNER JOIN dbo.T_BAS_ASSISTANTDATAENTRY b ON a.F_YTC_ASSISTANT5=b.FENTRYID
                                INNER JOIN dbo.T_BAS_ASSISTANTDATAENTRY_L c ON b.FENTRYID=c.FENTRYID
                                WHERE c.FDATAVALUE IN('产成品','原漆半成品','原漆')
                                AND a.FDOCUMENTSTATUS='C'
                                --AND a.FFORBIDSTATUS='A' --物料禁用状态:否
                               -- AND d.FLOCALEID=2052
                               -- AND z2.FLOCALEID=2052
                                AND EXISTS (
												SELECT NULL FROM T_ENG_BOM A1
												WHERE A1.FMATERIALID=A.FMATERIALID
                                                AND a1.FFORBIDSTATUS='A'   --BOM禁用状态:否
												AND a1.FDOCUMENTSTATUS='C' --BOM审核状态:已审核
											) --必须要在‘成本BOM’内存在
                                order by a.FMATERIALID
                            ";
            return _result;
        }

    }
}
