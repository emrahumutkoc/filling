using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set; }

    private PlayerBase playerBase;
    private LevelSystem levelSystem;
    public Player () {
        Instance = this;
    }

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

    public Vector3 GetPosition() {
        return transform.position;
    }

}
