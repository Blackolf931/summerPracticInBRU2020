using System;
using PrincessGame.DLL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldHeight = 20;
            int fieldWidth = 30;

            var gameLauncher = new PrincessGameLauncher();

            var startData = gameLauncher.GetStartData(
                (1, 1),
                (fieldWidth - 2, fieldHeight - 2),
                100,
                fieldHeight,
                fieldWidth);

            Console.ReadKey();
        }
    }
}
