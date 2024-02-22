using System.Diagnostics;
using System.Reflection.Metadata;
using System.IO;

namespace Stamina.Texts
 {
    public class Text
    {
        public string text;
        public int score = 0;
        public int mistakes = 0;

        

        string BAOLText = "BAOL.txt";
        string FDText = "ФЫДЖ.txt";
        string shortWords = "корслова.txt";
        string longWords = "длинслова.txt";
        string miWords = "Mi.txt";
        string EpWords = "EP.txt";
        string YKWords = "YK.txt";
        string ZWords = "ЙЦ.txt";
        string CHWords = "ЧС.txt";
        string YAWords = "Я.txt";
        string ExamsWords = "экзамен.txt";

        public char? user;
        bool end = false;
        public Text(){
            ReadTextFromFile(0);
        }
        public Text(int vars){
            ReadTextFromFile(vars);
        }
        public bool ChecksymvolAndEnd(char? key){
            if (text.Length <= 0){
                return true;
            }
            else if (text[0] == key && text.Length > 0){
                text = text.Substring(1);
                score += 1;
            }
            else{ mistakes += 1; }
            return false;
        }
        public void ShowText(){
            if (text.Length < 9)
                text.ShowBeautifullStr();
            else 
            {
                text.Substring(0, 9).ShowBeautifullStr();
            }
        }
        public void CheckSpacebar(){
            if(text[0] == ' '){
               text = text.Substring(1); 
            }
        }
        public int Start(EndFunc End)
        {
            Console.Clear();
            ShowText();
            while (true)
            {
                user = Console.ReadKey().KeyChar;
                if (end)
                {
                    End();
                    break;
                }
                else if (user is not null)
                {
                    Console.Clear();
                    end = ChecksymvolAndEnd(user);
                    ShowText();
                    user = null;
                }
                else if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    CheckSpacebar();
                }
            }
            return 0;
        }
        void ReadTextFromFile(int vars)
        {
            string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 16) + "\\texts\\";
            switch (vars)
            {
                case 0:
                    path += BAOLText;
                    break;
                case 1:
                    path += FDText;
                    break;
                case 2:
                    path += miWords;
                    break;
                case 3:
                    path += EpWords;
                    break;
                case 4:
                    path += YKWords;
                    break;
                case 5:
                    path += CHWords;
                    break;
                case 6:
                    path += ZWords;
                    break;
                case 7:
                    path += YAWords;
                    break;
                case 8:
                    path += shortWords;
                    break;
                case 9:
                    path += longWords;
                    break;
            }
            using (StreamReader reader = new StreamReader(path))
            {
                this.text = reader.ReadToEnd();
            }
        }
        public delegate void EndFunc();
    }
    public static class StringExtensions
    {
        public static void ShowBeautifullStr(this string str)
        {
            string upperS =     "|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|";
            string middleS = "|-------------------------------------------|";
            Console.WriteLine(upperS + upperS + upperS);
            Console.Write(middleS);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(str);
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine(middleS);
            Console.WriteLine(upperS + upperS + upperS);
         // res = upperS + upperS + upperS + "\n" + middleS + str + middleS + "\n" + upperS + upperS + upperS;
        }
    }
 }