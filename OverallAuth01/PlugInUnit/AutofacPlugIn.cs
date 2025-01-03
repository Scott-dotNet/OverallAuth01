using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Infrastructure;
using DomainService; 


namespace OverallAuth01.PlugInUnit
{
    /// <summary>
    /// Autofac 插件
    /// </summary>
    public class AutofacPlugIn : Autofac.Module
    {
        /// <summary>
        /// Override 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // 获取DomainService和Infrastructure程序集，然后批量注入。
            Assembly service = Assembly.Load("DomainService");
            Assembly intracface = Assembly.Load("Infrastructure");

            // 项目必须以 Service/Repository 结尾
            builder.RegisterAssemblyTypes(service)
                .Where(n => n.Name.EndsWith("Service") && !n.IsAbstract)
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(intracface)
                .Where(n=> n.Name.EndsWith("Repository") && !n.IsAbstract)
                .InstancePerLifetimeScope().AsImplementedInterfaces();
        }

    }
}
