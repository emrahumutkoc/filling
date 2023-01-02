using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class MoveRoam : MonoBehaviour {
    private Vector3 startPosition;
    private Vector3 targetMovePosition;

    private void Awake() {
        startPosition = transform.position;
    }

    private void Start() {
        SetRandomMovePosition();
    }

    private void Update() {
        SetMovePosition(targetMovePosition);
        float arrivedAtPositionDistance = 1f;
        if (Vector3.Distance(transform.position, targetMovePosition) < arrivedAtPositionDistance) {
            // Reached position
            SetRandomMovePosition();
        }
    }

    private void SetRandomMovePosition() {
        targetMovePosition = startPosition + Utils.GetRandomDir() * Random.Range(5f, 10f);
    }

    private void SetMovePosition(Vector3 movePosition) {
        GetComponent<IMoveVelocity>().SetVelocity(movePosition);
    }
}
