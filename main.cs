using Stamina.Menu;
using Stamina.SecondMenu;
using Stamina.Texts;
using System.Data;
using System.Diagnostics;

namespace Stamina.Main
{
    public class Main
    {
        Text text;
        Stopwatch stopwatch = new();
        MainMenu menu = new MainMenu();
        SecondMenus secondMenus = new SecondMenus();

        int speedOfWrite;
        int endTime = new();
        int choosePlayer;
        public void Start()
        {
            while (true)
            {
                choosePlayer = menu.Start();
                if (choosePlayer == 0)
                {
                    choosePlayer = secondMenus.Start();
                    if (choosePlayer == 0)
                    {
                        text = new Text(choosePlayer);
                        stopwatch.Start();
                        text.Start(End);
                        choosePlayer = 0;
                    }
                    else if (choosePlayer == 1)
                    {
                        text = new Text(choosePlayer);
                        stopwatch.Start();
                        text.Start(End);
                        choosePlayer = 0;
                    }
                    else if(choosePlayer == 2)
                    {
                        choosePlayer = 0;
                        continue;
                    }
                }
                if (choosePlayer == 1)
                    Console.WriteLine("пока здесь ничего нет");
                if (choosePlayer == 2)
                {
                    break;
                }
            }
        }
        public void End(){
            stopwatch.Stop();
            endTime = (int)(stopwatch.ElapsedMilliseconds / 6000);
            Console.Clear();
            Console.WriteLine("вы написали весь текст!");
            speedOfWrite = text.score / endTime;
            Console.WriteLine("ваш результат: " + speedOfWrite + " букв в мин");
            Console.WriteLine("количество ошибок: " + text.mistakes);
            Console.WriteLine("\n\n\n нажмите enter чтобы продолжить");
            Console.ReadLine();
        }
        
    }
}