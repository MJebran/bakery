using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components;

namespace Bakery.WebApp.Logic;
public class CartBase : ComponentBase
{
    [Parameter]
	public string? cartId { get; set; }

    [Inject]
    IItemPurchaseService? _itemPurchaseService {get; set;}

    [Inject]
    ICustomItemService? _customItemService {get; set;}

    [Inject]
    ICustomeItemToppingService? _customItemToppingService {get; set;}

    [Inject]
    NavigationManager? NavigationManager {get; set;}
	List<Itempurchase>? userPurchases { get; set; }
	public Dictionary<Itempurchase, int>? itemPurchaseQuantity { get; set; } = new();

	protected override async Task OnInitializedAsync()
	{
		var purchases = (await _itemPurchaseService!.GetAllItempurchase()).ToList();
		userPurchases = purchases.Where(c => c.PurchaseId == Int32.Parse(cartId ?? "")).ToList();

		foreach (var purchaseItem in userPurchases)
		{
			itemPurchaseQuantity?.Add(purchaseItem, 1);
		}
	}

	protected void DecreasingAmountItem(Itempurchase itempurchase)
	{
		if (itemPurchaseQuantity?[itempurchase] > 1)
		{
			itemPurchaseQuantity[itempurchase] -= 1;
		}
	}

	protected void IncreasingAmountItem(Itempurchase itempurchase)
	{
		if (itemPurchaseQuantity is not null)
		{
			itemPurchaseQuantity[itempurchase] += 1;
		}
	}

	protected async Task RemoveFromCart(Itempurchase itempurchase)
	{
		await _itemPurchaseService!.DeleteItempurchase(itempurchase.ItempurchaseId);
		foreach (var customtopping in itempurchase.ItempurchaseItem.Customitemtoppings)
		{
			await _customItemToppingService!.DeleteCustomeItemTopping(customtopping.CustomItemToppingId);
		}
		await _customItemService!.DeleteCustomitem(itempurchase.ItempurchaseItem.CustomItemId);

		NavigationManager!.NavigateTo($"/cart/{itempurchase.PurchaseId}", forceLoad: true);
	}

	protected decimal ComputeTotal()
	{
		decimal total = 0;

		if (itemPurchaseQuantity is not null)
		{
			foreach (var item in itemPurchaseQuantity)
			{
				var pricePerItem = item.Key.ItempurchaseItem.Item.ItemPrice;
				foreach (var topping in item.Key.ItempurchaseItem.Customitemtoppings)
				{
					pricePerItem += topping.CustomItemToppingQuantity * topping.Topping.ToppingPrice;
				}
				pricePerItem *= item.Value;
				total += pricePerItem ?? 0m;
			}
		}

		return total;
	}

}
