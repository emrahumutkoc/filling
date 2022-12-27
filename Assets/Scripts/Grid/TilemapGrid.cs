using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGrid {

    private GridSpriteSystem<TilemapObject> grid;

    public TilemapGrid(int width, int height, float cellSize, Vector3 originPosition) {
        grid = new GridSpriteSystem<TilemapObject>(width, height, cellSize, originPosition, (GridSpriteSystem<TilemapObject> g, int x, int y) => new TilemapObject(g, x, y));
    }

    public void SetTilemapSprite(Vector3 worldPosition, TilemapObject.TileMapSprite tilemapSprite) {
        TilemapObject tilemapObject = grid.GetGridObject(worldPosition);
        if (tilemapObject != null) {
            tilemapObject.SetTilemapSprite(tilemapSprite);
        }
    }

    public void SetTilemapVisual(TilemapVisual tilemapVisual) {
        tilemapVisual.SetGrid(grid);
    }


    // Define object that will be in grid cell
    public class TilemapObject {
        public enum TileMapSprite {
            None,
            Ground,
            Path,
            Dirt
        }

        private GridSpriteSystem<TilemapObject> grid;
        private int x, y;
        private TileMapSprite tilemapSprite;
        private BoxCollider2D boxCollider2D;
       
        public TilemapObject(GridSpriteSystem<TilemapObject> grid, int x, int y) {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void SetTilemapSprite(TileMapSprite tilemapSprite) {
            this.tilemapSprite = tilemapSprite;
            grid.TriggerGridObjectChanged(x, y);
        }

        public void SetBoxCollider(BoxCollider2D collider) {
            boxCollider2D = collider;
            grid.TriggerGridObjectChanged(x, y);
        }

        public TileMapSprite GetTileMapSprite() {
            return tilemapSprite;
        }

        public override string ToString() {
            return tilemapSprite.ToString();
        }
    }
}
