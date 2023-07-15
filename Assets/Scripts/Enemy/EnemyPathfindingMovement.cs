using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfindingMovement : MonoBehaviour {

    private const float SPEED = 7f;

    private EnemyMain enemyMain;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float pathfindingTimer;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Awake() {
        enemyMain = GetComponent<EnemyMain>();
    }

    private void Update() {
        pathfindingTimer -= Time.deltaTime;

        HandleMovement();
    }

    private void FixedUpdate() {
        enemyMain.EnemyRigidbody2D.velocity = moveDir * SPEED;
    }

    private void HandleMovement() {
        PrintPathfindingPath();
        if (pathVectorList != null) {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            float reachedTargetDistance = 5f;
            if (Vector3.Distance(GetPosition(), targetPosition) > reachedTargetDistance) {
                moveDir = (targetPosition - GetPosition()).normalized;
                lastMoveDir = moveDir;
            } else {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count) {
                    StopMoving();
                }
            }
        }
    }

    public void StopMoving() {
        pathVectorList = null;
        moveDir = Vector3.zero;
    }

    public List<Vector3> GetPathVectorList() {
        return pathVectorList;
    }

    private void PrintPathfindingPath() {
        if (pathVectorList != null) {
            for (int i = 0; i < pathVectorList.Count - 1; i++) {
                Debug.DrawLine(pathVectorList[i], pathVectorList[i + 1]);
            }
        }
    }

    public void MoveTo(Vector3 targetPosition) {
        SetTargetPosition(targetPosition);
    }

    public void MoveToTimer(Vector3 targetPosition) {
        if (pathfindingTimer <= 0f) {
            SetTargetPosition(targetPosition);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition) {
        currentPathIndex = 0;

        pathfindingTimer = .2f;
        pathVectorList = new List<Vector3> { targetPosition };

        if (pathVectorList != null && pathVectorList.Count > 1) {
            pathVectorList.RemoveAt(0);
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Vector3 GetLastMoveDir() {
        return lastMoveDir;
    }

    public void Enable() {
        enabled = true;
    }

    public void Disable() {
        enabled = false;
    }

}
