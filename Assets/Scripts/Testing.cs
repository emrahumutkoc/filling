using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private PlayerAim playerAimWeapon;
    private void Start() {
        playerAimWeapon.OnShoot += PlayerAim_OnShoot;
    }

    private void PlayerAim_OnShoot(object sender, PlayerAim.OnShootEventsArgs e) {

    }
}
