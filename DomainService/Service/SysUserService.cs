using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainService.IService;
using Infrastructure.IRepository;

namespace DomainService.Service
{
    /// <summary>
    /// 用户服务接口实现
    /// </summary>
    public class SysUserService : ISysUserService
    {
        #region 构造实例化
        private readonly ISysUserRepository _sysUserRepository;

        public SysUserService(ISysUserRepository sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }
        #endregion

        /// <summary>
        /// 测试Autofac
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string TestAutofac()
        {
            return _sysUserRepository.TestAutofac();
        }
    }
}
