using System.Configuration;

namespace GetBomMaterialMessageTool
{
    public class Conn
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            //读取App.Config配置文件中的Connstring节点    
            var pubs = ConfigurationManager.ConnectionStrings["Connstring"];
            var strcon = pubs.ConnectionString;
            return strcon;
        }
    }
}
