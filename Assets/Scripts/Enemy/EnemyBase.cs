using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
    private float health = 100f;
    public float speed = 3f;
    private Transform target;

    private void Update() {
        if (target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        //Player player = collider.GetComponent<Player>();
        if (collider.TryGetComponent<Player>(out Player player)) {
            target = player.transform;

            Debug.Log("Player entered");
        }

        if (collider.TryGetComponent<BulletPhysics>(out BulletPhysics bullet)) {
            bullet.DestroyBullet();
            TakeDamage(bullet.GetBulletDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out Player player)) {
            target = null;

            Debug.Log("Player exited");
        }
    }

    public void SetTarget() {

    }

    public void TakeDamage(float damage) {
        if (health > 0) {
            health -= damage;
        }

        if (health == 0 || health < 0) {
            EnemyDie();
        }
    }

    public void EnemyDie() {
        Destroy(gameObject);
    }

    public void MoveToDirection() {

    }
}
