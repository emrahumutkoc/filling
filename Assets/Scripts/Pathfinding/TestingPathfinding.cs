using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class TestingPathfinding : MonoBehaviour {
    private Pathfinding pathfinding;
    [SerializeField] private PathfindingVisual pathfindingVisual;
    private float zoom = 5f;

    private void Start() {
        pathfinding = new Pathfinding(10, 10);
        Vector3 startPoint = Vector3.zero;

        if (pathfindingVisual != null)
            pathfindingVisual.SetGrid(pathfinding.GetGrid());
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseworldPosition = Utils.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseworldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null) {
                for (int i = 0; i < path.Count - 1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }
    }
}
