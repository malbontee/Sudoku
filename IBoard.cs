namespace sudoku_project
{
    public interface IBoard
    {
        /// <summary>
        /// Получает текущее состояние судоку в виде двумерного массива.
        /// </summary>
        /// <returns>Двумерный массив (9x9), представляющий игровое поле.</returns>
        int[][] GetBoard();

        /// <summary>
        /// Получает значение из указанной ячейки судоку.
        /// </summary>
        /// <param name="row">Строка (0-8).</param>
        /// <param name="col">Столбец (0-8).</param>
        /// <returns>Число от 1 до 9, если ячейка заполнена, или 0, если ячейка пуста.</returns>
        int GetCellValue(int row, int col);

        /// <summary>
        /// Устанавливает значение в указанную ячейку судоку.
        /// </summary>
        /// <param name="row">Строка (0-8).</param>
        /// <param name="col">Столбец (0-8).</param>
        /// <param name="value">Число от 1 до 9.</param>
        void SetCell(int row, int col, int value);

        /// <summary>
        /// Проверяет, допустимо ли установить указанное значение в данную ячейку судоку.
        /// </summary>
        /// <param name="row">Строка (0-8).</param>
        /// <param name="col">Столбец (0-8).</param>
        /// <param name="value">Число от 1 до 9.</param>
        /// <returns>True, если ход допустим, иначе False.</returns>
        bool IsValidMove(int row, int col, int value);

        /// <summary>
        /// Выводит игровое поле судоку в консоль.
        /// </summary>
        void PrintBoard();
    }

}
