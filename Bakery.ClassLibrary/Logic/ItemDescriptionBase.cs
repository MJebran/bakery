using Microsoft.AspNetCore.Components;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.WebApp.Logic;
public class ItemDescriptionBase : ComponentBase
{
    [Inject]
    IItemTypeService? _itemservice { get; set; }

    [Parameter]
    public string? ItemId { get; set; }
    protected Itemtype ItemToDisplay { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        var items = (await _itemservice!.GetAllItemtypes()).ToList<Itemtype>();
        ItemToDisplay = items.Where(i => i.ItemTypeId == Int32.Parse(ItemId ?? "")).First<Itemtype>();
    }
}