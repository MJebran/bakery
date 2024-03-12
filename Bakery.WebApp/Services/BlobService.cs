using Bakery.ClassLibrary.Services;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;

namespace Bakery.WebApp.Services
{

    public class BlobService : IBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlobService> _logger;
        string blobStorageconnection = String.Empty;
        private string blobContainerName = "itemcontainer";

        public BlobService()
        {
            blobStorageconnection = _configuration.GetConnectionString("blobStorage");
        }
        public async Task<bool> DeleteFileToBlobAsync(string strFileName)
        {
            try
            {
                var container = new BlobContainerClient(blobStorageconnection, blobContainerName);
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = container.GetBlobClient(strFileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                return true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<string> UploadFileToBlobAsync(string strFileName, string contecntType, Stream fileStream)
        {
            try
            {
                var container = new BlobContainerClient(blobStorageconnection, blobContainerName);
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = container.GetBlobClient(strFileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contecntType });
                var urlString = blob.Uri.ToString();
                return urlString;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw;
            }
        }
    }
}
