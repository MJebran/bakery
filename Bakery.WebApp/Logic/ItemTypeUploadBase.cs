using Microsoft.AspNetCore.Components;
using Bakery.WebApp.Data;
using Bakery.ClassLibrary.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace Bakery.WebApp.Logic;
public class ItemTypeUploadBase : ComponentBase
{
    [Inject]
    IItemTypeService? _itemservice {get; set;}

    [Inject]
    ICategoryService? _categoryservice {get; set;}

    [Inject]
    ISizeService? _sizeservice {get; set;}

    [Inject]
    IBlobStorageService? _blobService {get; set;}
    protected List<Size> sizes = new();
    protected List<Category> categories = new();
    protected Itemtype? itemToAdd {get; set;} = new();
    protected List<IBrowserFile> loadedFiles = new();
    IReadOnlyList<IBrowserFile>? selectedFiles;
    protected List<FileUploadViewModel> fileUploadViewModels = new();
    
    protected override async Task OnInitializedAsync()
    {
        sizes = (await _sizeservice!.GetAllSizes()).ToList<Size>();
        categories = (await _categoryservice!.GetAllCategories()).ToList<Category>();
    }
    protected void OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFiles = e.GetMultipleFiles();
        this.StateHasChanged();
    }
    protected async Task AddItem()
    {
        if(itemToAdd is not null)
        {
            await _itemservice!.AddItemtype(itemToAdd);

            await OnUploadSubmit();
        }
    }
    protected async Task OnUploadSubmit()
    {
        if(selectedFiles is not null)
        {
            foreach (var file in selectedFiles)
            {
                var trustedFileNameForFileStorage = (itemToAdd?.ItemName ?? "").Replace(" ", "");
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