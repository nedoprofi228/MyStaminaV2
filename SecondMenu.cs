using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stamina.Main.Main;

namespace Stamina.SecondMenu
{
    internal class SecondMenus
    {
        string startText = "Выберите режим";
        string exitText = "назад";

        bool end = false;
        int user = 0;

        ConsoleKey? userKey;

        void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine(startText);
            for(int i = 0; i < lstOfText.Count; i++)
            {
                if (i == user)
                    ChooseVar($"=> {lstOfText[i].name}");
                else
                    Console.WriteLine(lstOfText[i].name);
            }
            if (user == lstOfText.Count)
                ChooseVar(exitText);
            else
                Console.WriteLine(exitText);
        }
        void ChooseVar(string text)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public int Start()
        {
            DrawMenu();
            while (true)
            {
                userKey = Console.ReadKey().Key;
                if (userKey is not null)
                {
                    CheckKey(userKey);
                    DrawMenu();
                }
                if (end)
                    break;
            }
            return user;
        }
        void CheckKey(ConsoleKey? key)
        {
            end = false;
            if (key == ConsoleKey.W)
            {
                if (user > 0)
                    user--;
            }
            if (key == ConsoleKey.S)
            {
                if (user < lstOfText.Count)
                    user++;
            }
            if (key == ConsoleKey.Enter)
                end = true;
        }
    }
}
