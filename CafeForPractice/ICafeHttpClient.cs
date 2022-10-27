using CafeForDevs.Models;

public interface ICafeHttpClient
{
    MenuModel GetMenu();

    void SelectMenuItem(uint menuItemId, uint quantity);

    OrderModel GetOrder();
}