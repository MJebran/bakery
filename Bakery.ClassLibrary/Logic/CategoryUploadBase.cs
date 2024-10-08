using Microsoft.AspNetCore.Components;
using Bakery.WebApp.Data;
using Bakery.ClassLibrary.Services;
using Microsoft.AspNetCore.Components.Forms;
using Bakery.WebApp.Telemetry;

namespace Bakery.ClassLibrary.Logic;

public class CategoryUploadBase : ComponentBase
{
    [Inject]
    ICategoryService? _categoryservice { get; set; }

    [Inject]
    IBlobStorageService? _blobService { get; set; }
    [Inject]
    PageLogger? _logger {get; set; }
    public Category categoryToAdd { get; set; } = new();
    protected List<IBrowserFile> loadedFiles = new();
    IReadOnlyList<IBrowserFile>? selectedFiles;
    public List<FileUploadViewModel> fileUploadViewModels = new();
    protected void OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFiles = e.GetMultipleFiles();

        this.StateHasChanged();
    }
    public async Task AddCategory()
    {
        if (categoryToAdd is not null)
        {
             _logger?.AddCategoryLogNotification();
            await _categoryservice!.AddCategory(categoryToAdd);

            await OnUploadSubmit();
        }
    }
    public async Task OnUploadSubmit()
    {
        if (selectedFiles is not null)
        {
            foreach (var file in selectedFiles)
            {
                var trustedFileNameForFileStorage = (categoryToAdd?.CategoryName ?? "").Replace(" ", "");
                var blobUrl = await _blobService!.UploadFileToBlobAsync(trustedFileNameForFileStorage, file.ContentType, file.OpenReadStream(20971520));
                if (blobUrl != null)
                {
                    FileUploadViewModel fileUploadViewModel = new FileUploadViewModel()
                    {
                        FileName = trustedFileNameForFileStorage,
                        FileStorageUrl = blobUrl,
                        ContentType = file.ContentType,
                    };

                    fileUploadViewModels.Add(fileUploadViewModel);
                }
            }
        }
    }
}