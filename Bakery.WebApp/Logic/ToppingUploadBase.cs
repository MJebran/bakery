using Microsoft.AspNetCore.Components;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components.Forms;

namespace Bakery.WebApp.Logic;

public class ToppingUploadBase : ComponentBase
{
    [Inject]
    IToppingService? _toppingService {get; set;}

    [Inject]
    IBlobStorageService? _blobService {get; set;}
    public Topping? toppingToAdd {get; set;} = new();
    protected List<IBrowserFile> loadedFiles = new();
    IReadOnlyList<IBrowserFile>? selectedFiles;
    protected List<FileUploadViewModel> fileUploadViewModels = new();
    protected void OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFiles = e.GetMultipleFiles();

        this.StateHasChanged();
    }
    public async Task AddTopping()
    {
        if(toppingToAdd is not null)
        {
            await _toppingService!.AddTopping(toppingToAdd);

            await OnUploadSubmit();
        }
    }
    protected async Task OnUploadSubmit()
    {
        if(selectedFiles is not null)
        {
            foreach (var file in selectedFiles)
            {
                var trustedFileNameForFileStorage = (toppingToAdd?.ToppingName??"").Replace(" ", "");
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