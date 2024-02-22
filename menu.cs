using Stamina.Main;

namespace Stamina.Menu
{
    public class MainMenu()
    {
        string startText = "Добро пожаловать в стамину!";
        string ChooseVarOfText = "Выбрать режим";
        string settingsText = "Настройки";
        string exitText = "exit";

        bool end = false;
        int user = 0;

        ConsoleKey? userKey;

        void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine(startText);
            if (user == 0)
            {
                ChooseVar("=> " + ChooseVarOfText);
            }
            else
            {
                Console.WriteLine(ChooseVarOfText);
            }
            if (user == 1)
            {
                ChooseVar("=> " + settingsText);
            }
            else
            {
                Console.WriteLine(settingsText);
            }
            if(user == 2)
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
                    end = false;
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
            if (key == ConsoleKey.W)
            {
                if(user > 0)
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