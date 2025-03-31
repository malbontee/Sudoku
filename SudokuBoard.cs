namespace sudoku_project
{
    public class SudokuBoard : IBoard
    {
        private int[][] board;
        private Stack<Tuple<int, int, int>> moveHistory; // Стек для истории ходов

        public SudokuBoard()
        {
            // Инициализация рваного массива 9x9
            board = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                board[i] = new int[9];
            }
            moveHistory = new Stack<Tuple<int, int, int>>(); // Инициализация стека для истории ходов
        }

        public int GetCellValue(int row, int col)
        {
            return board[row][col];
        }

        public void SetCell(int row, int col, int value)
        {
            moveHistory.Push(new Tuple<int, int, int>(row, col, board[row][col])); // Сохранение предыдущего состояния ячейки
            board[row][col] = value;
        }

        public bool IsValidMove(int row, int col, int value)
        {
            // Нельзя вставлять в уже заполненную клетку
            if (GetCellValue(row, col) != 0)
                return false;

            // Проверка строки
            for (int i = 0; i < 9; i++)
            {
                if (GetCellValue(row, i) == value)
                    return false;
            }

            // Проверка столбца
            for (int i = 0; i < 9; i++)
            {
                if (GetCellValue(i, col) == value)
                    return false;
            }

            // Проверка квадрата 3x3
            int startRow = row - row % 3;
            int startCol = col - col % 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GetCellValue(startRow + i, startCol + j) == value)
                        return false;
                }
            }

            return true;
        }

        // Метод для проверки, завершена ли доска
        public bool IsBoardCompleted()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int value = GetCellValue(row, col);
                    if (value == 0 || !IsValidMove(row, col, value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Печать доски
        public void PrintBoard()
        {
            Console.WriteLine("Current Sudoku board:");

            for (int row = 0; row < 9; row++)
            {
                if (row % 3 == 0)
                {
                    Console.WriteLine("+-------+-------+-------+");
                }

                for (int col = 0; col < 9; col++)
                {
                    if (col % 3 == 0)
                    {
                        Console.Write("| ");
                    }

                    int value = GetCellValue(row, col);
                    Console.Write(value == 0 ? ". " : value + " ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("+-------+-------+-------+");
        }

        // Метод для отмены последнего хода
        public void UndoLastMove()
        {
            if (moveHistory.Count == 0)
            {
                Console.WriteLine("No moves to undo.");
                return;
            }

            var lastMove = moveHistory.Pop();
            board[lastMove.Item1][lastMove.Item2] = lastMove.Item3; // Восстановление предыдущего значения ячейки
            Console.WriteLine($"Undo: Restored cell ({lastMove.Item1 + 1}, {lastMove.Item2 + 1}) to {lastMove.Item3}");
            PrintBoard();
        }

        public int[][] GetBoard()
        {
            return board;
        }
    }
}
