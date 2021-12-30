using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace McShares.API.Services.File
{
    public interface IFileService
    {
        Task UploadFile(IFormFile file, string subDirectory, string fileName);
    }
}
