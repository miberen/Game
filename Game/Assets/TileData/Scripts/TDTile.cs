public class TDTile {
    public enum TILES
    {
        UNEXPLORED = 0,
        FLOOR = 1,
        WALL = 2,
        STONE = 3
    }

    public TILES type;

    public TDTile(TILES t)
    {
        type = t;
    }
}
