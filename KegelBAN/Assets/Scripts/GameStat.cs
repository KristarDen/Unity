using System.Collections.Generic;

public class GameStat
{
    public static List<MoveData> Moves = new List<MoveData>();
    public static List<MoveData> BestMoves;

    public static bool IsRecord
    {
        get
        {
            int total = 0, bestTotal = 0;
            foreach (var move in Moves) total += move.Score;
            foreach (var move in BestMoves) bestTotal += move.Score;
            return total > bestTotal;
        }
    }
}
