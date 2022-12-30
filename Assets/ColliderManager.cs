using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderManager : MonoBehaviour {
    [SerializeField] private RuleTile grassTile;
    private Tilemap tilemap;
    private void Awake() {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerStay2D(Collider2D collider) {
        BulletPhysics bullet = collider.GetComponent<BulletPhysics>();
        if (bullet != null) {
            Vector3Int test = tilemap.WorldToCell(bullet.transform.position);
            TileBase tileBase = tilemap.GetTile(test);

            if (tileBase != null && tileBase != grassTile) {
                tilemap.SetTile(test, grassTile);
                bullet.DestroyBullet();
            }
        }
    }
}