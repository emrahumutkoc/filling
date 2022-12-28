using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class PlayerAim : MonoBehaviour {

    public event EventHandler<OnShootEventsArgs> OnShoot;
    public class OnShootEventsArgs: EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }
    private Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private Animator aimAnimator;

    private void Awake() {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }

    private void Update() {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming() {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 ||angle < -90) {
            aimLocalScale.y = -1f;
        } else {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }

    private void HandleShooting() {
        if (Input.GetMouseButtonDown(0)) {
            aimAnimator.SetTrigger("Shoot");
            Vector3 mousePosition = Utils.GetMouseWorldPosition();

            OnShoot?.Invoke(this, new OnShootEventsArgs {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition,
            }) ;
        }
    }
}
