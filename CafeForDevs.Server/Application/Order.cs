namespace CafeForDevs.Server.Application
{
    internal class Order
    {
        private List<OrderPosition> _positions;

        internal Order()
        {
            _positions = new List<OrderPosition>();
        }

        internal void AddPosition(MenuItem menuItem, uint quantity)
        {
            try
            {
                var position = new OrderPosition()
                {
                    Name = menuItem.Name,
                    Price = menuItem.Price,
                    Quantity = quantity
                };
                _positions.Add(position);
            }
            catch (Exception ex)
            {
                throw new ServerExceptions("Был выбран несуществующий id блюда! ", ex);
            }
        }

        internal OrderPosition[] GetPositions()
        {
            return _positions.ToArray();
        }
    }
}
