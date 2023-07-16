using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles finding Enemy Targets
 * */
public class EnemyTargeting : MonoBehaviour {
    private EnemyMain enemyMain;

    private void Awake() {
        enemyMain = GetComponent<EnemyMain>();
    }


}
