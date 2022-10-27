using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeForDevs.Client
{
    internal class ClientApplication
    {
        private ICafeHttpClient _cafeHttpClient;

        public ClientApplication(ICafeHttpClient cafeHttpClient)
        {
            _cafeHttpClient = cafeHttpClient;
        }

        internal void Start()
        {
            try
            {
                Console.WriteLine("ClientApplication запущен");
                var isUserContiniue = true;
                string userAnswer;
                do
                {
                    PrintMainMenu(); // главное меню
                    userAnswer = Console.ReadLine();

                    // сделать проверку а число из пункта меню

                    switch (userAnswer)
                    {
                        case "1":
                            PrintMenu();
                            break;
                        case "2":
                            SelectMenuItem();
                            break;
                        case "3":
                            PrintOrder();
                            break;
                        default:
                            Console.WriteLine("Вы ввели недопустимый символ! ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    Console.WriteLine("Будете ли вы продолжать? (y/n)");
                    userAnswer = Console.ReadLine();
                    isUserContiniue = userAnswer.ToLower() == "y";
                    Console.Clear();
                } while (isUserContiniue);
            }
            catch (Exception ex)
            {
                throw new ClientException("Ошибка клиента...", ex);
            }

        }

        internal void PrintMainMenu()
        {
            Console.WriteLine("выберите пункт меню:" +
              "\n\t1) вывести меню " +
              "\n\t2) выбрать блюдо из меню" +
              "\n\t3) вывести информацию о своем заказе" +
              "\n\t4) оплатить заказ");
        }

        internal void PrintMenu()

        {
            var menu = _cafeHttpClient.GetMenu();

            foreach (var item in menu.Items)
            {
                Console.WriteLine($"№{item.Id} {item.Name} - {item.Price}");
            }
        }

        internal void SelectMenuItem()
        {
            try
            {
                var menuItems = _cafeHttpClient.GetMenu().Items;
                Console.WriteLine("Введите номер пункта блюда: ");
                var menuItemId = uint.Parse(Console.ReadLine());
                if (menuItems.All(x => x.Id != menuItemId))
                {
                    throw new ClientException("Вы ввели несуществующий id блюда! ");
                }
                Console.WriteLine("Введите количество блюд: ");
                var quantity = uint.Parse(Console.ReadLine());
                _cafeHttpClient.SelectMenuItem(menuItemId, quantity);
            }
            catch (ClientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void PrintOrder()
        {
            var order = _cafeHttpClient.GetOrder();

            foreach (var position in order.Positions)
            {
                Console.WriteLine($"{position.Name}: {position.Price} * {position.Quantity} = {position.Sum}");
            }

            var orderTotal = order.Positions.Sum(x => x.Sum);

            Console.WriteLine($"Сумма вашего заказа: {orderTotal}");
        }
    }
}
