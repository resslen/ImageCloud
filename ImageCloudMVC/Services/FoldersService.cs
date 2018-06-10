using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Models.Folders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Services
{
    public class FoldersService
    {
        private readonly ImageCloudContext _context;
        private readonly FilesService _filesService;

        public FoldersService(ImageCloudContext context, FilesService filesService)
        {
            _context = context;
            _filesService = filesService;
        }

        public ICollection<FolderModel> GetFolders()
        {
            IQueryable<Folder> foldersDal = _context.Folders;
            return Mapper.Map<List<FolderModel>>(foldersDal);
        }

        public FolderListViewModel GetAll()
        {
            return new FolderListViewModel
            {
                Folders = GetFolders(),
                Files = _filesService.GetFilesForFolder()
            };
        }

    }
}