using Stamina.Menu;
using Stamina.SecondMenu;
using Stamina.Texts;
using System.Data;
using System.Diagnostics;

namespace Stamina.Main
{
    public class Main
    {
        public static List<Text> lstOfText = new();
        Stopwatch stopwatch = new();
        MainMenu menu = new MainMenu();
        SecondMenus secondMenus = new SecondMenus();

        int score;
        int mistakes;
        int speedOfWrite;
        int endTime;
        int choosePlayer;

        public Main()
        {
            lstOfText.Add(new Text("ва ол", "BAOL.txt"));
            lstOfText.Add(new Text("фы дж", "ФЫДЖ.txt"));
            lstOfText.Add(new Text("ми ть", "Mi.txt"));
            lstOfText.Add(new Text("еп нр", "EP.txt"));
            lstOfText.Add(new Text("ук гш", "YK.txt"));
            lstOfText.Add(new Text("чс бю", "ЧС.txt"));
            lstOfText.Add(new Text("йц щз", "ЙЦ.txt"));
            lstOfText.Add(new Text("я зхъ", "Я.txt"));
            lstOfText.Add(new Text("короткие слова", "корслова.txt"));
            lstOfText.Add(new Text("длинные слова", "длинслова.txt"));
            lstOfText.Add(new Text("экзамен", "экзамен.txt"));
        }
        public void Start()
        {
            while (true)
            {
                choosePlayer = menu.Start();
                if (choosePlayer == 0)
                {
                    choosePlayer = secondMenus.Start();
                    for(int i = 0; i < lstOfText.Count; i++)
                    {
                        if(choosePlayer == i)
                        {
                            choosePlayer = 0;
                            stopwatch.Start();
                            (score, mistakes) = lstOfText[i].Start(End);
                        }
                    }
                    if(choosePlayer == lstOfText.Count)
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
            speedOfWrite = score / endTime;
            Console.WriteLine("ваш результат: " + speedOfWrite + " букв в мин");
            Console.WriteLine("количество ошибок: " + mistakes);
            Console.WriteLine("\n\n\n нажмите enter чтобы продолжить");
            Console.ReadLine();
        }
        
    }
}