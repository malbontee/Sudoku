

namespace sudoku_project
{
    public class TxtSerializer : ISerializer
    {
        public void Save(IBoard board, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        writer.Write(board.GetCellValue(row, col));
                        if (col < 8) writer.Write(" ");
                    }
                    writer.WriteLine();
                }
            }
        }

        public void Load(IBoard board, string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int row = 0; row < 9; row++)
            {
                string[] values = lines[row].Split(' ');
                for (int col = 0; col < 9; col++)
                {
                    int value = int.Parse(values[col]);
                    board.SetCell(row, col, value);
                }
            }
        }
    }
}

