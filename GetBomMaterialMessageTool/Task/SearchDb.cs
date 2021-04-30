using System;
using System.Data;
using System.Data.SqlClient;
using GetBomMaterialMessageTool.DB;

namespace GetBomMaterialMessageTool.Task
{
    public class SearchDb
    {
        SqlList sqlList = new SqlList();

        private string _sqlscript = string.Empty;

        /// <summary>
        /// 获取K3-Cloud连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetCloudConn()
        {
            var conn = new Conn();
            var sqlcon = new SqlConnection(conn.GetConnectionString());
            return sqlcon;
        }

        /// <summary>
        /// 根据SQL语句查询得出对应的DT
        /// </summary>
        /// <param name="sqlscript"></param>
        /// <returns></returns>
        public DataTable UseSqlSearchIntoDt(string sqlscript)
        {
            var resultdt = new DataTable();
            try
            {
                var sqlDataAdapter = new SqlDataAdapter(sqlscript, GetCloudConn());
                sqlDataAdapter.Fill(resultdt);
            }
            catch (Exception)
            {
                resultdt.Rows.Clear();
                resultdt.Columns.Clear();
            }
            return resultdt;
        }

        /// <summary>
        /// 初始化获取物料记录
        /// </summary>
        /// <returns></returns>
        public DataTable SearchMaterial()
        {
            _sqlscript = sqlList.SearchMaterial();
            return UseSqlSearchIntoDt(_sqlscript);
        }

        /// <summary>
        /// 初始化获取BOM明细记录
        /// </summary>
        /// <returns></returns>
        public DataTable SearchBom()
        {
            _sqlscript = sqlList.Get_Bomdtl();
            return UseSqlSearchIntoDt(_sqlscript);
        }
    }
}
