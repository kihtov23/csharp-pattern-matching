using System;
using System.CommandLine.Rendering;
using CSharpPatternMatching.Models;

namespace CSharpPatternMatching
{
    public class Program
    {
        static void Main(
            string region = null,
            string session = null,
            string package = null,
            string project = null,
            string[] args = null)
        {

            switch (region)
            {
                case "firstExample":
                    RunFirstExample();
                    break;
                case "secondExample":
                    RunSecondExample();
                    break;
                case "thirdExample":
                    RunThirdExample();
                    break;
                case "fourthExample":
                    RunFourthExample();
                    break;
                case "fifthRegion":
                    RunFifthExample();
                    break;
            }
        }

        #region firstExample

        public static void RunFirstExample()
        {
            var b = new Bread();
            Console.WriteLine(CalculatePriceFirstExample(b));
        }

        public static int CalculatePriceFirstExample(object product) =>
            product switch
            {
                Bread br => 14,
                Candy c => 10,
                Chocolate ch => 20,
                { } => throw new ArgumentException(message: $"Unknown product {product.GetType()}"),
                null => throw new ArgumentNullException(nameof(product))
            };

        #endregion

        #region secondExample

        public static void RunSecondExample()
        {
            var chocolate = new Chocolate();
            Console.WriteLine(CalculatePriceSecondExample(chocolate));

            var smallChocolate = new Chocolate() { Size = "Small" };
            Console.WriteLine(CalculatePriceSecondExample(smallChocolate));

            var bigChocolate = new Chocolate() { Size = "Big" };
            Console.WriteLine(CalculatePriceSecondExample(bigChocolate));
        }

        public static int CalculatePriceSecondExample(object product) =>
            product switch
            {
                Bread br => 14,
                Candy _ => 10,
                Chocolate { Size: "Small" } => 10,
                Chocolate { Size: "Big" } => 30,
                Chocolate _ => 20,
                { } => throw new ArgumentException(message: $"Unknown product {product.GetType()}"),
                null => throw new ArgumentNullException(nameof(product))
            };

        #endregion

        #region thirdExample

        public static void RunThirdExample()
        {
            var bread = new Bread() { Size = 9 };
            Console.WriteLine(CalculatePriceThirdExample(bread));

            bread.Size = 11;
            Console.WriteLine(CalculatePriceThirdExample(bread));
        }

        public static int CalculatePriceThirdExample(object product) =>
            product switch
            {
                Candy _ => 1,
                Bread b when b.Size < 10 => 5,
                Bread b when b.Size >= 10 => 7,
                { } => throw new ArgumentException(message: $"Unknown product {product.GetType()}"),
                null => throw new ArgumentNullException(nameof(product))
            };

        #endregion

        #region fourthExample

        public static void RunFourthExample()
        {
            var bread = new Bread() { Size = 1 };
            Console.WriteLine(CalculatePriceFourthExample(bread));

            bread.Size = 2;
            Console.WriteLine(CalculatePriceFourthExample(bread));

            bread.Size = 5;
            Console.WriteLine(CalculatePriceFourthExample(bread));
        }

        public static int CalculatePriceFourthExample(object product) =>
            product switch
            {
                Candy _ => 10,
                Bread b => b.Size switch
                {
                    1 => 10,
                    2 => 11,
                    _ => 12
                },
                { } => throw new ArgumentException(message: $"Unknown product {product.GetType()}"),
                null => throw new ArgumentNullException(nameof(product))
            };

        #endregion

        #region fifthRegion

        public static void RunFifthExample()
        {
            var bread = new Bread() { ShopName = "ShopABC", ShopCity = "CityC" };
            Console.WriteLine(GetDiscount(bread.ShopName, bread.ShopCity));
        }

        public static int GetDiscount(string shopName, string city) =>
            (IsRetailSales(shopName), GetRegion(city)) switch
            {
                (true, "AbRegion") => 10,
                (false, "CbRegion") => 23,
                (_, _) => 45
            };

        public static bool IsRetailSales(string shopName) =>
            shopName switch
            {
                "ShopA" => true,
                "ShopB" => true,
                null => throw new ArgumentNullException(),
                _ => false,
            };

        public static string GetRegion(string city) =>
        city switch
        {
            "CityA" => "AbRegion",
            "CityB" => "AbRegion",
            "CityC" => "CbRegion",
            _ => "EtcRegion"
        };

        #endregion
    }
}