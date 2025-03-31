namespace sudoku_project
{
    using System;
    public enum Theme
    {
        Light,
        Dark,
        Grey,
        DustyBlue,
        Lavender
    }

    public static class ThemeSelector 
    {
        public static Theme ChooseTheme()
        {
            Console.CursorVisible = false;  // Скрытие курсора
            Console.WriteLine("Choose a theme:");
            Console.WriteLine("1. Light");
            Console.WriteLine("2. Dark");
            Console.WriteLine("3. Grey");
            Console.WriteLine("4. Blue");
            Console.WriteLine("5. Lavender");
            

            string input = Console.ReadLine();
            return input switch
            {
                "1" => Theme.Light,
                "2" => Theme.Dark,
                "3" => Theme.Grey,
                "4" => Theme.DustyBlue,
                "5" => Theme.Lavender,
                _ => Theme.Dark,
            };
        }

        public static void ApplyTheme(Theme theme)
        {
            
            switch (theme)
            {
                case Theme.Light:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Theme.Dark:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Theme.Grey:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Theme.DustyBlue:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case Theme.Lavender:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
               
            }
        Console.Clear();

        } 
    }
}
