using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OverallAuth01.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OverallAuth01.PlugInUnit
{
    /// <summary>
    /// JWT 插件，用于解析JWT配置文件
    /// </summary>
    public static class JwtPlugInUnit
    {
        /// <summary>
        /// 初始化 jwt 
        /// </summary>
        /// <param name="services"></param>
        public static void InitJwt(this IServiceCollection services)
        {
            var jwtSetting = AppSettingdPlugInUnit.GetNode<JwtSettingModel>("JwtSetting");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSetting.Issuer,
                        ValidAudience = jwtSetting.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.SecurityKey)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    }; 
                });
        }
    }
}
