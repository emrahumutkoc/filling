using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem {
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;
    private static readonly int[] experiencePerLevel = new[] { 100, 120, 140, 160, 180, 200, 220, 230, 250, 300, 400 };
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystem() {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount) {
        if (!isMaxLevel()) {
            experience += amount;

            while (!isMaxLevel() && experience >= GetExperienceToNextLevel(level)) {
                // enough experience to level up
                experience -= GetExperienceToNextLevel(level);
                LevelUp();
            }
            if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    private void LevelUp() {
        level++;
        if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);

    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        if (isMaxLevel()) {
            return 1f;
        } else {
            return (float)experience / GetExperienceToNextLevel(level);
        }
    }

    public int GetExperienceToNextLevel(int level) {
        if (level < experiencePerLevel.Length) {
            return experiencePerLevel[level];
        } else {
            // Level 
            return 100;
        }
    }

    public bool isMaxLevel() {
        return isMaxLevel(level);
    }

    public bool isMaxLevel(int level) {
        return level == experiencePerLevel.Length - 1;
    }
}
