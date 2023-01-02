using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity {
    [SerializeField] private float moveSpeed;
    private Vector3 velocityVector;
    private Rigidbody2D playerRigidbody2D;

    private void Awake() {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetVelocity(Vector3 velocityVector) {
        this.velocityVector = velocityVector;
    }

    private void FixedUpdate() {
        //rigidbody2D.velocity = velocityVector * moveSpeed;
        playerRigidbody2D.MovePosition(transform.position + velocityVector * moveSpeed * Time.fixedDeltaTime);
    }
}

