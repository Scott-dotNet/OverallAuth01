using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.IRepository;

namespace Infrastructure.Repository
{
    /// <summary>
    /// 用户 仓储接口实现
    /// </summary>
    public class SysUserRepository : ISysUserRepository
    {
        /// <summary>
        /// test autofac
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string TestAutofac()
        {
            return "Autofac successful!";
        }
    }
}
