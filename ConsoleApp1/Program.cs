using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{

    public class GoldenDaricCalculator
    {
        static void Main(string[] args)
        {
            //Lowest price for which you can buy Golden Talents from the Trade Broker.
            Console.Write("Price for Golden Talent: ");
            double goldenTalent_Price = Convert.ToDouble(Console.ReadLine());

            //Lowest price for which you can buy an Aged Elinu's Tear from the Trade Broker. This value
            //significantly lowers the profit and should generally be set to 0 unless you are actively
            //buying Elinu's Tears to restore your production points.
            Console.Write("Price for Aged Elinu's Tear: ");
            double productionPoint_Price = Convert.ToDouble(Console.ReadLine());

            //Lowest price for your end product.
            Console.Write("Minimum Price for Golden Daric: ");
            double goldenDaric_Price = Convert.ToDouble(Console.ReadLine());

            //Debug outputs.
                //Console.WriteLine(goldenTalent_Price.ToString());
                //Console.WriteLine(productionPoint_Price.ToString());
                //Console.WriteLine(goldenDaric_Price.ToString());

            //Calculates the gold value of one single production point if bought from the trade broker.
            double singlePP_Price = productionPoint_Price / 4000;

            //Subtracts the 1% Trade Broker fee from the price.
            goldenDaric_Price = goldenDaric_Price - 0.01 * goldenDaric_Price;
            //Console.WriteLine(goldenDaric_Price);

            //Craft Kits cost a constant 1 gold and 6 silver.
            const double craftKit_Price = 1.06;

            //Sale value of the end product minus the ingredients (and production points value) = profit.
            var profit = 3 * goldenDaric_Price - 5 * goldenTalent_Price - 60 * craftKit_Price - 20 * singlePP_Price;

            //The designer jumped out.
            if (profit >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You gain " + profit + " gold per produce.");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose " + profit * -1 + " gold per produce.");
                }
        }
    }
}
