using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Models.Folders;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
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

        public Folder Find(int id, string userId)
        {
            var folder = _context.Folders
                .SingleOrDefault(x => x.Id == id && x.UserId == userId);

            if (folder == null)
            {
                throw new System.IO.FileNotFoundException();
            }
            return folder;
        }

        public ICollection<FolderModel> GetFolders(int id, string user_id, string searchString)
        {
            var foldersDal = _context.Folders
                .Where(x => x.ParentFolderId == id && x.UserId == user_id);
            if (!String.IsNullOrEmpty(searchString))
            {
                foldersDal = foldersDal
                    .Where(x => x.Name.Contains(searchString));
            }
            foldersDal.ToList();
            return Mapper.Map<List<FolderModel>>(foldersDal);
        }

        public FolderListViewModel GetFolderById(int id, string user_id, string searchString, string searchString2)
        {
            return new FolderListViewModel
            {
                Folders = GetFolders(id, user_id, searchString),
                Files = _filesService.GetFilesForFolder(id, user_id, searchString2)
            };
        }

        public NewFolderViewModel GetAddViewModel()
        {
            return new NewFolderViewModel();
        }

        public int AddFolder(NewFolderViewModel model, string userId)
        {
            var folder = Mapper.Map<Folder>(model);
            folder.UserId = userId;
            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder.Id;
        }

        public void Delete(int id, string userId)
        {
            var folder = Find(id, userId);
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

        public void UpdateFolder(int id, EditFolderViewModel model, string userId)
        {
            var folder = Find(id, userId);
            Mapper.Map(model, folder);
            _context.SaveChanges();
        }

        public int GetRootId(string userId)
        {
            if (userId != null)
            {
                var folder = _context.Folders
                .Where(x => x.UserId == userId && x.ParentFolderId == null)
                .Select(x => x.Id)
                .Single();
                return folder;
            }
            else
                return -1;
        }

        public void Move(int source, int destination, string userId)
        {
            var folder = Find(destination, userId);
            var file = _filesService.Find(source, userId);

            file.ParentFolderId = folder.Id;
            folder.AmountOfFiles++;
            _context.SaveChanges();
        }

        public void AmountOfFiles(int id, string userId, string operation)
        {
            var folder = Find(id, userId);
            if(operation == "add")
            {
                folder.AmountOfFiles++;
            }else
            if( operation == "sub")
            {
                folder.AmountOfFiles--;
            }
            _context.SaveChanges();
        }
    }
}