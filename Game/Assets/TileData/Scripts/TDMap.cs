using UnityEngine;
using System.Collections.Generic;

public class TDMap {

    protected class DRoom
    {
        public int left;
        public int top;
        public int width;
        public int height;

        public int right 
        {
            get { return left + width - 1; }
        }

        public int bottom
        {
            get { return top + height - 1; }
        }

        public int centerX
        {
            get { return left + width/2; }
        }
        public int centerY
        {
            get { return top + height/2; }
        }

        public bool CollidesWith(DRoom other)
        {
            if (left > other.right)
                return false;
            if (top > other.bottom)
                return false;
            if (right < other.left)
                return false;
            if (bottom < other.top)
                return false;

            return true;
        }
    }
    
    TDTile[] _tiles;
    int _width;
    int _height;
    List<DRoom> rooms;
    
    public TDMap(int width, int height) 
    {
        _width = width;
        _height = height;

        _tiles = new TDTile[_width * _height];

        rooms = new List<DRoom>();

        for (int x = 0; x < _width * _height; x++ )
        {
            _tiles[x] = new TDTile(TDTile.TILES.UNEXPLORED);
        }

        for (int i = 0; i < 10; i++)
        {
            int roomSizeX = Random.Range(4, 8);
            int roomSizeY= Random.Range(4, 8);

            DRoom r = new DRoom();
            r.left = Random.Range(0, width - roomSizeX);
            r.top = Random.Range(0, height - roomSizeY);
            r.width = roomSizeX;
            r.height = roomSizeY;

            if(!RoomCollides(r))
            {
                rooms.Add(r);
                MakeRoom(r);
            }           
        }           
    }


    bool RoomCollides(DRoom r)
    {
        foreach(DRoom r2 in rooms)
        {
            if(r.CollidesWith(r2))
            {
                return true;
            }           
        }
        return false;
    }
    public TDTile GetTileAt(int x, int y)
    {
        if(x < 0 || x >= _width || y < 0 || y >= _height)
            return null;

        return _tiles[y * _width + x];
    }

    void MakeRoom(DRoom r)
    {
        for(int x = 0; x < r.width; x++)
            for (int y = 0; y < r.height; y++)
            {
                if (x == 0 || x == r.width - 1 || y == 0 || y == r.height - 1)
                {
                    _tiles[y * _width + x + r.top * _width + r.left].type = TDTile.TILES.WALL;
                }
                else
                {
                    _tiles[y * _width + x + r.top * _width + r.left].type = TDTile.TILES.STONE;
                }
                
                
            }
    }

    void MakeCorrider(DRoom r1, DRoom r2)
    {

    }
    
}
