using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ImageCloudMVC.Services
{
    public class FilesService
    {
        private readonly ImageCloudContext _context;
       // private readonly FoldersService _foldersService;

        public FilesService(ImageCloudContext context)
        {
            _context = context;
           // _foldersService = foldersService;
        }

        public File Find(int id, string userId)
        {
            var file = _context.Files
                .Include(x => x.Folder)
                .SingleOrDefault(x => x.Id == id && x.UserId == userId);
            
            if (file == null)
            {
                throw new System.IO.FileNotFoundException();
            }
            return file;
        }

        public IEnumerable<FileListViewModel> GetFiles()
        {
            var filesDal = _context.Files
                .ProjectTo<FileListViewModel>(Mapper.Configuration)
                .ToList();
            return filesDal;
        }

        // chyba metoda ta jest do wywalenia
        public IEnumerable<FilesView> GetRootFiles()
        {
            //zmieniac aby id nie bylo na sztywno tylko samo pobieralo sobie id roota
            var filesDal = _context.Files
                .Include(x => x.Folder)
                .Where(x => x.Folder.Id == 1)
                .ProjectTo<FilesView>(Mapper.Configuration)
                .ToList();
            return filesDal;
        }

        public int AddFile(NewFileViewModel model, string userId, int? id)
        {
            var file = Mapper.Map<File>(model);
            file.UserId = userId;
            file.ParentFolderId = id;
            _context.Files.Add(file);
            _context.SaveChanges();
            return file.Id;
        }

        public NewFileViewModel GetAddViewModel()
        {
            return new NewFileViewModel();
        }

        public FileViewModel FileById(int id, string userId)
        {
            var file = Find(id, userId);
            return Mapper.Map<FileViewModel>(file);
        }

        public void Delete(int id, string userId)
        {
            var file = Find(id, userId);
            _context.Files.Remove(file);
           // _foldersService.AmountOfFiles((int)file.ParentFolderId, userId, "sub");
            _context.SaveChanges();
        }

        public EditFileViewModel GetEditViewModel(int id)
        {
            var file = _context.Files
                        .Where(x => x.Id == id)
                        .ProjectTo<EditFileViewModel>()
                        .SingleOrDefault();
            return file;
        }

        public void UpdateFile(int id, EditFileViewModel model, string userId)
        {
            var file = Find(id, userId);
            Mapper.Map(model, file);
            _context.SaveChanges();
        }

        public ICollection<FileModel> GetFilesForFolder(int id, string user_id)
        {
            var filesDal = _context.Files
                .Where(x => x.ParentFolderId == id && x.UserId == user_id)
                .ToList();
            return Mapper.Map<List<FileModel>>(filesDal);
        }

        public void UploadFiles (IEnumerable<HttpPostedFileBase> files, int? id, string userId)
        {
            string directory = HttpContext.Current.Server.MapPath("~/UploadedFiles/");
            foreach (var photo in files)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(photo.FileName);
                    var fileSize = photo.ContentLength;
                    AddFile(new NewFileViewModel
                    {
                        Name = fileName,
                        DateOfUpload = DateTime.Now,
                        Description = "",
                        Resolution = 0,
                        Size = fileSize,
                    }, userId, id);
                    photo.SaveAs(System.IO.Path.Combine(directory, fileName));
                    //_foldersService.AmountOfFiles((int)id, userId, "add");
                }
            }
        }


    }
}