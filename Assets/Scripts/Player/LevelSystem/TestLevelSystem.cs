using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelSystem : MonoBehaviour
{
    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private Player player;
    private void Awake() {
        LevelSystem levelSystem = new LevelSystem();
        //levelWindow.SetLevelSystem(levelSystem);
        //player.SetLevelSystem(levelSystem);
    }
}
