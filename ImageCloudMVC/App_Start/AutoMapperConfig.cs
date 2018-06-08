using AutoMapper;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Models;

namespace ImageCloudMVC.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(Register);
        }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<File, FileListViewModel>();
            config.CreateMap<File, FilesView>();
            config.CreateMap<NewFileViewModel, File>();
            config.CreateMap<File, FileViewModel>();
            config.CreateMap<EditFileViewModel, File>()
                .ReverseMap();
        }
    }
}