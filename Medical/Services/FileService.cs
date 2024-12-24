using Medical.General;
using Medical.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical.Services
{
    public class FileService
    {
        AppDbContext context;
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment=environment ;
            context = new AppDbContext();
        }
        public AppFiles Uploadfile(fileUploadModel fileUploaded) {

            var newFile = new AppFiles();
            if (fileUploaded.File != null || fileUploaded.File.Length > 0)
            {
                //throw new ArgumentException("file is not found");
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "Images/");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileUploaded.File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileUploaded.File.CopyTo(stream);
                }
                newFile.filePath = filePath;
                newFile.fileName = fileUploaded.File.FileName;
            }
            return newFile;
        }
    }
}
