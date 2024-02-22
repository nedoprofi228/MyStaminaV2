using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stamina.SecondMenu
{
    internal class SecondMenus
    {
        string startText = "Выберите режим";
        string aWords = "1. ва ол";
        string bWords = "2. фы дж";
        string bWords = "3. фы дж";
        string bWords = "2. фы дж";
        string bWords = "2. фы дж";
        string bWords = "2. фы дж";
        string bWords = "2. фы дж";
        string exitText = "назад";

        bool end = false;
        int user = 0;

        ConsoleKey? userKey;

        void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine(startText);
            if (user == 0)
            {
                ChooseVar("=> " + aWords);
            }
            else
            {
                Console.WriteLine(aWords);
            }
            if (user == 1)
            {
                ChooseVar("=> " + bWords);
            }
            else
            {
                Console.WriteLine(bWords);
            }
            if (user == 2)
            {
                ChooseVar("=> " + exitText);
            }
            else
            {
                Console.WriteLine(exitText);
            }
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
                if (user < 2)
                    user++;
            }
            if (key == ConsoleKey.Enter)
                end = true;
        }
    }
}
