using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeys : MonoBehaviour {

    private Vector3 lastMoveDir;
    private Vector3 moveDir;
    private bool isDashButtonDown = false;
    [SerializeField] float dashDistance = 3f;
    [SerializeField] private LayerMask dashLayerMask;

    private IMoveVelocity moveVelocity;

    private void Awake() {
        moveVelocity = GetComponent<IMoveVelocity>();
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

        moveVelocity.SetVelocity(moveDir);

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

    private void HandleDash() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isDashButtonDown = true;
            TryMove(lastMoveDir, dashDistance);
        }
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

    private bool CanMove(Vector3 direction, float distance) {
        return Physics2D.Raycast(transform.position, direction, distance).collider == null;
    }

    private void FixedUpdate() {

        if (isDashButtonDown) {
            Vector2 dashPosition = transform.position + lastMoveDir * dashDistance;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, lastMoveDir, dashDistance, dashLayerMask);
            if (raycastHit2d.collider != null) {
                dashPosition = raycastHit2d.point;
            }

            //TryMove(moveDir, dashDistance);
            GetComponent<IMoveVelocity>().SetVelocity(dashPosition);
            isDashButtonDown = false;
        }
    }
}
