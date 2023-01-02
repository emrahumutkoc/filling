using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformVelocity : MonoBehaviour, IMoveVelocity {
    [SerializeField] private float moveSpeed = 2f;
    private Vector3 velocityVector;
    private Rigidbody2D playerRigidbody2D;

    private void Awake() {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        transform.position += velocityVector * moveSpeed * Time.deltaTime;
    }

    public void SetVelocity(Vector3 velocityVector) {
        this.velocityVector = velocityVector;
    }
}
