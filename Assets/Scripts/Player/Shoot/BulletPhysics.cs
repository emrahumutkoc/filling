using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class BulletPhysics : MonoBehaviour {
    public void Setup(Vector3 shootDir) {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        float moveSpeed = 20f;
        rigidbody2D.AddForce(shootDir * moveSpeed, ForceMode2D.Impulse);


        transform.eulerAngles = new Vector3(0, 0, Utils.GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Target target = collider.GetComponent<Target>();
        if (target != null) {
            // Hit
            target.Damage();
            Destroy(gameObject);
        }
    }
}
