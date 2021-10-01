﻿using System;
using System.Threading;

namespace ClickerGameConsoleLine
{
    class ClickerFactory
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            var points = 0;
            var totalPoints = 0;
            var manualClick = 1;
            var manualUpgradeCost = 10;
            var manualUpgradeCostMulitplier = 1.1;


            //Game Opening
            Console.WriteLine("Begin Clicking!");

            //Game
            do
            {

                while (Console.KeyAvailable == false)
                    Thread.Sleep(100); // Loop until input is entered.
                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Spacebar)
                {
                    points += manualClick;
                    totalPoints += manualClick;
                }

                if (cki.Key == ConsoleKey.U && points >= manualUpgradeCost)
                {
                    points -= manualUpgradeCost;
                    manualClick += 1;
                    manualUpgradeCost = Convert.ToInt32(Math.Ceiling(manualUpgradeCost * manualUpgradeCostMulitplier));
                }
       
                Console.WriteLine($"Points: {points} Total Points: {totalPoints} Points Per Click: {manualClick} Upgrade Cost: {manualUpgradeCost}");
            } while (cki.Key != ConsoleKey.Q);

        }
    }
}