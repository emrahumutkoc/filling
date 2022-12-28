using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private RuleTile grassTile;
    private Tilemap tilemap;
    private void Awake() {
        tilemap = GetComponent<Tilemap>();
    }
    //private void OnTriggerEnter2D(Collider2D collision) {
    //    BulletPhysics bullet = collision.GetComponent<BulletPhysics>();
    //    if (bullet != null) {
    //        Debug.Log("mermidir bu");
    //        //map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), grassTile);
    //        Debug.Log(bullet.transform.position);
    //        Vector2 bulletPosition;
    //        bulletPosition.x = Mathf.Floor(bullet.transform.position.x);
    //        bulletPosition.y = Mathf.Floor(bullet.transform.position.y);
    //        tilemap.SetTile(new Vector3Int((int)bulletPosition.x, (int)bulletPosition.y, (int)0), grassTile);

    //        bullet.DestroyBullet();
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision) {
    //    BulletPhysics bullet = collision.gameObject.GetComponent<BulletPhysics>();

    //    Debug.Log("collision.gameObject" + collision.gameObject.name);
    //    if (bullet != null) {
    //        Vector3 hitPosition = Vector3.zero;
    //        foreach (ContactPoint2D hit in collision.contacts) {
    //            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
    //            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
    //            Vector3Int cellPosition = new Vector3Int((int)hitPosition.x, (int)hitPosition.y, (int)0);

    //            tilemap.SetTile(cellPosition, grassTile);

    //            //tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
    //        }
    //        bullet.DestroyBullet();
    //    }

    //}

    private void OnTriggerStay2D(Collider2D collider) {
        BulletPhysics bullet = collider.GetComponent<BulletPhysics>();
        if (bullet != null) {
            //collider.ClosestPoint();
            //Debug.Log("mermidir bu");
            //bullet.
            Debug.Log("bullet.transform.position" + bullet.transform.position);
            Vector2 bulletPosition;
       
            bulletPosition.x = Mathf.Floor(bullet.transform.position.x);
            bulletPosition.y = Mathf.Floor(bullet.transform.position.y);


            Vector3Int cellPosition = new Vector3Int((int)bulletPosition.x, (int)bulletPosition.y, (int)0);
            Debug.Log("cellPosition  " + cellPosition.ToString());
            tilemap.SetTile(cellPosition, grassTile);
            //Tile.ColliderType colliderType = Tile.ColliderType.None;
            //tilemap.SetColliderType(cellPosition, colliderType);
            bullet.DestroyBullet();
        }
    }
}

