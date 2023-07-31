using PharmacyCompany.Commands;
using PharmacyCompany.Database;
using PharmacyCompany.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace PharmacyCompany
{
    internal class Program
    {
        private static DbInteraction _dbInteraction;

        static void Main(string[] args)
        {
            try
            {
                if (args.Length >= 1)
                {
                    string[] trimedArgs = args.Select(x => x.Trim()).ToArray();

                    string firstOption = trimedArgs[0];
                    var remainingArgs = trimedArgs.Skip(1).ToArray();

                    SqlConnectionStringBuilder dbConnectionStringBuilder = new SqlConnectionStringBuilder
                    {
                        UserID = "sa",
                        Password = "1234",
                        InitialCatalog = "PharmacyCompany",
                        DataSource = "WINDOWS-LAPTOP\\SQLEXPRESS"
                    };

                    _dbInteraction = new MsSqlDbInteraction(dbConnectionStringBuilder.ToString());

                    HandleArguments(firstOption, remainingArgs);
                }
                else
                {
                    PrintHelp();
                }
            }
            catch(Exception ex)
            {
                PrintHelp();
            }
        }

        static void HandleArguments(string firstOption, string[] remainingArgs)
        {
            string firstOptionInLowerCase = firstOption.ToLower();

            if(!string.IsNullOrEmpty(firstOptionInLowerCase)|| !remainingArgs.Any()) 
            {
                CommandBase command = null;

                switch (firstOptionInLowerCase) 
                {
                    case "--help":
                        PrintHelp();
                        return;
                    case "--addproduct":
                        command = new AddProduct(_dbInteraction, remainingArgs);
                        break;
                    case "--addpharmacy":
                        command = new AddPharmacy(_dbInteraction, remainingArgs);
                        break;
                    case "--addwarehouse":
                        command = new AddWarehouse(_dbInteraction, remainingArgs);
                        break;
                    case "--addconsignment":
                        command = new AddConsignment(_dbInteraction, remainingArgs);
                        break;
                    case "--removeproduct":
                        command = new RemoveProduct(_dbInteraction, remainingArgs);
                        break;
                    case "--removepharmacy":
                        command = new RemovePharmacy(_dbInteraction, remainingArgs);
                        break;
                    case "--removewarehouse":
                        command = new RemoveWarehouse(_dbInteraction, remainingArgs);
                        break;
                    case "--removeconsignment":
                        command = new RemoveConsignment(_dbInteraction, remainingArgs);
                        break;
                    case "--list":
                        command = new GetAllProductsFromPharm(_dbInteraction, remainingArgs);
                        break;
                    default:
                        PrintHelp();
                        return;
                }

                if (command != null)
                {
                    bool success = command.Execute();

                    if(command is GetAllProductsFromPharm allProductsFromPharm)
                    {
                        PrintProductsWithQuantity(allProductsFromPharm.Result);
                    }
                    else
                    {
                        Console.WriteLine($"Итог операции: {(success ? "Успешно" : "Неудачно")}\n");
                    }
                }
            }
        }

        static void PrintProductsWithQuantity(List<(Product, int)> productsAndQuantity)
        {
            foreach(var res in productsAndQuantity)
            {
                Product product = res.Item1;
                int quantity = res.Item2;

                Console.WriteLine($"id = {( product.Id == null ? "null" : product.Id.ToString() )} | Title = {product.Title} | {quantity}");
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine($"Каждой из этих команд будет соответствовать соответствующая операция: --addproduct|--addpharmacy|--addwarehouse|--addconsignment|--removeproduct|--removepharmacy|--removewarehouse|--removeconsignment\n" +
                $"Флаги для товара: --title\n" +
                $"Флаги для апетек: --title, --address, --phone\n" +
                $"Флаги для складов: --title, --pharmacyId\n" +
                $"Флаги для партий: --warehouseId, --productId, --quantity\n" +
                $"Для удаления используется только флаг --id\n" +
                $"Есть команда --list, для отображения всех товаров по аптеке. Используется с флагом --id\n\n" +
                $"Примеры:\n" +
                $"PharmacyCompany.exe --addproduct --title test\n" +
                $"PharmacyCompany.exe --list --id 1");
        }
    }
}
