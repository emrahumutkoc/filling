using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectiles : MonoBehaviour {
    [SerializeField] private Transform pfBullet;
    [SerializeField] private Transform pfBulletPhysics;
    [SerializeField] private float bulletMoveSpeed = 16f;

    private void Awake() {
        GetComponent<PlayerAim>().OnShoot += PlayerShootProjectiles_OnShoot;
    }

    private void PlayerShootProjectiles_OnShoot(object sender, PlayerAim.OnShootEventsArgs e) {
        // Shoot
        // METHOD 1;
        /*
        Transform bulletTransform = Instantiate(pfBullet, e.gunEndPointPosition, Quaternion.identity);
        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(shootDir);
        */

        // METHOD 2;
        Transform bulletTransform = Instantiate(pfBulletPhysics, e.gunEndPointPosition, Quaternion.identity);
        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        bulletTransform.GetComponent<BulletPhysics>().Setup(shootDir, bulletMoveSpeed);


        // METHOD 3;
        //Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        //BulletRaycast.Shoot(e.gunEndPointPosition, shootDir);
    }
}
