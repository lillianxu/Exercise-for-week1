using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Model;
using Exercise.Service;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();
            var products = productService.InitialiseProduct();
            Console.WriteLine("List of all products in system");
            foreach (var p in products)
            {
                Console.WriteLine("Product number: {0}", p.IdGuid);
                Console.WriteLine("Product name: {0}", p.Name);
                Console.WriteLine("Product price: {0}", p.Price);
                Console.WriteLine("----------------------");
            }

            //continue to buy loop
            decimal Total=0;

            // shopping cart
            List<Trolley> list = new List<Trolley>();

            //continue shopping loop
            bool BuyFlag = true;
            while(BuyFlag) { 
                Console.WriteLine("Please enter product number you want to purchase");
                //Convert product id to integer
                var productId = Convert.ToInt32(Console.ReadLine());
                //Check if product id valid 
                //Use foreach to go through all product list
                foreach (var pr in products)
                {
                    if (pr.IdGuid == productId)
                    {
                        var productType = pr.GetType();
                        Console.WriteLine("We found 1 product in our system");
                        switch (productType.Name)
                        {
                            case "Lawnmower":
                                {
                                    var lawMower = (Lawmower)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product brand: {0}", lawMower.Brand);
                                    Console.WriteLine("Product fuel efficiency: {0}", lawMower.FuelEfficiency);
                                    Console.WriteLine("----------------------");
                                    break;
                                }
                            case "Computer":
                                {
                                    var lawMower = (Computer)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product memory: {0}", lawMower.Memory);
                                    Console.WriteLine("Product hard drive: {0}", lawMower.HardDrive);
                                    Console.WriteLine("----------------------");
                                    break;
                                }
                            case "Car":
                                {
                                    var lawMower = (Car)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product year: {0}", lawMower.Year);
                                    Console.WriteLine("Product plate: {0}", lawMower.Plate);
                                    Console.WriteLine("----------------------");
                                    break;
                                }
                            case "Furniture":
                                {
                                    var lawMower = (Furniture)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product size: {0}", lawMower.Size);
                                    Console.WriteLine("Product material: {0}", lawMower.Material);
                                    Console.WriteLine("----------------------");
                                    break;
                                }

                            case "SportsEquipment":
                                {
                                    var lawMower = (SportsEquipment)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product style: {0}", lawMower.Style);
                                    Console.WriteLine("Product color: {0}", lawMower.Color);
                                    Console.WriteLine("----------------------");
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        //Allow users to enter a quantity when they make a purchase
                        Console.WriteLine("Please input the quantity.");
                        int Quantity = Convert.ToInt32(Console.ReadLine());
                        Total += pr.Price * Quantity;

                        bool SameItemFlag = true;
                        for (int i = 0; i < list.Count; i++)
                        {
                            //Add logic so if they make multiple purchases of the same item the shopping cart is updated
                            Trolley temp = list[i];
                            if (pr.IdGuid == temp.BuyNumber.IdGuid)
                            {
                                temp.BuyQuantity += Quantity;
                                SameItemFlag = false;
                                break;
                            }

                        }

                        //add to cart
                        if (SameItemFlag)
                            list.Add(new Trolley(pr, Quantity));



                        Console.WriteLine("Would you like to pay for this product. Press Y to continue,Press any key to continue shopping");
                        string option = Console.ReadLine();
                        if (option == "Y" || option == "y")
                        {
                            BuyFlag = false;
                            Console.WriteLine("Total to pay: ${0}", Total);

                            //Add a checkout option which prints a receipt with a summary of the users purchase(s).
                            Console.WriteLine("Would you like to prints a receipt.Press Y to print.");
                            string PrintOption = Console.ReadLine();
                             if (PrintOption == "Y" || PrintOption == "y")
                            {
                                Console.WriteLine("-------------Receipt-----------");
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Trolley temp = list[i];
                                    Console.WriteLine("Product number: {0}", temp.BuyNumber.IdGuid);
                                    Console.WriteLine("Product name: {0}", temp.BuyNumber.Name);
                                    Console.WriteLine("Product price: {0}", temp.BuyNumber.Price);
                                    Console.WriteLine("Product Quantity: {0}", temp.BuyQuantity);
                                    Console.WriteLine("---------------------------------------");
                                }

                                Console.WriteLine("Total price:" + Total);
                            }
                                Console.WriteLine("Thank you for shopping with us. Bye bye");
                        }
                        //else
                        //{
                        //    Console.WriteLine("Thank you for shopping with us. Bye bye");
                        //}
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
