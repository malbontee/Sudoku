namespace sudoku_project
{
    public class SudokuSolver : ISolver
    {
        public bool Solve(IBoard board)
        {
            // Проходим по каждой клетке на доске
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // Если клетка пуста (значение 0)
                    if (board.GetCellValue(row, col) == 0)
                    {
                        // Пробуем поставить числа от 1 до 9
                        for (int num = 1; num <= 9; num++)
                        {
                            // Если число можно поставить в текущую клетку
                            if (board.IsValidMove(row, col, num))
                            {
                                board.SetCell(row, col, num); // Ставим число

                                // Рекурсивно пытаемся решить оставшиеся клетки
                                if (Solve(board))
                                    return true; // Если решение найдено, возвращаем true

                               
                                board.SetCell(row, col, 0); // Если решение не найдено, откатываем изменения
                            }
                        }

                       
                        return false; // Если не нашли подходящее число для текущей клетки, возвращаем false
                    }
                }
            }

           
            Console.WriteLine("Solution found!");
            return true;
        }
    }
}
