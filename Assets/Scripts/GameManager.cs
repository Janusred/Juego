using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

public GameState currentGameState = GameState.menu;
public static GameManager sharedInstance;

private PlayerController controller;

public int collectedObject=0;

void Awake(){
    if(sharedInstance == null)
    {
        sharedInstance = this;
    }
}

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame){
            StartGame();
        }
    }
    public void StartGame(){
        SetGameState(GameState.inGame);
    }
    public void GameOver(){
SetGameState(GameState.gameOver);
    }
    public void GameBackToMenu(){
            SetGameState(GameState.menu);
    }
    private void SetGameState(GameState newGameState){
        if(newGameState == GameState.menu){
                MenuManager.sharedInstance.ShowMainMenu();
        }else if(newGameState == GameState.inGame){
           LevelManager.sharedInstance.RemoveAllLevelBlocks();
            LevelManager.sharedInstance.GenerateInitialBlocks();
            controller.StartGame();
            Invoke("ReloadLevel",0.1f);
            MenuManager.sharedInstance.HideMainMenu();
        }else if(newGameState == GameState.gameOver){
                MenuManager.sharedInstance.ShowMainMenu();
        }
        this.currentGameState = newGameState;
    } 
    void ReloadLevel(){
        LevelManager.sharedInstance.GenerateInitialBlocks();
            controller.StartGame();
    }

    public void collectedObject(Collectable Collectable){
        collectedObject += Collectable.value;
    }

}
