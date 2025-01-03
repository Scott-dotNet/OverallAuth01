using DomainService.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Enums;

namespace OverallAuth01.Controllers.Sys
{
    /// <summary>
    /// 用户 控制器
    /// </summary>
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [ApiExplorerSettings(GroupName = nameof(ModuleGroupEnum.SysUser))]
    public class SysUserController : Controller
    {
        #region Constractor
        /// <summary>
        /// Service Inject
        /// </summary>
        public ISysUserService _sysUserService;
        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="sysUserService"></param>
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        #endregion

        /// <summary>
        /// test autofac
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public string TestAutofac()
        {
            return _sysUserService.TestAutofac();
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
    }
}
