using System.Diagnostics;
using System.Reflection.Metadata;
using System.IO;
using System.Globalization;

namespace Stamina.Texts
 {
    public class Text
    {
        public string text;
        public int score = 0;
        public int mistakes = 0;

        public string name;
        public string fileName;

        public char? user;
        bool end = false;

        public Text(string name, string fileName){
            this.name = name;
            this.fileName = fileName;
            ReadTextFromFile();
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
        public (int, int) Start(EndFunc End)
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
            return (score, mistakes);
        }
        void ReadTextFromFile()
        {
            string path = Directory.GetCurrentDirectory() + "\\texts\\" + fileName;
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