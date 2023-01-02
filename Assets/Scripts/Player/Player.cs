using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private PlayerBase playerBase;
    private LevelSystem levelSystem;

    private void Awake() {
        playerBase = gameObject.GetComponent<PlayerBase>();
    }

    // make a raycast and test the distance to the wall change dash distance 

    public void SetLevelSystem(LevelSystem levelSystem) {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e) {
        // do whenever player level ups
        Debug.Log("player level up");
    }
}
