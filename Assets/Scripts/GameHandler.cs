using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform playerTransform;
    public Transform obstacle1;
    public Transform obstacle2;
    public Transform obstacle3;
    private float zoom;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(() => playerTransform.position, () => zoom);

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

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ZoomIn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            ZoomOut();
        }
    }

    private void ZoomIn() {
        zoom -= 5f;
        if (zoom < 40f) zoom = 5f;
    }
    private void ZoomOut() {
        zoom += 5f;
        if (zoom > 30f) zoom = 30f;
    }


}
