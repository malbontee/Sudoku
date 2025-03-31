
namespace sudoku_project
{
    using static ThemeSelector;
    internal class Program
    {
        static void Main(string[] args)
        {
            Theme selectedTheme = ChooseTheme();
            ApplyTheme(selectedTheme);

            ISolver solver = new SudokuSolver();

            // Создаем и запускаем меню
            IMenu menu = new SudokuMenu(solver);
            IBoard board = new SudokuBoard();

            menu.ShowMenu();

            

        }
    }
}
