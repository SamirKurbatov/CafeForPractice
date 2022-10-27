using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeForDevs.Server.Application
{
    internal static class Menu
    {
        static Menu()
        {
            Items = new[]
            {
                    new MenuItem()
                    {
                        Id = 1,
                        Name = "Apple",
                        Price = 13300
                    },

                     new MenuItem()
                    {
                        Id = 2,
                        Name = "Cheese",
                        Price = 1200
                    },

                      new MenuItem()
                    {
                        Id = 3,
                        Name = "Cavasaki",
                        Price = 1012320
                    },
            };
        }
        internal static MenuItem[] Items { get; private set; }

        internal static MenuItem Get(uint menuItemId)
        {
            var items = Items.SingleOrDefault(x => x.Id == menuItemId);
            return items;
        }
    }

}
