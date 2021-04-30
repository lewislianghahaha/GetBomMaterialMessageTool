using System;
using System.Data;

namespace GetBomMaterialMessageTool.DB
{
    public class DbList
    {
        /// <summary>
        /// 创建导入EXCEL临时表
        /// </summary>
        /// <returns></returns>
        public DataTable ImportTemp()
        {
            var dt = new DataTable();
            for (var i = 0; i < 2; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "Bom物料编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "Bom物料名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }

        /// <summary>
        /// 用于:将EXCEL导入的记录与查找出来的FMATERIAL结合
        /// </summary>
        /// <returns></returns>
        public DataTable ImportMergeTemp()
        {
            var dt = new DataTable();
            for (var i = 0; i < 3; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "fmaterialid";
                        dc.DataType = Type.GetType("System.Int32"); 
                        break;
                    case 1:
                        dc.ColumnName = "Bom物料编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "Bom物料名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }

        /// <summary>
        /// 创建导出临时表
        /// </summary>
        /// <returns></returns>
        public DataTable MakeExportTemp()
        {
            var dt = new DataTable();
            for (var i = 0; i < 8; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "Bom物料编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "Bom物料名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "清漆物料编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 3:
                        dc.ColumnName = "清漆物料名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 4:
                        dc.ColumnName = "干剂物料编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 5:
                        dc.ColumnName = "干剂物料名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 6:
                        dc.ColumnName = "稀释剂物料编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 7:
                        dc.ColumnName = "稀释剂物料名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }
    }
}
