using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class Bullet : MonoBehaviour {
    private Vector3 shootDir;
    public void Setup(Vector3 shootDir) {
        this.shootDir = shootDir;

        transform.eulerAngles = new Vector3(0, 0, Utils.GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f);
    }

    private void Update() {
        float bulletMoveSpeed = 20f;
        transform.position += shootDir * bulletMoveSpeed * Time.deltaTime;

        // METHOD 1
        //float hitDetectionSize = 0.7f;
        //Target target = Target.GetClosest(transform.position, hitDetectionSize);
    
        //if (target != null) {
        //    target.Damage();
        //    Destroy(gameObject);
        //}
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
