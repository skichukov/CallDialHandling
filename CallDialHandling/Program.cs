using System.Text;

namespace CallDialHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] producs = {"01.Картофи", "02.Риба", "03.Ябълка", "04.Портокал", "05.Мляко", "06.Музика", "07.Мъфини"};

            bool isLogged = true;
            List<string> orders = new List<string>();
            List<int> helpRequests = new List<int>();
            List<int> cancelRequests = new List<int>();

            Console.WriteLine(String.Join("\n", producs));

            while (isLogged)
            {
                Console.WriteLine("     \n      \n" +
                    "==========\n" +
                    "Главно меню - въведете само една цифра: \n" +
                    "1 - извършване на поръчка \n" +
                    "2 - показване на всички поръчки \n" +
                    "3 - заявка за помощ за поръчка \n" +
                    "4 - заявка за анулиране на поръчка \n" +
                    "0 - изход от главното меню и програмата");

                string digitIntroduced = Console.ReadLine();

                switch(digitIntroduced)
                {
                    case "1":
                        Console.WriteLine("Въведете двуцифрен код на продукта или 00, за да завършите поръчката.");
                        Console.WriteLine("Ето продуктите и техните кодове:");
                        Console.WriteLine(string.Join("\n", producs));

                        bool isDoing = true;
                        string newOrder = "";

                        while (isDoing)
                        {
                            string codeDialed = Console.ReadLine();

                            switch(codeDialed)
                            {
                                case "01":
                                    Console.WriteLine("Добавяне на картофи към поръчката");
                                    break;
                                case "02":
                                    Console.WriteLine("Добавяне на риба към поръчката");
                                    break;
                                case "03":
                                    Console.WriteLine("Добавяне на ябълка към поръчката");
                                    break;
                                case "04":
                                    Console.WriteLine("Добавяне на портокал към поръчката");
                                    break;
                                case "05":
                                    Console.WriteLine("Добавяне на мляко към поръчката");
                                    break;
                                case "06":
                                    Console.WriteLine("Добавяне на музика към поръчката");
                                    break;
                                case "07":
                                    Console.WriteLine("Добавяне на мъфини към поръчката");
                                    break;
                                case "00":

                                    if (newOrder.Length > 0)
                                    {
                                        Console.WriteLine("Завършване на поръчката...");
                                        orders.Add(newOrder.Trim());
                                        Console.WriteLine("Поръчката е готова.");
                                    }

                                    isDoing = false;
                                    break;
                                default:
                                    Console.WriteLine("Грешен код!");
                                    continue;
                            }

                            if(!isDoing)
                            {
                                break;
                            }

                            newOrder += codeDialed + " ";
                        }

                        break;

                    case "2":
                        if(orders.Count == 0)
                        {
                            Console.WriteLine("Нямате поръчки");
                        }
                        else
                        {
                            Console.WriteLine("Ето вашите поръчки:");

                            foreach (string order in orders)
                            {
                                Console.WriteLine("Номер на поръчката: " + (orders.IndexOf(order) + 1)
                                     + "    Поръчка: " + order);
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Моля, въведете номера на поръчката си, за която се нуждаете от помощ," +
                            " и един от нашите представители ще се свърже с вас: ");

                        int helpNumber = int.Parse(Console.ReadLine());

                        if(orders.ElementAt(helpNumber - 1) != null)
                        {
                            helpRequests.Add(helpNumber);
                            Console.WriteLine("Вашата заявка е получена.");
                        }
                        else { 
                            Console.WriteLine("Невалиден номер на поръчка!");
                        }
                        break;

                    case "4":
                        Console.Write("Моля, въведете номера на поръчката си, която искате да анулирате," +
                            " и един от нашите представители ще я прегледа и премахне вместо вас: ");

                        int cancelNumber = int.Parse(Console.ReadLine());

                        if(orders.ElementAt(cancelNumber - 1) != null)
                        {
                            cancelRequests.Add(cancelNumber);
                            Console.WriteLine("Вашата заявка е получена.");
                        }
                        else {
                            Console.WriteLine("Невалиден номер на поръчка!");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Благодарим Ви, че използвахте нашата програма!");
                        Console.WriteLine("Обобщение на вашето взаимодействие:\n");
                        Console.WriteLine("Поръчки:\n" + string.Join("\n", orders) + "\n");
                        Console.WriteLine("Заявки за помощ: " + string.Join(", ", helpRequests));
                        Console.WriteLine("Заявки за анулиране: " + string.Join(", ", cancelRequests));
                        isLogged = false; 
                        break;

                    default: 
                        Console.WriteLine("Въведете валиден номер на команда!");
                        break;
                }
            }
        }
    }
}