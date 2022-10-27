using CafeForDevs.Models;
using CafeForDevs.Server.Application;
using System.Net;

namespace CafeForDevs.Server.Handlers
{
    public class OrderHandler : Handler, IHandler
    {
        public string Path => "/order";

        private Order _order;

        public OrderHandler()
        {
            _order = new Order();
        }

        public void Handle(HttpListenerContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    var order = GetOrder();
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    SetResponse(order, context);
                    break;
                case "POST":
                    var request = GetRequestBody<MenuItemRequestModel>(context);
                    SelectMenuItem(request.MenuItemId, request.Quantity);

                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                    break;
            }
            context.Response.Close();
        }

        private void SelectMenuItem(uint menuItemId, uint quantity)
        {
            var menuItem = Menu.Get(menuItemId);
            _order.AddPosition(menuItem, quantity);
        }

        private OrderModel GetOrder()
        {
            var order = new OrderModel()
            {
                Positions = _order.GetPositions()
                .Select(x => new OrderPositionModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
                .ToArray()
            };
            return order;
        }
    }
}
