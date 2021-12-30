using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace McShares.API.Services.File
{
    public class FileService : IFileService
    {
        #region Property  
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor  
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Upload File  
        public async Task UploadFile(IFormFile file, string subDirectory, string fileName)
        {
            subDirectory = subDirectory ?? string.Empty;
            var target = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);
            Directory.CreateDirectory(target);


            if (file.Length <= 0) return;
            var filePath = Path.Combine(target, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        }
        #endregion
    }
}
