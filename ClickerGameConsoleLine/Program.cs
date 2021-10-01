using System;
using System.Threading;

namespace ClickerGameConsoleLine
{
    class ClickerFactory
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
            var autoClick = 0;
            var autoUpgradeCost = 50;
            var autoUpgradeCostMulitplier = 1.5;


            //Game Opening
            Console.WriteLine("Begin Clicking!");

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
                        Console.WriteLine($"Points: {points} Total Points: {totalPoints} Points Per Click: {manualClick} Upgrade Cost: {manualUpgradeCost}");
                    }
                }
                Thread.Sleep(100); // Loop until input is entered.
                cki = Console.ReadKey(true);
                //Manual Clicker
                if (cki.Key == ConsoleKey.Spacebar)
                {
                    points += manualClick;
                    totalPoints += manualClick;
                }
                //Upgrade
                if (cki.Key == ConsoleKey.U && points >= manualUpgradeCost)
                {
                    points -= manualUpgradeCost;
                    manualClick += 1;
                    manualUpgradeCost = Convert.ToInt32(Math.Ceiling(manualUpgradeCost * manualUpgradeCostMulitplier));
                }
                //Display
                Console.WriteLine($"Points: {points} Total Points: {totalPoints} Points Per Click: {manualClick} Upgrade Cost: {manualUpgradeCost}");
            } while (cki.Key != ConsoleKey.Q);

        }

        private static int automaticAdder(int time, int autoClick)
        {  
            Thread.Sleep(time); // Loop until input is entered.
            return autoClick;
        }
    }
}
