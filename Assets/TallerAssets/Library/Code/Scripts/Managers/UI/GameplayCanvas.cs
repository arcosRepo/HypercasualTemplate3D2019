using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Lean.Touch;
using Taller;
using DG.Tweening;
using UnityEngine.UI;

public class GameplayCanvas : MonoBehaviour
{
 	private bool bClicked;
	private CanvasGroup canvasGroup;
	public float fadeTime =.2f;
	private GameObject childGameover;

	private void Awake()
	{

		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
			canvasGroup = GetComponentInChildren<CanvasGroup>();

		childGameover=transform.GetChild(0).gameObject;
		childGameover.SetActive(true);

	}
	// Start is called before the first frame update
	protected virtual void OnEnable()
	{
        GameManager.OnGameBegin += GameManager_OnGameBegin;
         GameManager.OnGamestateChange += GameManager_OnGamestateChange;
	}


    protected virtual void OnDisable()
	{
		GameManager.OnGameBegin -= GameManager_OnGameBegin;
 		GameManager.OnGamestateChange -= GameManager_OnGamestateChange;

	}

    private void GameManager_OnGamestateChange(EGameStates Param1)
    {
        switch (Param1)
        {
            case EGameStates.MainMenu:
                break;
            case EGameStates.GameBegin:
                break;
            case EGameStates.GameOver:
				canvasGroup?.DOFade(0, fadeTime).OnComplete(() =>
				{
					gameObject.SetActive(false);


				});
				break;
            case EGameStates.RoundOver:
                break;
            default:
                break;
        }
    }
	private void GameManager_OnGameBegin()
	{
		 BeginGame();

	}

	 
	private void BeginGame()
	{ 
		 
		canvasGroup?.DOFade(1, fadeTime).OnComplete(() =>
		{
			 

		});
	}

}
