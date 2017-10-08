using System;

namespace Algorithms.CellularAutomata
{
    public class GameOfLife
    {
        public static void Test(int gridSize = 27, double filledPercentage = 0.25)
        {
            var random = new Random();

            var grid = new AutomataGrid(gridSize, gridSize)
                .SetCells(tuple => random.NextDouble() < filledPercentage);

            Console.Write(grid.ToString());

            for (var i = 0; i < 40; i++)
            {
                grid.Advance();
                Console.Write(grid.ToString());
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
