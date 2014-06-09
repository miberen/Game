using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TGMap))]
public class TileMapMouse : MonoBehaviour {

    TGMap _tileMap;
	
	Vector3 currentTileCoord;
	
	public Transform selectionCube;
	
	void Start() {
        _tileMap = GetComponent<TGMap>();
	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;
		
		if( collider.Raycast( ray, out hitInfo, Mathf.Infinity ) ) {
			int x = Mathf.FloorToInt( hitInfo.point.x / _tileMap.tileSize);
			int z = Mathf.CeilToInt( hitInfo.point.z / _tileMap.tileSize);
			Debug.Log ("Tile: " + x + ", " + z);
			
			currentTileCoord.x = x;
			currentTileCoord.z = z;
			
			selectionCube.transform.position = currentTileCoord;

            if(Input.GetMouseButtonDown(0)) {
                _tileMap.tdMap.GetTileAt(x, z).type = TDTile.TILE_STONE;
		    }
		}
		else {
			// Hide selection cube?
		}
		
		
	}
}
