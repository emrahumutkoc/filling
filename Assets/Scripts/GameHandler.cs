using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private TilemapVisual tilemapVisual;
    public Transform playerTransform;
    public Transform obstacle1;
    public Transform obstacle2;
    public Transform obstacle3;
    private float zoom = 5f;

    private GridSpriteSystem<GridCellSprite> spriteGrid;
    private TilemapGrid tilemap;
    private TilemapGrid.TilemapObject.TileMapSprite tilemapSprite = TilemapGrid.TilemapObject.TileMapSprite.Ground;

    // Start is called before the first frame update
    void Start()
    {
        //grid = new GridTEST<CellObject>(40, 40, 1f, Vector3.zero, (GridTEST<CellObject> g, int x, int y) => new CellObject(g, x, y));
        //spriteGrid = new GridSpriteSystem<GridCellSprite>(40, 40, 1f, Vector3.zero, (GridSpriteSystem<GridCellSprite> g, int x, int y) => new GridCellSprite(g, x, y));
        
        // tilmap-1
        // tilemap = new TilemapGrid(40, 40, 10f, Vector3.zero);
        cameraFollow.Setup(() => playerTransform.position, () => zoom);
        // tilemap.SetTilemapVisual(tilemapVisual);
        // cameraFollow.SetCameraFollowPosition(new Vector3(100f, 100f));

    }
    void Update() {
        HandleZoom();
        //HandleCameraChange();
        HandleChangeCellSprite();
        if (Input.GetMouseButtonDown(0)) {
            Vector3 position = Utils.GetMouseWorldPosition();

            //CellObject cellObject = grid.GetGridObject(position);
            //if (cellObject != null) {   
            //    cellObject.AddValue(5);
            //}
             
            //GridCellSprite cellObject = spriteGrid.GetGridObject(position);
            //if (cellObject != null) {
            //    cellObject.ChangeCellSprite();
            //}
            // tilemap.SetTilemapSprite(position, tilemapSprite);

            //if (cellObject != null) {
            //    cellObject.ChangeCellSprite();
            //}
        }
    }

    private void HandleCameraChange() {
        

        if (Input.GetKeyDown(KeyCode.R)) {
            cameraFollow.SetGetCameraFollowPositionFunc(() => playerTransform.position);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            cameraFollow.SetGetCameraFollowPositionFunc(() => obstacle1.position);
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            cameraFollow.SetGetCameraFollowPositionFunc(() => obstacle2.position);
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            cameraFollow.SetGetCameraFollowPositionFunc(() => obstacle3.position);
        }

    }

    private void HandleChangeCellSprite() {
        if (Input.GetKeyDown(KeyCode.G)) {
            tilemapSprite = TilemapGrid.TilemapObject.TileMapSprite.Ground;
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            tilemapSprite = TilemapGrid.TilemapObject.TileMapSprite.None;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            tilemapSprite = TilemapGrid.TilemapObject.TileMapSprite.Path;
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            tilemapSprite = TilemapGrid.TilemapObject.TileMapSprite.Dirt;
        }
    }
    private void HandleZoom() {
        float zoomChangeAmount = 250f;
        if (Input.mouseScrollDelta.y > 0) {
            zoom -= zoomChangeAmount * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0) {
            zoom += zoomChangeAmount * Time.deltaTime;
        }
    }
}

public class CellObject {
    private int value;
    private GridTEST<CellObject> grid;
    private int x;
    private int y;
    public CellObject(GridTEST<CellObject> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue (int addValue) {
        value += addValue;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString() {
        return value.ToString();
    }
}

//public class GridCellSprite: MonoBehaviour {
//    private GridSpriteSystem<GridCellSprite> grid;
//    GameObject cellObject;
//    SpriteRenderer spriteRenderer;
//    private int x, y;

//    public GridCellSprite(GridSpriteSystem<GridCellSprite> grid, int x, int y) {
//        this.grid = grid;
//        this.x = x;
//        this.y = y;
//    }

//    public void ChangeCellSprite() {
//        cellObject.GetComponent<SpriteRenderer>().color = Color.green;
//    }

//    public override string ToString() {
//        return "0";
//    }
//}
