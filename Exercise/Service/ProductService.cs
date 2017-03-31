using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Model;
using Exercise.Repository;

namespace Exercise.Service
{
    public class ProductService : IProductRepository
    {
        public List<Product> InitialiseProduct()
        {
            var products = new List<Product>()
            {
                new Lawmower()
                {
                    IdGuid = 1,
                    Brand = "Masport",
                    FuelEfficiency = "Very Effective",
                    IsVehicle = false,
                    Name = "Lawnmower Masport",
                    Price = 120
                },
                new Lawmower()
                {
                    IdGuid = 2,
                    Brand = "Morrison",
                    FuelEfficiency = "Very Effective",
                    IsVehicle = false,
                    Name = "Lawnmower Morrison",
                    Price = 50
                },
                new Lawmower()
                {
                    IdGuid = 3,
                    Brand = "Flymo",
                    FuelEfficiency = "Very Effective",
                    IsVehicle = false,
                    Name = "Lawnmower Flymo",
                    Price = 40
                },

                new Computer()
                {
                    IdGuid = 4,
                    Name = "HP ProBook 450",
                    Price = 450,
                    HardDrive = "1TB",
                    Memory = "16Gb"
                },
                new Computer()
                {
                    IdGuid = 5,
                    HardDrive = "SSD 512Mb",
                    Memory = "16Gb",
                    Name = "Macbook Pro",
                    Price = 3440
                },

                new Car()
                {
                    IdGuid = 6,
                    Year = "2010",
                    Plate = "ABC123",
                    Name = "Honda",
                    Price = 3440
                },
                 new Car()
                {
                    IdGuid = 7,
                    Year = "2013",
                    Plate = "DEF234",
                    Name = "Toyota",
                    Price = 5000
                },
                 new Furniture()
                {
                    IdGuid = 8,
                    Size = "King",
                    Material = "Wooden",
                    Name = "Bed",
                    Price = 500
                },
                new SportsEquipment()
                {
                    IdGuid = 9,
                    Style = "Basic",
                    Color = "Silver",
                    Name = "Running machine",
                    Price = 1000
                },
            };
            return products;

        }
    }

    public class Trolley
    {
        public Product BuyNumber;
        public int BuyQuantity;
        public Trolley(Product BuyNumber, int BuyQuantity)
        {
            this.BuyNumber = BuyNumber;
            this.BuyQuantity = BuyQuantity;
        }
    }
}
