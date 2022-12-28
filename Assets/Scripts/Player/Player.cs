using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerBase playerBase;
    private Rigidbody2D playerRigidbody2D;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private bool isDashButtonDown;
    [SerializeField] float MOVE_SPEED = 10f;
    [SerializeField] float dashDistance = 3f;
    [SerializeField] private LayerMask dashLayerMask;

    private void Awake() {
        playerBase = gameObject.GetComponent<PlayerBase>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        MovePlayer();
        HandleDash();
    }

    private void MovePlayer() {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
        if (moveX != 0 || moveY != 0) {
            lastMoveDir = moveDir;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            isDashButtonDown = true;
        }
        //bool isIdle = moveX == 0 && moveY == 0;

        //if (isIdle) {
        //    // manage idle animation
        //} else {

        //    if (TryMove(moveDir, MOVE_SPEED * Time.deltaTime)) {
        //        // manage walking animation
        //        // store the last direction of the charecter and use it above to make right direction of the character.
        //    } else {
        //        // manage idle
        //    }
        //}
    }

    private void FixedUpdate() {
        playerRigidbody2D.MovePosition(transform.position + moveDir * MOVE_SPEED * Time.fixedDeltaTime);
    
        if (isDashButtonDown) {
            Vector2 dashPosition = transform.position + lastMoveDir * dashDistance;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, lastMoveDir, dashDistance, dashLayerMask);
            if (raycastHit2d.collider != null) {
                dashPosition = raycastHit2d.point;
            }

            //TryMove(moveDir, dashDistance);
            playerRigidbody2D.MovePosition(dashPosition);
            isDashButtonDown = false;   
        }
    }

    // make a raycast and test the distance to the wall change dash distance accordingly

    private bool CanMove(Vector3 direction, float distance) {
        return Physics2D.Raycast(transform.position, direction, distance).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float distance) {
        moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, distance);

        if (!canMove) {
            // Cannot move diagnoally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, distance);
            if (!canMove) {
                // Can not move horizontally
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, distance);

            }
        }

        if (canMove) {
            lastMoveDir = moveDir;
            // manage walking animation
            // store the last direction of the charecter and use it above to make right direction of the character.
            transform.position += moveDir * distance;
            return true;
        } else {
            return false;
        }
    }

    private void HandleDash() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TryMove(lastMoveDir, dashDistance);
        }
    }
}
