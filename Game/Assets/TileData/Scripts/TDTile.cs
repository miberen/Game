public class TDTile {

    public const int TILE_UNEXPLORED = 0;
    public const int TILE_FLOOR = 1;
    public const int TILE_WALL = 2;
    public const int TILE_STONE = 3;

    public int type;

    public TDTile(int t)
    {
        type = t;
    }
}
