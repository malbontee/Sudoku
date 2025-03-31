using sudoku_project;

public static class FileManager // Менеджер для сохранения/загрузки доски в файл
{
    
    public static void SaveBoard(IBoard board) // Статический метод для сохранения доски
    {
        if (board == null)
        {
            Console.WriteLine("Board is empty. Generate it first.");
            return;
        }

        Console.WriteLine("Select format to save:");
        Console.WriteLine("1. JSON");
        Console.WriteLine("2. TXT");

        string? input = Console.ReadLine();
        Console.Write("Enter filename: ");
        string? filename = Console.ReadLine();

        // Создание папки для JSON + сохранение в данном формате
        if (input == "1")
        {
            Directory.CreateDirectory("boards/json");
            JsonConverter.Save(board.GetBoard(), "boards/json/" + filename + ".json");
            Console.WriteLine("Sudoku saved to JSON file.");
        }
        // Создание папки для TXT + сохранение в данном формате
        else if (input == "2")
        {
            Directory.CreateDirectory("boards/txt");
            var serializer = new TxtSerializer();
            serializer.Save(board, "boards/txt/" + filename + ".txt");
            Console.WriteLine("Sudoku saved to TXT file.");
        }
        else
        {
            Console.WriteLine("Invalid format selected.");
        }
    }

   
    public static void LoadBoard(IBoard board)  // Статический метод для загрузки доски
    {
        Console.WriteLine("Select format to load:");
        Console.WriteLine("1. JSON");
        Console.WriteLine("2. TXT");

        string? input = Console.ReadLine();
        Console.Write("Enter filename (without extension): ");
        string? filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty!");
            return;
        }

        string path = "";

        if (input == "1")
        {
            path = "boards/json/" + filename + ".json";
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found: " + path);
                return;
            }

            int[][] tempBoard = new int[9][];
            JsonConverter.Load(ref tempBoard, path);

            int[][] currentBoard = board.GetBoard();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    currentBoard[i][j] = tempBoard[i][j];
                }
            }

            Console.WriteLine("Sudoku loaded from JSON file.");
        }
        else if (input == "2")
        {
            path = "boards/txt/" + filename + ".txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found: " + path);
                return;
            }

            var serializer = new TxtSerializer();
            serializer.Load(board, path);
            Console.WriteLine("Sudoku loaded from TXT file.");
        }
        else
        {
            Console.WriteLine("Invalid format selected.");
        }

        board.PrintBoard();
    }
}
