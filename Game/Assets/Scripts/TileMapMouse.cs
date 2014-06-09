using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

    TileMap tileMap;

    Vector3 currentTileCoord;

    public Transform selectionCube;

    void Start()
    {
        tileMap = GetComponent<TileMap>();
    }

	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (collider.Raycast( ray, out hitInfo, Mathf.Infinity))
        {
            selectionCube.active = true;
            int x = Mathf.FloorToInt(hitInfo.point.x / tileMap.tileSize);
            int z = Mathf.FloorToInt(hitInfo.point.z / tileMap.tileSize);

            currentTileCoord.x = x;
            currentTileCoord.z = z;

            selectionCube.transform.position = currentTileCoord;
        }
        else
        {
            selectionCube.active = false;
        }
	}
}
