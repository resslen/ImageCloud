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

        public Folder Find(int id)
        {
            var folder = _context.Folders
                .SingleOrDefault(x => x.Id == id);

            if (folder == null)
            {
                throw new System.IO.FileNotFoundException();
            }
            return folder;
        }

        public ICollection<FolderModel> GetFolders(int id)
        {
            var foldersDal = _context.Folders
                .Where(x => x.ParentFolderId == id)
                .ToList();
            return Mapper.Map<List<FolderModel>>(foldersDal);
        }

        public FolderListViewModel GetFolderById(int id)
        {
            return new FolderListViewModel
            {
                Folders = GetFolders(id),
                Files = _filesService.GetFilesForFolder(id)
            };
        }

    }
}