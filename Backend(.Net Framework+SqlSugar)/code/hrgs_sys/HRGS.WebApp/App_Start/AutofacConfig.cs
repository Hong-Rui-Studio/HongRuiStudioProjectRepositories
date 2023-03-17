using Autofac.Integration.Mvc;
using Autofac;
using System.Reflection;
using System.Web.Mvc;

namespace HRGS.WebApp.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            //配置autofac的基本信息
            //(1) 创建容器
            var builder = new ContainerBuilder();
            //(2) 进行依赖注入的注册
            //builder.RegisterType<RolesDal>().As<IRolesDal>();
            //builder.RegisterType<RolesBll>().As<IRolesBll>();
            //这个地方我们通过反射来实现直接配置 程序集,写一个语句 实现配置所有的内容
            Assembly dal = Assembly.Load("HRGS.Repository"); //通过反射找到对应的dal成功
            builder.RegisterAssemblyTypes(dal).AsImplementedInterfaces(); //通过容器注册反射等得到类型,并且与接口层进行关联

            Assembly bll = Assembly.Load("HRGS.Service");
            builder.RegisterAssemblyTypes(bll).AsImplementedInterfaces();

            //(3) 注册控制器
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);
            //(4) 构建
            var container = builder.Build();
            //(5) 实现
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}