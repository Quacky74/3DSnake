using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    [SerializeField] private Text endScreentile;
    [SerializeField] private Text endScreenMessage;
    [SerializeField] private so_CollectableController PlayerCollectables;

    [SerializeField] private so_PlayerEvents playerEvents;
    [SerializeField] private GameObject GameplayCanvas;
    [SerializeField] private GameObject EndGameCanvas;
    private void OnEnable()
    {
        playerEvents.OnHitWall += DisableGame;
        playerEvents.OnGameOver += DisplayScreen;
    }

    void DisableGame()
    {
        CreateEndGameScreen();
        

        if (GameplayCanvas != null)
        {
            GameplayCanvas.SetActive(false);
        }

        
        
    }

    void CreateEndGameScreen()
    {
        if (EndGameCanvas != null)
        {
            EndGameCanvas.SetActive(true);
        }
       
    }

    
    void DisplayScreen(List<Collectable> collectables, bool isTimerFinished)
    {
        //Set the tile text
        if (isTimerFinished)
        {
            SetTile("Times up");
        }
        else
        {
            SetTile("You hit a wall");
        }
        //Set the Message text
        SetMessage(CreateMessage(collectables));
    }

    void SetTile(string newTile)
    {
        if (endScreentile != null)
        {
            endScreentile.text = newTile;
        }
    }

    string CreateMessage(List<Collectable> collectables)
    {
        string newMessage = "";

        int redcount = 0, bluecount = 0, greencount = 0;
        foreach (var col in collectables)
        {
            
            switch (col.BlockType)
            {
                case EBlockType.Blue:
                    bluecount++;
                
                break;
                case EBlockType.Red:

                    redcount++;
                break;
                case EBlockType.Green:
                    greencount++;
                break;
                default:
                break;
            }
        }

        string redLine = "Red cubes collected: " + redcount + "\n";
        string blueLine = "Blue cubes collected: " + bluecount + "\n";
        string greenLine = "Green cubes collected: " + greencount + "\n";

        newMessage = "You collected \n" + redLine + blueLine + greenLine;
        
        return newMessage;
    }

    void SetMessage(string newMessage)
    {
        if (endScreenMessage != null)
        {
            endScreenMessage.text = newMessage;
        }
        
    }
    
    
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
