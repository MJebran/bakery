using Bakery.ClassLibrary.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

public class BlobServiceTest : IBlobStorageService
{
    public Task<bool> DeleteFileToBlobAsync(string strFileName)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadFileToBlobAsync(string strFileName, string contecntType, Stream fileStream)
    {
        return Task.FromResult("Assume this File has been Uploaded");

    }
}