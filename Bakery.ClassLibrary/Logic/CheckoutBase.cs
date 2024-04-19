using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Bakery.ClassLibrary.Logic;
public class CheckoutBase : ComponentBase
{
    private IJSObjectReference? module;

    [Parameter]
    public string? purchaseId { get; set; }

    [Parameter]
    public IJSRuntime? Js { get; set; }

    [Inject]
    public IEmailService? _emailservice { get; set; }

    [Inject]
    public IBakeryAutheticationService? _authenticationservice { get; set; }
    
    [Inject]
    public IPurchaseService? _purchaseservice { get; set; }

    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    public List<Itempurchase>? itempurchases { get; set; }
    protected int TotalQty { get; set; }
    protected string? PaymentDescription { get; set; }
    protected decimal PaymentAmount { get; set; }
    protected decimal TaxAmount { get; set; }
    protected string DisplayButtons { get; set; } = "block";
    public int PurchaseId { get; set; }
    public User? user {get; set;}
    public Purchase? userCart {get; set;}


    protected override async Task OnInitializedAsync()
    {
        PurchaseId = int.Parse(purchaseId ?? "0");
        user = _authenticationservice?.GetAuthenticatedUser();
        userCart = (await _purchaseservice!.GetAllPurchase()).ToList<Purchase>().Where(p => p.PurchaseId == PurchaseId).FirstOrDefault();

        try
        {
            itempurchases = userCart?.Itempurchases.ToList<Itempurchase>();

            if (itempurchases != null && itempurchases.Count() > 0)
            {

                PaymentAmount = 0;

                foreach (var itempurchase in itempurchases)
                {
                    var customitem = itempurchase.ItempurchaseItem;

                    foreach (var customitemtopping in customitem.Customitemtoppings)
                    {
                        PaymentAmount += customitemtopping.Topping.ToppingPrice * customitemtopping.CustomItemToppingQuantity ?? 0m;
                    }

                    PaymentAmount += customitem.Item.ItemPrice * itempurchase.ItempurchaseQuantity ?? 0m;

                }
                TaxAmount = (int)Math.Round(PaymentAmount) - PaymentAmount;
                PaymentAmount = (int)Math.Round(PaymentAmount);
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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var dotNetReference = DotNetObjectReference.Create(this);
            module = await Js.InvokeAsync<IJSObjectReference>("import", "/js/Checkout.js");
            await module.InvokeVoidAsync("initialisePayPal", dotNetReference);
        }

    }
    public async Task SendEmailAfterSuccesfulPurchase()
    {
        await _emailservice!.SendEmailAsync(user?.UserEmail ?? throw new Exception("user email not found"), itempurchases);
    }

    public async Task MarkCartAsCompletedPurchase()
    {
        if(userCart is not null)
        {
            userCart.Ispayed = true;
            _purchaseservice?.UpdatePurchase(userCart);
            await Task.CompletedTask;
        }
        else{
            throw new Exception("user cart not available");
        }
    }

}

//madeup comment
