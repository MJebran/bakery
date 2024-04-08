using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Immutable;

namespace Bakery.WebApp.Logic;
public class CheckoutBase : ComponentBase
{
        [Inject]
        public IJSRuntime Js { get; set; }
        protected List<Itempurchase>? itempurchases { get; set; }
    protected int TotalQty { get; set; }
        protected string? PaymentDescription { get; set; }
        protected decimal PaymentAmount { get; set; }
        protected string DisplayButtons { get; set; } = "block";
        [Parameter]
        public string? purchaseId { get; set; }

        [Inject]
        public IPurchaseService? _purchaseservice { get; set; }
        
        public int PurchaseId {get; set;}

        protected override async Task OnInitializedAsync()
        {
            PurchaseId = int.Parse(purchaseId ?? "0");
        try
            {
                var userCart = (await _purchaseservice.GetAllPurchase()).Where(p => p.PurchaseId == PurchaseId).FirstOrDefault();
                itempurchases = userCart?.Itempurchases.ToList<Itempurchase>();

                if (itempurchases != null && itempurchases.Count() > 0)
                {

                    PaymentAmount = 0;

                    foreach (var itempurchase in itempurchases)
                    {
                        var customitem = itempurchase.ItempurchaseItem;

                        foreach(var customitemtopping in customitem.Customitemtoppings)
                        {
                            PaymentAmount += customitemtopping.Topping.ToppingPrice * customitemtopping.CustomItemToppingQuantity ?? 0m;
                        }

                        PaymentAmount += customitem.Item.ItemPrice * itempurchase.ItempurchaseQuantity ?? 0m;
                        
                    }
                    TotalQty = 10;
                    PaymentDescription = "Some random description xdd";
                }
                else
                {
                    DisplayButtons = "none";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }  
}
