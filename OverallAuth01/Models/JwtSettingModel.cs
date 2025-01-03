namespace OverallAuth01.Models
{
    /// <summary>
    /// 配置 JWT
    /// </summary>
    public class JwtSettingModel
    {
        /// <summary>
        /// JWT 密钥
        /// </summary>
        public string? SecurityKey { get; set; }

        /// <summary>
        /// JWT 加密算法
        /// </summary>
        public string ENAlogrithm { get; set; }

        /// <summary>
        /// JWT 发布人
        /// </summary>
        public  string Issuer { get; set; } 

        /// <summary>
        /// JWT 订阅人
        /// </summary>
        public string Audience { get; set; }    

        /// <summary>
        /// 过期时间 单位：秒
        /// </summary>
        public int ExpireSeconds { get; set; }
    }
}
