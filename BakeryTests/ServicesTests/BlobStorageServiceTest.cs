using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryTests.ServicesTests;

public class BlobStorageServiceTest : IBlobStorageService
{
    private readonly ILogger<BlobService> _logger;
    string blobStorageconnection = String.Empty;
    private string blobContainerName = "itemcontainer";

    public BlobStorageServiceTest(IConfiguration _config)
    {
        blobStorageconnection = _config["blobStorage"];
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
