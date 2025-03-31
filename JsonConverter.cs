using System.Text.Json;

public static class JsonConverter
{
    public static void Save(int[][] board, string filename)
    {
        string json = JsonSerializer.Serialize(board);
        File.WriteAllText(filename, json);
    }

    public static void Load(ref int[][] board, string filename)
    {
        string json = File.ReadAllText(filename);
        board = JsonSerializer.Deserialize<int[][]>(json);
    }
}



