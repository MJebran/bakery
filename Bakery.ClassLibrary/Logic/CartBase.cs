using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components;

namespace Bakery.WebApp.Logic;
public class CartBase : ComponentBase
{
    [Parameter]
    public string? cartId { get; set; }

    [Inject]
    IItemPurchaseService? _itemPurchaseService { get; set; }

    [Inject]
    ICustomItemService? _customItemService { get; set; }

    [Inject]
    ICustomeItemToppingService? _customItemToppingService { get; set; }

    [Inject]
    NavigationManager? NavigationManager { get; set; }
    List<Itempurchase>? userPurchases { get; set; }
    public Dictionary<Itempurchase, int> itemPurchaseToQuantity { get; set; } = new();
    bool HasAtLeastOneInCart(Itempurchase itempurchase) => itemPurchaseToQuantity?[itempurchase] > 1;

    protected override async Task OnInitializedAsync()
    {
        var purchases = (await _itemPurchaseService!.GetAllItempurchase()).ToList();
        userPurchases = purchases.Where(c => c.PurchaseId == int.Parse(cartId ?? "")).ToList();

        foreach (var purchaseItem in userPurchases)
        {
            itemPurchaseToQuantity.Add(purchaseItem, 1);
        }
    }

    protected void DecreasingAmountItem(Itempurchase itempurchase)
    {
        if (HasAtLeastOneInCart(itempurchase))
        {
            itemPurchaseToQuantity[itempurchase] -= 1;
        }
    }

    protected void IncreasingAmountItem(Itempurchase itempurchase)
    {
        itemPurchaseToQuantity[itempurchase] += 1;
    }

    protected async Task RemoveFromCart(Itempurchase itempurchase)
    {
        await DeleteItemPurchase(itempurchase);
        await DeleteCustomItemToppings(itempurchase.ItempurchaseItem.Customitemtoppings);
        await DeleteCustomItem(itempurchase.ItempurchaseItem.CustomItemId);

        RefreshCartPage(itempurchase.PurchaseId);
    }

    private async Task DeleteItemPurchase(Itempurchase itempurchase)
    {
        await _itemPurchaseService!.DeleteItempurchase(itempurchase.ItempurchaseId);
    }

    private async Task DeleteCustomItemToppings(IEnumerable<Customitemtopping> customToppings)
    {
        foreach (var customTopping in customToppings)
        {
            await _customItemToppingService!.DeleteCustomeItemTopping(customTopping.CustomItemToppingId);
        }
    }

    private async Task DeleteCustomItem(int customItemId)
    {
        await _customItemService!.DeleteCustomitem(customItemId);
    }

    private void RefreshCartPage(int purchaseId)
    {
        NavigationManager!.NavigateTo($"/cart/{purchaseId}", forceLoad: true);
    }

    protected decimal ComputeTotal()
    {
        decimal total = 0;

        if (itemPurchaseToQuantity is not null)
        {
            foreach (var item in itemPurchaseToQuantity)
            {
                total += ComputeTotalForItem(item.Key, item.Value);
            }
        }

        return total;
    }

    protected decimal ComputeTotalForToppings(IEnumerable<Customitemtopping> toppings)
    {
        decimal total = 0;

        foreach (var topping in toppings)
        {
            total += topping.CustomItemToppingQuantity ?? 0 * topping.Topping.ToppingPrice ?? 0;
        }

        return total;
    }

    protected decimal ComputeTotalForItem(Itempurchase itempurchase, int itemQuantity)
    {
        decimal total = 0;
        var baseItemPrice = itempurchase.ItempurchaseItem.Item.ItemPrice ?? 0;

        total += baseItemPrice;
        total += ComputeTotalForToppings(itempurchase.ItempurchaseItem.Customitemtoppings);
        total *= itemQuantity;

        return total;
    }

}
