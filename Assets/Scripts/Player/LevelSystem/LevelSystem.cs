using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem 
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystem() {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }
    
    public void AddExperience(int amount) {
        experience += amount;
    
        while (experience >= experienceToNextLevel) {
            // enough experience to level up
            LevelUp();
            experience -= experienceToNextLevel;
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    private void LevelUp() {
        level++;
        if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);

    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        return (float) experience / experienceToNextLevel; 
    }
}
