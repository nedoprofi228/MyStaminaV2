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
        string сWords = "3. ми ть";
        string вWords = "4. еп нр";
        string eWords = "5. ук гш";
        string fWords = "6. чс бю";
        string gWords = "7. йц щз";
        string YaWords = "8. я зхъ";
        string shortWords = "9. короткие слова";
        string longWords = "10. длинные слова";
        string examsWords = "11. экзамен";
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
