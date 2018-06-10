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

        public NewFolderViewModel GetAddViewModel()
        {
            return new NewFolderViewModel();
        }

        public int AddFolder(NewFolderViewModel model)
        {
            var folder = Mapper.Map<Folder>(model);
            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder.Id;
        }

        public void Delete(int id)
        {
            var folder = Find(id);
            _context.Folders.Remove(folder);
            _context.SaveChanges();
        }

        public EditFolderViewModel GetEditViewModel(int id)
        {
            var folder = _context.Folders
                        .Where(x => x.Id == id)
                        .ProjectTo<EditFolderViewModel>()
                        .SingleOrDefault();
            return folder;
        }

        public void UpdateFolder(int id, EditFolderViewModel model)
        {
            var folder = Find(id);
            Mapper.Map(model, folder);
            _context.SaveChanges();
        }

    }
}