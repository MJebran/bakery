using Microsoft.AspNetCore.Components;
using Bakery.WebApp.Data;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;

namespace Bakery.ClassLibrary.Logic;
public class CustomizeItemBase : ComponentBase
{
    [Parameter]
    public string? baseItemId { get; set; }

    [Inject]
    protected IItemTypeService? _itemservice { get; set; }

    [Inject]
    protected IToppingService? _toppingservice { get; set; }

    [Inject]
    protected ICustomItemService? _customItemService { get; set; }

    [Inject]
    protected IPurchaseService? _purchaseservice { get; set; }

    [Inject]
    protected IItemPurchaseService? _itemPurchaseService { get; set; }

    [Inject]
    protected IBakeryAutheticationService? _authenticationService { get; set; }

    [Inject]
    protected ICustomeItemToppingService? _customItemToppingService { get; set; }

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }
    protected User? user { get; set; } = new();
    protected Customitem userCustomItem { get; set; } = new();
    protected Itemtype? baseItem { get; set; } = new();
    protected Purchase? userCart { get; set; } = new();
    protected string? ErrorMesage { get; set; } = null;
    protected Dictionary<Topping, int>? toppingToQuantity { get; set; }
    protected char? sizeItem { get; set; } = 'M';

    protected override async Task OnInitializedAsync() 
    {
        user = _authenticationService!.GetAuthenticatedUser();
    }

    protected override async Task OnParametersSetAsync()
    {
        var items = (await _itemservice!.GetAllItemtypes()).ToList<Itemtype>();

        var toppings = (await _toppingservice!.GetAllToppings()).ToList<Topping>();
        baseItem = items
        .Where(i => i.ItemTypeId == Int32.Parse(baseItemId ?? ""))
        .First<Itemtype>();

        userCustomItem = new Customitem()
        {
            ItemId = baseItem?.ItemTypeId ?? 0
        };

        toppingToQuantity = new();

        foreach (var topping in toppings)
        {
            toppingToQuantity?.Add(topping, 0);
        }
    }

    protected void IncreaseToppingAmount(Topping topping)
    {
        if (toppingToQuantity is not null)
            toppingToQuantity[topping] += 1;
    }

    protected void DecreaseToppingAmount(Topping topping)
    {
        if (toppingToQuantity?[topping] > 0)
        {
            toppingToQuantity[topping] -= 1;
        }
    }

    protected decimal ComputeTotalPrice()
    {
        decimal total = 0;

        if (toppingToQuantity is not null)
        {
            foreach (var toppingAndQuantity in toppingToQuantity)
            {
                total += toppingAndQuantity.Key.ToppingPrice * toppingAndQuantity.Value ?? 0.0m;
            }
        }

        total += baseItem?.ItemPrice ?? 0.0m;

        return total;
    }

    protected async Task AddToCart()
    {
        if (!_authenticationService.UserExists())
        {
            ReturnErrorMessage();
            return;
        }
        var purchases = (await _purchaseservice.GetAllPurchase()).ToList<Purchase>();

        if (purchases.Count() > 0)
        {
            userCart = purchases
            .Where(p => p.PurchaseUserId == user?.UserId && p.Ispayed == false)
            .FirstOrDefault<Purchase>();
        }

        if (userCart is null)
        {
            await CreateCartForUser();
            await AddToCart();
            return;
        }

        await _customItemService!.AddCustomitem(userCustomItem);

        await AddCustomItemToppings(userCustomItem);

        await _itemPurchaseService!.AddItempurchase(new Itempurchase()
        {
            ItempurchaseQuantity = 1,
            PurchaseId = userCart?.PurchaseId ?? 0,
            ItempurchaseItemId = userCustomItem.CustomItemId
        });

        NavigationManager!.NavigateTo($"/cart/{userCart.PurchaseId}");
    }

    protected async Task CreateCartForUser()
    {
        await _purchaseservice!.AddPurchase(new Purchase()
        {
            PurchaseUserId = user?.UserId ?? 0,
            Ispayed = false
        });
    }

    protected async Task AddCustomItemToppings(Customitem baseCustomItem)
    {
        if (toppingToQuantity is not null)
        {
            foreach (var toppingAndQuantity in toppingToQuantity)
            {
                if (toppingAndQuantity.Value > 0)
                {
                    await _customItemToppingService!.AddCustomeItemTopping(new Customitemtopping()
                    {
                        CustomItemId = baseCustomItem.CustomItemId,
                        ToppingId = toppingAndQuantity.Key.ToppingId,
                        CustomItemToppingQuantity = toppingAndQuantity.Value
                    });
                }
            }
        }
    }

    protected char FilterSelection(char size)
    {
        sizeItem = size;
        return size;
    }
    protected void ReturnErrorMessage()
    {
        ErrorMesage = "You're not logged in!";
    }
}