using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class BulletPhysics : MonoBehaviour {

    private float bulletDamage = 27f;
    public void Setup(Vector3 shootDir, float bulletMoveSpeed = 10f) {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(shootDir * bulletMoveSpeed, ForceMode2D.Impulse);


        transform.eulerAngles = new Vector3(0, 0, Utils.GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Target target = collider.GetComponent<Target>();
        TilemapVisual tileMapVisual = collider.GetComponent<TilemapVisual>();
        //Debug.Log("asd" + collider.ToString());
        if (target != null) {
            // Hit
            target.Damage();
            Destroy(gameObject);
        }

        if (tileMapVisual != null) {
            Debug.Log("mrh");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("bi�iler");
    }

    public void DestroyBullet() {
        Destroy(gameObject);

        // to stop bullet;s
        //Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        //rigidbody2D.velocity = Vector2.zero;
        //rigidbody2D.angularVelocity = 0f;
    }

    public void SetBulletDamage(float bulletDamage) {
        this.bulletDamage = bulletDamage;
    }
    public float GetBulletDamage() {
        return bulletDamage;
    }
}
