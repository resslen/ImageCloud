using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Services;

namespace ImageCloudMVC.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Register(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<ImageCloudContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<FilesService>();
            builder.RegisterType<FoldersService>();
        }
    }
}