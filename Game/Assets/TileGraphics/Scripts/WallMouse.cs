using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(TGMap))]
public class WallMouse : MonoBehaviour
{
    Vector3 currentTileCoord;

    public Transform selectionCube;
    LayerMask lM = 1 << 8;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, lM))
        {
            int x = Mathf.FloorToInt(hitInfo.transform.position.x);
            int z = Mathf.FloorToInt(hitInfo.transform.position.z);
            Debug.Log("Tile: " + x + ", " + z);

            currentTileCoord.x = x;
            currentTileCoord.z = z;
            currentTileCoord.y = 2.5f;

            selectionCube.transform.position = currentTileCoord;

            if (Input.GetMouseButtonDown(0))
            {
                //_tileMap.tdMap.GetTileAt(x, z).type = TDTile.TILE_STONE;
            }
        }
        else
        {
            // Hide selection cube?
        }


    }
}
