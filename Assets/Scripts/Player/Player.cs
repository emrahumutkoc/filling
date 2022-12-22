using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerBase playerBase;
    private Vector3 lastMoveDir;
    [SerializeField] float speed = 3f;
    [SerializeField] float dashDistance = 3f;

    private void Awake() {
        playerBase = gameObject.GetComponent<PlayerBase>();
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

        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle) {
            // manage idle animation
        } else {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            if (TryMove(moveDir, speed * Time.deltaTime)) {
                // manage walking animation
                // store the last direction of the charecter and use it above to make right direction of the character.
            } else {
                // manage idle
            }
        }
    }
    // make a raycast and test the distance to the wall change dash distance accordingly

    private bool CanMove(Vector3 direction, float distance) {
        return Physics2D.Raycast(transform.position, direction, distance).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float distance) {
        Vector3 moveDir = baseMoveDir;
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
