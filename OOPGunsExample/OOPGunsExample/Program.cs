using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGunsExample
{
    class Program
    {
        private static readonly Random _random = new Random();

        static void Main(string[] args)
        {

            // Inheritance Hunting

            Console.WriteLine("Welcome to Inheritance Hunting!");
            Console.WriteLine("-----------------");
            Console.WriteLine("Select a rifle:");
            Console.WriteLine("1. Vanguard Synthetic");
            Console.WriteLine("2. Vanguard MeatEater");
            string riflePicked = Console.ReadLine();
            UOM caliberOnRifle = new UOM();
            int gunCapacity = 0;
            if (riflePicked == "1")
            {
                VanguardSynthetic vs1 = new VanguardSynthetic();
                vs1.myUOM = setRandomCaliber();
                caliberOnRifle = vs1.myUOM;
                Console.WriteLine("Rifle caliber is: " + vs1.myUOM.Caliber);
                vs1.capacity = 3; // PA state law
                gunCapacity = vs1.capacity;
            } else if (riflePicked == "2")
            {
                VanguardMeatEater vme1 = new VanguardMeatEater();
                vme1.myUOM = setRandomCaliber();
                caliberOnRifle = vme1.myUOM;
                Console.WriteLine("Rifle caliber is: " + vme1.myUOM.Caliber);

                vme1.capacity = 3; // PA state law
                gunCapacity = vme1.capacity;
            }


            double shotsFired = 0;
            double targetsHit = 0;
            double targetsKilled = 0;
            while (shotsFired < gunCapacity)
            {
            Console.WriteLine("A new target appears!");
                GameTarget gt = new GameTarget();
                gt = getNewRandomGameTarget();

                Console.WriteLine("Do you want to take a shot? (y/n)");

                     string response = Console.ReadLine();

                        if (response == "y")
                        {
                    Console.WriteLine("Target's caliber is: " + gt.targetUOM.Caliber);

                    shotsFired++;
                            if (gt.targetUOM.Caliber == caliberOnRifle.Caliber )
                    {
                        Console.WriteLine("Good kill!");
                        targetsHit++;
                        targetsKilled++;

                    } else
                    {
                        // we shot at it, but wasn't right caliber
                        //TODO: Play with caliber combinations / scoring

                        if ((gt.targetUOM.CaliberGroup == Group.Long) && (caliberOnRifle.CaliberGroup == Group.Short))
                        {
                            // get nothing, shot is fired
                            Console.WriteLine("Complete miss!");
                        }
                        if ((gt.targetUOM.CaliberGroup == Group.Short) && (caliberOnRifle.CaliberGroup == Group.Long))
                        {
                            Console.WriteLine("Target wounded!");
                            targetsHit++;

                        }

                    }
                        } else if (response == "n") {
                    continue;
                        } else
                        {
                    continue;
                }

            }
            Console.WriteLine("OK the game is over! Final Results:");
            //TODO: Play with score

            Console.WriteLine("Your Score: " + ((targetsKilled + (targetsHit*.5))  / gunCapacity));
            Console.ReadLine();
        
        }
        public static GameTarget getNewRandomGameTarget()
        {
            GameTarget newRandomGameTarget = new GameTarget();
            newRandomGameTarget.targetUOM = setRandomCaliber();
            return newRandomGameTarget;

        }
        public static UOM setRandomCaliber()
        {
            UOM newUOM = new UOM();
            string[] caliber = new string[5];
            caliber[0] = "22-250 Rem.";
            caliber[1] = "243 Win.";
            caliber[2] = "308 Win.";
            caliber[3] = "300 Win. Mag";
            caliber[4] = "7mm Rem. Mag";

            int randomN = RandomNumber(0, 4);
            newUOM.Caliber = caliber[randomN];

            switch (randomN) {
                case 0:
                    newUOM.CaliberGroup = Group.Short;
                    break;
                case 1:
                    newUOM.CaliberGroup = Group.Medium;
                    break;
                case 2:
                    newUOM.CaliberGroup = Group.Long;
                    break;
                case 3:
                    newUOM.CaliberGroup = Group.Long;
                    break;
                case 4:
                    newUOM.CaliberGroup = Group.Long;
                    break;
            }

            return newUOM;
        }
        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
