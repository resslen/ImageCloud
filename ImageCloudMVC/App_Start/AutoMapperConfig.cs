using AutoMapper;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Models;
using ImageCloudMVC.Models.Files;
using ImageCloudMVC.Models.Folders;

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
            config.CreateMap<File, FileModel>();
            config.CreateMap<FileModel, FolderListViewModel>();

            config.CreateMap<Folder, FolderListViewModel>();
            config.CreateMap<Folder, FolderModel>();
            config.CreateMap<FolderModel,FolderListViewModel>();
            config.CreateMap<EditFolderViewModel, Folder>()
                .ReverseMap();
            config.CreateMap<NewFolderViewModel, Folder>();
        }
    }
}