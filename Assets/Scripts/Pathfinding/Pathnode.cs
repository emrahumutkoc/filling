using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode {

    private GridSystem<PathNode> grid;
    public int x, y;

    public int gCost;
    public int hCost;
    public int fCost;
    public bool isWalkable;

    public PathNode cameFromNode;
    public PathNode(GridSystem<PathNode> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = true;
    }

    public void CalculateFCost() {
        fCost = gCost + hCost;
    }

    public override string ToString() {
        return x + "," + y;
    }

    public void SetIsWalkable(bool isWalkable) {
        this.isWalkable = isWalkable;
        grid.TriggerGridObjectChanged(x, y);
    }

    public Vector3 GetWorldVector(Vector3 worldOrigin, float nodeSize) {
        return worldOrigin + new Vector3(x * nodeSize, y * nodeSize);
    }
}
