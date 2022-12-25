using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    public Transform playerTransform;
    public Transform obstacle1;
    public Transform obstacle2;
    public Transform obstacle3;
    private float zoom = 5f;

    private GridTEST<CellObject> grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridTEST<CellObject>(20, 20, 1f, Vector3.zero, (GridTEST<CellObject> g, int x, int y) => new CellObject(g, x, y));
        cameraFollow.Setup(() => playerTransform.position, () => zoom);
        // cameraFollow.SetCameraFollowPosition(new Vector3(100f, 100f));
       
    }
    void Update() {
        HandleZoom();
        HandleCameraChange();

        if (Input.GetMouseButtonDown(0)) {
            Vector3 position = Utils.GetMouseWorldPosition();
            //grid.SetValue(position, true);
            //grid.AddValue(position, 100, 2, 25);
            CellObject cellObject = grid.GetGridObject(position);
            if (cellObject != null) {   
                cellObject.AddValue(5);
            }
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

    private void HandleZoom() {
        float zoomChangeAmount = 250f;
        if (Input.mouseScrollDelta.y > 0) {
            Debug.Log(Input.mouseScrollDelta.y);
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
