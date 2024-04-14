using Bakery.WebApp.Data;
using Riok.Mapperly.Abstractions;

namespace Bakery.WebApp.Services;

[Mapper]
public partial class BakeryMapper
{
    public partial PurchaseDTO PurchaseToPurchaseDto(Purchase purchase);
    public partial CategoryDTO CategoryToCategoryDto(Category category);
    public partial CustomItemDTO CustomItemToCustomItemDto(Customitem customItem);
    public partial CustomitemtoppingDTO CustomItemToppingToCustomItemToppingDto(Customitemtopping customItemTopping);
    public partial FavoriteitemDTO FavoriteItemToFavoriteItemDto(Favoriteitem favoriteItem);
    public partial ItempurchaseDTO ItemPurchaseToItemPurchaseDto(Itempurchase itemPurchase);
    public partial ItemtypeDTO ItemTypeToItemTypeDto(Itemtype itemType);
    public partial RoleDTO RoleToRoleDto(Role role);
    public partial SizeDTO SizeToSizeDto(Size size);
    public partial ToppingDTO ToppingToToppingDto(Topping topping);
    public partial UserDTO UserToUserDto(User user);

}
