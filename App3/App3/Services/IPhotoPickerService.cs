using System.IO;
using System.Threading.Tasks;

namespace App3.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}