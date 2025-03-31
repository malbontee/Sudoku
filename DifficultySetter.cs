namespace sudoku_project
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public static class DifficultySetter
    {

        // Выбор сложности игры
        internal static Difficulty AskDifficulty()
        {
            Console.WriteLine("Choose difficulty: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            while (true)
            {
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": return Difficulty.Easy;
                    case "2": return Difficulty.Medium;
                    case "3": return Difficulty.Hard;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2 or 3.");
                        break;
                }
            }
        }
    }
}