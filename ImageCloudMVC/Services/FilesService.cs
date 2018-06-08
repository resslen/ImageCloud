using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageCloudMVC.DAL;
using ImageCloudMVC.Models;
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

        public FilesService(ImageCloudContext context)
        {
            _context = context;
        }

        public IEnumerable<FileListViewModel> GetFiles()
        {
            var filesDal = _context.Files
                .ToList();
            return Mapper.Map<IEnumerable<FileListViewModel>>(filesDal);
        }

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

        public int AddFile(NewFileViewModel model)
        {
            var file = Mapper.Map<File>(model);
            _context.Files.Add(file);
            _context.SaveChanges();
            return file.Id;
        }
    }
}