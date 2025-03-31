namespace sudoku_project
{
    



    public class SudokuGenerator : IGenerator
    {
        private readonly Difficulty difficulty;

        public SudokuGenerator(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        public IBoard Generate()
        {
            var board = new SudokuBoard();
            Random random = new Random();

            // Количество ячеек для заполнения в зависимости от выбранного уровня сложности
            int attempts = difficulty switch
            {
                Difficulty.Easy => 20,
                Difficulty.Medium => 15,
                Difficulty.Hard => 10,
                _ => 20 // значение по умолчанию
            };

            while (attempts > 0)
            {
                int row = random.Next(0, 9);
                int col = random.Next(0, 9);
                int num = random.Next(1, 10);
                // Проверяем, что клетка пуста и вставка не нарушит правила судоку
                if (board.GetCellValue(row, col) == 0 && board.IsValidMove(row, col, num))
                {
                    board.SetCell(row, col, num);
                    attempts--;
                }
            }

            return board;
        }
    }
}