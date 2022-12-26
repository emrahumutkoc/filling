using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCellSprite
{
    private GridSpriteSystem<GridCellSprite> grid;
    SpriteRenderer spriteRenderer;
    private int x, y;

    public GridCellSprite(GridSpriteSystem<GridCellSprite> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void ChangeCellSprite() {
        //cellObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public override string ToString() {
        return "0";
    }
}
