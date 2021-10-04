using System;
using System.Threading;

namespace ClickerGameConsoleLine
{
    class Clicker
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            var time = 1000; //miliseconds
            //Points
            var points = 0;
            var totalPoints = 0;
            //Manual Clicker
            var manualClick = 1;
            var manualUpgradeCost = 10;
            var manualUpgradeCostMulitplier = 1.1;
            //Auto Clicker
            var autoClick = 50;
            var autoUpgradeCost = 50;
            var autoUpgradeCostMulitplier = 1.5;

            //Game Opening
            Console.WriteLine("Begin Clicking!");
            Console.WriteLine("Press SPACEBAR to click!");
            Console.WriteLine("Press U for the upgrade menu.");

            //Game
            do
            {
                while (Console.KeyAvailable == false)
                {
                    //Auto Clicker
                    if (autoClick > 0)
                    {
                        points += automaticAdder(time, autoClick);
                        totalPoints += automaticAdder(time, autoClick);
                        Console.Clear();
                        Console.WriteLine($"Points: {points} Total Points: {totalPoints} Points Per Click: {manualClick}");
                    }
                }
                Thread.Sleep(100); // Loop until input is entered.
                Console.Clear();
                cki = Console.ReadKey(true);
                //Manual Clicker
                if (cki.Key == ConsoleKey.Spacebar)
                {
                    points += manualClick;
                    totalPoints += manualClick;
                }
                //Upgrade Menu
                if (cki.Key == ConsoleKey.U)
                {
                    Console.WriteLine("Welcome to the Upgrade Menu!");
                    Console.WriteLine($"Current Points: {points}");
                    Console.WriteLine($"Manual Click Level: {manualClick}  Auto Click Level: {autoClick}");
                    Console.WriteLine($"A - Auto Clicker Upgrade Price {autoUpgradeCost}");
                    Console.WriteLine($"M - Manual Clicker Upgrade Price {manualUpgradeCost}");
                    
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.A && points >= autoUpgradeCost)
                    {
                        points -= autoUpgradeCost;
                        autoClick += 1;
                        autoUpgradeCost = Convert.ToInt32(Math.Ceiling(autoUpgradeCost * autoUpgradeCostMulitplier));
                    }
                    if (cki.Key == ConsoleKey.M && points >= manualUpgradeCost)
                    {
                        points -= manualUpgradeCost;
                        manualClick += 1;
                        manualUpgradeCost = Convert.ToInt32(Math.Ceiling(manualUpgradeCost * manualUpgradeCostMulitplier));
                    }
                    if ((cki.Key == ConsoleKey.A && points < autoUpgradeCost)|| (cki.Key == ConsoleKey.M && points < manualUpgradeCost))
                    {
                        Console.WriteLine("Sorry, not enough points!");
                    }
                }
                //Display
                Console.WriteLine($"Points: {points} Total Points: {totalPoints} Points Per Click: {manualClick}");
            } while (cki.Key != ConsoleKey.Q);

        }
        private static int automaticAdder(int time, int autoClick)
        {  
            Thread.Sleep(time); // Loop until input is entered.
            return autoClick;
        }
    }
}
