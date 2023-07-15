using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    public Transform playerTransform;
    private float zoom = 5f;

    // Start is called before the first frame update
    void Start() {
        cameraFollow.Setup(() => playerTransform.position, () => zoom);
    }

    // Update is called once per frame
    void Update() {
        HandleZoom();
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
