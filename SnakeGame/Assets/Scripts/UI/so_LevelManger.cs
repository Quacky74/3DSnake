using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level Manger", menuName = "Scriptable/Level Manger")]
public class so_LevelManger : ScriptableObject
{
    public List<string> levelNames;
    [NonSerialized] private string _currentLevel;

    public void SetCurrentLevel(int index)
    {
        if (index >= 0 && index < levelNames.Count)
        {
            _currentLevel = levelNames[index];
            Debug.Log(_currentLevel);
        }
        else
        {
            Debug.Log(name + ": passed level index is greater then");
        }
        
    }

    public string GetCurrentLevel()
    {
        return _currentLevel;
    }

}
