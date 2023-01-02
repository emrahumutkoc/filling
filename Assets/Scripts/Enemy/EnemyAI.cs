using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class EnemyAI : MonoBehaviour {
    private Vector3 startingPosition;

    private void Start() {
        startingPosition = transform.position;
    }

    private Vector3 GetRoamingPosition() {
        return startingPosition + Utils.GetRandomDir() * Random.Range(10f, 20f);
    }
}
