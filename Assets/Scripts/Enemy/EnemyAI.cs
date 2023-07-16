using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class EnemyAI : MonoBehaviour {

    private enum State {
        Roaming,
        ChaseTarget,
        ShootingTarget,
        GoingBackToStart,
    }

    [SerializeField] public object defaultTarget;

    private EnemyPathfindingMovement pathfindingMovement;
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private float nextShootTime;
    private State state;

    private void Awake() {
        pathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        state = State.Roaming;
    }

    private void Start() {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();

    }

    private void Update() {
        if (defaultTarget != null) {
            if (defaultTarget is Player) {
                Debug.Log("loggg");
            }
        } else {
            switch (state) {
                default:
                case State.Roaming:
                    Debug.Log("Roaming State");
                    pathfindingMovement.MoveToTimer(roamPosition);
                    float reachedPositionDistance = 15f;
                    if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) {
                        // Reached Roam Position
                        roamPosition = GetRoamingPosition();
                    }
                    FindTarget();
                    break;
                case State.ChaseTarget:
                    Debug.Log("Chasing State");
                    pathfindingMovement.MoveToTimer(Player.Instance.GetPosition());

                    float attackRange = 1f;
                    if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) < attackRange) {
                        // Target withing attack range
                        if (Time.time > nextShootTime) {
                            pathfindingMovement.StopMoving();
                            // state = State.ShootingTarget;
                            float fireRate = .03f;
                            nextShootTime = Time.time + fireRate;

                        }
                    }

                    float stopChaseDistance = 20f;
                    if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) > stopChaseDistance) {
                        // Too far, stop chasing
                        state = State.GoingBackToStart;
                        Debug.Log("Change changed as " + state);
                    }
                    break;
                case State.ShootingTarget:
                    Debug.Log("Shooting State");
                    break;
                case State.GoingBackToStart:
                    pathfindingMovement.MoveTo(startingPosition);
                    Debug.Log("Going back to start State" + Vector3.Distance(transform.position, roamPosition));
                    reachedPositionDistance = 40f;
                    if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) {
                        // Reached Roam Position
                        Debug.Log("Going back to start State" + state);

                        state = State.Roaming;
                    }
                    break;
            }
        }
        
    }

    private Vector3 GetRoamingPosition() {
        return startingPosition + Utils.GetRandomDir() * Random.Range(10f, 20f);
    }

    private void FindTarget() {
        float targetRange = 20f;
        if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) < targetRange) {
            // Player within target range
            state = State.ChaseTarget;
        }
    }
}
