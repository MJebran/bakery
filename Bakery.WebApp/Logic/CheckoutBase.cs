using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Collections.Immutable;
using Bakery.WebApp.Authentication;

namespace Bakery.WebApp.Logic;
public class CheckoutBase : ComponentBase
{
    private IJSObjectReference? module;

    [Inject]
    public IJSRuntime Js { get; set; }

    [Inject]
    public IEmailService _emailservice { get; set; }

    [Inject]    
    public IBakeryAutheticationService _authenticationservice { get; set; }
    public List<Itempurchase>? itempurchases { get; set; }
    protected int TotalQty { get; set; }
    protected string? PaymentDescription { get; set; }
    protected decimal PaymentAmount { get; set; }
    protected decimal TaxAmount {get; set;}
    protected string DisplayButtons { get; set; } = "block";

    [Parameter]
    public string? purchaseId { get; set; }

    [Inject]
    public IPurchaseService? _purchaseservice { get; set; }
    public int PurchaseId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PurchaseId = int.Parse(purchaseId ?? "0");

        try
        {
            itempurchases = (await _purchaseservice.GetAllPurchase()).Where(p => p.PurchaseId == PurchaseId).FirstOrDefault().Itempurchases.ToList<Itempurchase>();

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
            module = await Js.InvokeAsync<IJSObjectReference>("import", "/js/Checkout.js");
            await module.InvokeVoidAsync("initialisePayPal");
        }

    }
    public async Task Purchase()
    {
        //Esto es lo que te digo, osea _emailService esta nulo tengo que ponerlo en iniatization?
        var User = _authenticationservice.GetAuthenticatedUser();
        await _emailservice.SendEmailAsync(User.UserEmail ?? throw new Exception("user email not found"), itempurchases);
    }
}
