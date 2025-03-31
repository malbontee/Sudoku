namespace sudoku_project
{
    public interface ISerializer
    {
        /// <summary>
        /// Сохраняет текущую доску в файл по указанному пути.
        /// </summary>
        /// <param name="board">Доска, которую нужно сохранить.</param>
        /// <param name="path">Путь к файлу, в который будет сохранена доска.</param>
        void Save(IBoard board, string path);

        /// <summary>
        /// Загружает доску из файла по указанному пути.
        /// </summary>
        /// <param name="board">Доска, в которую будет загружено состояние из файла.</param>
        /// <param name="path">Путь к файлу, из которого будет загружена доска.</param>
        void Load(IBoard board, string path);
    }
}
