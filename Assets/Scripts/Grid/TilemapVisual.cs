using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.MeshUtils;

public class TilemapVisual : MonoBehaviour {

    [System.Serializable]
    public struct TilemapSpriteUV {
        public TilemapGrid.TilemapObject.TileMapSprite tilemapSprite;
        public Vector2Int uv00Pixels;
        public Vector2Int uv11Pixels;
    }

    private struct UVCoords {
        public Vector2 uv00;
        public Vector2 uv11;
    }

    [SerializeField] private TilemapSpriteUV[] tilemapSpriteUVArray;

    private GridSpriteSystem<TilemapGrid.TilemapObject> grid;
    private Mesh mesh;
    private bool updateMesh;
    private Dictionary<TilemapGrid.TilemapObject.TileMapSprite, UVCoords> uvCoordsDictionary;

    private void Awake() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Texture texture = GetComponent<MeshRenderer>().material.mainTexture;
        float textureWidth = texture.width;
        float textureHeight = texture.height;

        uvCoordsDictionary = new Dictionary<TilemapGrid.TilemapObject.TileMapSprite, UVCoords>();
        foreach (TilemapSpriteUV tilemapSpriteUV in tilemapSpriteUVArray) {
            uvCoordsDictionary[tilemapSpriteUV.tilemapSprite] = new UVCoords {
                uv00 = new Vector2(tilemapSpriteUV.uv00Pixels.x / textureWidth, tilemapSpriteUV.uv00Pixels.y / textureHeight),
                uv11 = new Vector2(tilemapSpriteUV.uv11Pixels.x / textureWidth, tilemapSpriteUV.uv11Pixels.y / textureHeight)
            };
        }
    }

    public void SetGrid(GridSpriteSystem<TilemapGrid.TilemapObject> grid) {
        this.grid = grid;
        UpdateHeatMapVisual();

        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, GridSpriteSystem<TilemapGrid.TilemapObject>.OnGridValueChangedEventArgs e) {
        UpdateHeatMapVisual();
        updateMesh = true;
    }

    private void LateUpdate() {
        if (updateMesh) {
            updateMesh = false;
            UpdateHeatMapVisual();
        }
    }

    private void UpdateHeatMapVisual() {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++) {
            for (int y = 0; y < grid.GetHeight(); y++) {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

                TilemapGrid.TilemapObject gridObject = grid.GetGridObject(x, y);
                TilemapGrid.TilemapObject.TileMapSprite tileMapSprite = gridObject.GetTileMapSprite();

                Vector2 gridValueUV00, gridValueUV11;
                if (tileMapSprite == TilemapGrid.TilemapObject.TileMapSprite.None) {
                    gridValueUV00 = Vector2.zero;
                    gridValueUV11 = Vector2.zero;
                    // none will have not wireframe
                    quadSize = Vector3.zero;
                } else {
                    UVCoords uvCoords = uvCoordsDictionary[tileMapSprite];
                    gridValueUV00 = uvCoords.uv00;
                    gridValueUV11 = uvCoords.uv11;
                }
                 
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, gridValueUV00, gridValueUV11);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

}
