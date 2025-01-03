using Microsoft.Extensions.Configuration.Json;

namespace OverallAuth01.PlugInUnit
{
    /// <summary>
    /// APP Setting 配置文件插件
    /// </summary>
    public static class AppSettingdPlugInUnit
    {
        /// <summary>
        /// 声明配置属性
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        // constructor
        static AppSettingdPlugInUnit()
        {
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
        }

        /// <summary>
        /// 获取配置文件的对象值
        /// </summary>
        /// <param name="jsonPath">文件路径</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string? GetJson( string jsonPath , string key)
        {
            if (string.IsNullOrEmpty(jsonPath) || string.IsNullOrEmpty(key))
                return null;
            // json 路径
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(jsonPath).Build();
            // json 对象
            return config.GetSection(key).Value;            
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetDbConnection()
        {
            return Configuration.GetConnectionString("DbConnection").Trim(); 
        }

        /// <summary>
        /// 获取Mysql数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetMysqlConnection()
        {
            return Configuration.GetConnectionString("MySql").Trim();
        }

        /// <summary>
        /// 根据节点名称获取配置模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Node"></param>
        /// <returns></returns>
        public static T GetNode<T> (string Node) where T : new()
        {
            T model = Configuration.GetSection(Node).Get<T>();
            return model;
        } 
    }
}
