using System.Collections;
using System.Collections.Generic;
using Taller;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ludiq;
using Bolt;

public class GameManager : Singleton<GameManager>
{
   public static event FNotify OnGameBegin,OnGameOver,OnRoundOver;
    public static event FNotify_1Params<EGameStates> OnGamestateChange;
    public static event FNotify_1Params<int> OnScoreChanged;

    public EGameStates gameState=EGameStates.MainMenu;
    public int StartLevelIndex=0;
    public int roundScore;

    void OnEnable()
    {
        if(!Variables.ActiveScene.IsDefined("gameManagerRef"))
        {
            
        }
        Variables.Scene(gameObject).Set("gameManagerRef",gameObject);

       // Variables.ActiveScene.Set("gameManagerRef",gameObject);

    }
    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(StartLevelIndex);

    }

    public void ChangeGameState(EGameStates NewGameState)
    {
        gameState=NewGameState;
        CustomEvent.Trigger(gameObject,"_OnGamestateChange",NewGameState);

        OnGamestateChange?.Invoke(NewGameState);
        switch (gameState)
        {
            case EGameStates.GameBegin:
                OnGameBegin?.Invoke();

            break;

            case EGameStates.MainMenu:
                OnGameOver?.Invoke();

            break;

            case EGameStates.RoundOver:
                OnRoundOver?.Invoke();

                break;
        }
    }

    public void AddScore(int ScoreToAdd)
    {
        roundScore+=ScoreToAdd;

        OnScoreChanged?.Invoke(roundScore);

    }
}
