namespace sudoku_project
{
    public class SudokuMenu : IMenu
    {
        private IBoard board;
        private ISolver solver;

        public SudokuMenu(ISolver solver)
        {
            this.solver = solver;
            board = null;
        }

        // Главное меню
        public void ShowMenu()
        {
            Console.CursorVisible = false;  // Скрытие курсора
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|         SUDOKU MENU         |");
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("| 1. Generate New Sudoku      |");
                Console.WriteLine("| 2. Auto-Solve Sudoku        |");
                Console.WriteLine("| 3. Manual Input (Fill Cells)|");
                Console.WriteLine("| 4. Save Sudoku to File      |");
                Console.WriteLine("| 5. Load Sudoku from File    |");
                Console.WriteLine("| 6. Print Sudoku             |");
                Console.WriteLine("| 7. Undo Last Move           |");
                Console.WriteLine("| 8. Exit                     |");
                Console.WriteLine("+-----------------------------+");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Difficulty difficulty = DifficultySetter.AskDifficulty();
                        var generator = new SudokuGenerator(difficulty);
                        board = generator.Generate(); // Генерация нового судоку
                        Console.WriteLine($"New {difficulty} Sudoku generated.");
                        board.PrintBoard();
                        break;

                    case "2":
                        if (board == null)
                        {
                            Console.WriteLine("Generate a board first!"); // Проверка наличия доски
                            break;
                        }
                        if (solver.Solve(board))
                            Console.WriteLine("Sudoku solved successfully!");
                        else
                            Console.WriteLine("No solution found.");
                        board.PrintBoard();
                        break;

                    case "3":
                        ManualInput(); // Переход в режим ручного ввода
                        break;

                    case "4":
                        if (board == null)
                        {
                            Console.WriteLine("Board is empty. Generate it first.");
                        }
                        else
                        {
                            FileManager.SaveBoard(board); // Сохранение в файл
                        }
                        break;

                    case "5":
                        if (board == null)
                        {
                            Console.WriteLine("Board is empty. Generate it first.");
                        }
                        else
                        {
                            FileManager.LoadBoard(board); // Загрузка из файла
                        }
                        break;

                    case "6":
                        if (board == null)
                            Console.WriteLine("Board is empty. Generate it first.");
                        else
                            board.PrintBoard();
                        break;

                    case "7":
                        if (board != null)
                            ((SudokuBoard)board).UndoLastMove(); // Вызов метода Undo у доски для отмены хода
                        break;

                    case "8":
                        exit = true; // Выход из программы
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // Режим ручного ввода судоку
        public void ManualInput()
        {
            if (board == null)
            {
                Console.WriteLine("Generate a board first!"); // Проверка, есть ли поле
                return;
            }

            Console.WriteLine("You can now start manually filling the Sudoku.");
            Console.WriteLine("Enter 'q' at any time to return to the main menu.");

            while (true)
            {
                board.PrintBoard(); // Печать текущей доски

                Console.Write("Enter row (1-9) or 'q' to quit: ");
                string? rowInput = Console.ReadLine();
                if (rowInput.ToLower() == "q")
                    break;

                Console.Write("Enter column (1-9) or 'q' to quit: ");
                string? colInput = Console.ReadLine();
                if (colInput.ToLower() == "q")
                    break;

                Console.Write("Enter value (1-9) or 'q' to quit: ");
                string? valInput = Console.ReadLine();
                if (valInput.ToLower() == "q")
                    break;

                if (int.TryParse(rowInput, out int row) &&
                    int.TryParse(colInput, out int col) &&
                    int.TryParse(valInput, out int value))
                {
                    row -= 1;
                    col -= 1;

                    if (row < 0 || row > 8 || col < 0 || col > 8 || value < 1 || value > 9)
                    {
                        Console.WriteLine("Invalid input. Row, column and value must be between 1 and 9.");
                        continue;
                    }

                    if (board.GetCellValue(row, col) != 0)
                    {
                        Console.WriteLine("Cell is already filled. Try another cell.");
                        continue;
                    }

                    if (board.IsValidMove(row, col, value))
                    {
                        ((SudokuBoard)board).SetCell(row, col, value); // Запись значения в ячейку
                        Console.WriteLine("Move accepted.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid move according to Sudoku rules.");
                    }

                    if (((SudokuBoard)board).IsBoardCompleted()) // Проверка, заполнена ли вся доска
                    {
                        board.PrintBoard();
                        Console.WriteLine("Congratulations! Sudoku completed!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter numbers between 1 and 9.");
                }
            }
        }
    }
}
