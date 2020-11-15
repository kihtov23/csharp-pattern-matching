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

            var smallChocolate = new Chocolate(){Size = "Small"};
            Console.WriteLine(CalculatePriceSecondExample(smallChocolate));

            var bigChocolate = new Chocolate(){Size = "Big" };
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
            var bread = new Bread() {Size = 9};
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
    }
}