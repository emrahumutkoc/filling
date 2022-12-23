using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    public Transform playerTransform;
    public Transform obstacle1;
    public Transform obstacle2;
    public Transform obstacle3;
    private float zoom = 5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(() => playerTransform.position, () => zoom);
        // cameraFollow.SetCameraFollowPosition(new Vector3(100f, 100f));
        HandleZoom();
    }

    private void HandleZoom() {

        float zoomChangeAmount = 2f;
        if (Input.mouseScrollDelta.y > 0) {
            zoom -= zoomChangeAmount * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0) {
            zoom += zoomChangeAmount * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
}
