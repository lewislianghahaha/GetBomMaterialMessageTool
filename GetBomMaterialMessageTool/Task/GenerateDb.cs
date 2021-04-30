using System;
using System.Data;
using GetBomMaterialMessageTool.DB;

namespace GetBomMaterialMessageTool.Task
{
    public class GenerateDb
    {
        DbList dbList=new DbList();

        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="bomdt">bom记录</param>
        /// <param name="importdt">EXCEL导入记录</param>
        /// <returns></returns>
        public DataTable Generatedt(DataTable bomdt,DataTable importdt)
        {
            //获取导出临时表
            var resultdt = dbList.MakeExportTemp();
            //循环importdt并获取BOMDT记录集
            foreach (DataRow row in importdt.Rows)
            {
                //通过FMATERIALID获取BOM明细记录
                //设定循环的判断值;0:清漆 1:干剂 2:稀释剂
                var newrow = resultdt.NewRow();
                newrow[0] = row[1];
                newrow[1] = row[2];
                for (var i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        //获取‘清漆’
                        case 0:
                            var dtlrows = bomdt.Select("表头物料ID='" + row[0] + "' and 物料名称 like '%清漆%'");
                            newrow[2] = dtlrows.Length > 0 ? (object) Convert.ToString(dtlrows[0][3]) : DBNull.Value;
                            newrow[3] = dtlrows.Length > 0 ? (object)Convert.ToString(dtlrows[0][4]) : DBNull.Value;
                            break;
                        //获取‘干剂’
                        case 1:
                            var dtlrows1 = bomdt.Select("表头物料ID='" + row[0] + "' and 物料名称 like '%干剂%'");
                            newrow[4] = dtlrows1.Length > 0 ? (object)Convert.ToString(dtlrows1[0][3]) : DBNull.Value;
                            newrow[5] = dtlrows1.Length > 0 ? (object)Convert.ToString(dtlrows1[0][4]) : DBNull.Value;
                            break;
                        //获取‘稀释剂’
                        case 2:
                            var dtlrows2 = bomdt.Select("表头物料ID='" + row[0] + "' and 物料名称 like '%稀释剂%'");
                            newrow[6] = dtlrows2.Length > 0 ? (object)Convert.ToString(dtlrows2[0][3]) : DBNull.Value;
                            newrow[7] = dtlrows2.Length > 0 ? (object)Convert.ToString(dtlrows2[0][4]) : DBNull.Value;
                            break;
                    }
                }
                resultdt.Rows.Add(newrow);
            }

            return resultdt;
        }
    }
}
