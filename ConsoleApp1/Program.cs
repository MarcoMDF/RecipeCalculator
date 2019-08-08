using System;

namespace RecipeCalculator
{

    public class GoldenDaricCalculator
    {
        static void Main(string[] args)
        {
            //Lowest price for which you can buy Golden Talents from the Trade Broker.
            Console.WriteLine(">Price for Golden Talent: ");
            double goldenTalent_Price = Convert.ToDouble(Console.ReadLine());

            //Lowest price for which you can buy an Aged Elinu's Tear from the Trade Broker. This value
            //significantly lowers the profit and should generally be set to 0 unless you are actively
            //buying Elinu's Tears to restore your production points.
            Console.WriteLine(">Price for Aged Elinu's Tear: ");
            double productionPoint_Price = Convert.ToDouble(Console.ReadLine());

            //Lowest price for your end product.
            Console.WriteLine(">Minimum Price for Golden Daric: ");
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
                Console.WriteLine(">You gain " + profit + " gold per produce.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">You lose " + profit * -1 + " gold per produce.");
            }

            //Material calculator. You enter your materials for this recipe and get told which ones you need to stock up on and how many.
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine(">If you would like to proceed with the material calculator type 'Yes' and hit enter. ");
            Console.ForegroundColor = ConsoleColor.White;
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {

                Console.WriteLine(">How many Golden Talents do you have? ");
                double materialA = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine(">How many Craft Kits do you have? ");
                double materialB = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine(">How many Production points do you have? ");
                double materialC = Convert.ToDouble(Console.ReadLine());

                /* My goal here is to find out which material the player has most of relative to the recipe ratios.
                 * 
                 * The ratios are as followed:
                 * Material A (Golden Talent) 5
                 * Material B (Craft Kits) 60
                 * Material C (Production Points) 20
                 * 
                 * Following that, I divide each number by the number needed for to craft one produce (5, 60 and 20).
                 * Whichever value ends up being the highest is now the goal for the other materials to be stocked up to.
                 * For example: Player has enough mats C to craft 60 produce. Mats A and B will subsequently be stocked up to get to 60.
                 */

                //Aux is short for auxiliary calculation don't sue me
                double auxA = materialA / 5;
                double auxB = materialB / 60;
                double auxC = materialC / 20;

                //Rounding down to assure even numbers and that the highest number of mats does not need increasing. 
                //This might cause you to have leftovers of the material that you have most of.
                //Yes, this is messy but sue me.
                int auxARounded = Convert.ToInt32(auxA);
                int auxBRounded = Convert.ToInt32(auxB);
                int auxCRounded = Convert.ToInt32(auxC);

                //This next part is an overcomplicated way of finding out which rounded number is the highest

                if (auxARounded > auxBRounded & auxARounded > auxCRounded)
                {
                    //Calculating the need of material B; Max amount of produce according to material A being the highest quantitative standard
                    //minus the material B's you already have = the material B's you still need.
                    double materialBNeed = Convert.ToDouble(auxARounded) * 60 - materialB;
                    double materialCNeed = Convert.ToDouble(auxARounded) * 20 - materialC;
                    Console.WriteLine(">You need to buy a total of " + materialBNeed + " Craft Kits and " + materialCNeed + " production points.");
                }
                else if (auxBRounded > auxARounded & auxBRounded > auxCRounded)
                {
                    double materialANeed = Convert.ToDouble(auxBRounded) * 5 - materialA;
                    double materialCNeed = Convert.ToDouble(auxBRounded) * 20 - materialC;
                    Console.WriteLine(">You need to buy a total of " + materialANeed + " Golden Talents and " + materialCNeed + " production points.");
                }
                else if (auxCRounded > auxARounded & auxCRounded > auxBRounded)
                {
                    double materialANeed = Convert.ToDouble(auxCRounded) * 5 - materialA;
                    double materialBNeed = Convert.ToDouble(auxCRounded) * 60 - materialB;
                    Console.WriteLine(">You need to buy a total of " + materialANeed + " Golden Talents and " + materialBNeed + " Craft Kits.");
                }
                //---*--- RARE-ish EXCEPTIONS ---*---
                //All of them can produce the same amount of produce or there is no produce that can be crafted
                else if (auxARounded.Equals(auxBRounded & auxCRounded))
                {
                    Console.WriteLine(">You either already have the perfect amount of materials or not enough of all of them. Stock up on one of them and retry!");
                }
                //A equals B and both are bigger than C
                else if (auxARounded.Equals(auxBRounded) & auxARounded > auxCRounded)
                {
                    double materialCNeed = Convert.ToDouble(auxARounded) * 20 - materialC;
                    Console.WriteLine(">You are missing " + materialCNeed + " production points. Consider buying an Elinu's Tear potion from the Trade Broker or Vanguard Special Rewards Vendor.");
                }
                //A equals C and both are bigger than B
                else if (auxARounded.Equals(auxCRounded) & auxARounded > auxBRounded)
                {
                    double materialBNeed = Convert.ToDouble(auxARounded) * 60 - materialB;
                    Console.WriteLine(">You are missing " + materialBNeed + " Craft Kits.");
                }
                //B equals C and both are bigger than A
                else if (auxBRounded.Equals(auxCRounded) & auxBRounded > auxARounded)
                {
                    double materialANeed = Convert.ToDouble(auxARounded) * 5 - materialA;
                    Console.WriteLine(">You are missing " + materialANeed + " Golden Talents.");
                }
            }
            else
            {
                return;
            }
        }
    }
}
