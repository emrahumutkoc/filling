using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class PlayerMovementMouse : MonoBehaviour {
    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            GetComponent<MovePositionDirect>().SetMovePosition(Utils.GetMouseWorldPosition());
        }
    }
}
