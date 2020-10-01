using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Lean.Touch;
using Taller;
using DG.Tweening;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class RoundOverUI : MonoBehaviour
{
	public TouchTypes StartTouch;
	private bool bClicked;
	private CanvasGroup canvasGroup;
	public float fadeTime = 1;
 
    public GameObject childRoundOver;
	private bool bCanRestart;

    private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
			canvasGroup = GetComponentInChildren<CanvasGroup>();
		childRoundOver = transform.GetChild(0).gameObject;
		childRoundOver.SetActive(false);

	}
	// Start is called before the first frame update
	protected virtual void OnEnable()
	{
		// Hook into the events we need
		LeanTouch.OnFingerDown += OnFingerDown;
		LeanTouch.OnFingerUp += OnFingerUp;
		LeanTouch.OnFingerTap += OnFingerTap;
		LeanTouch.OnFingerSwipe += OnFingerSwipe;
 
        GameManager.OnGamestateChange += GameManager_OnGamestateChange;
        GameManager.OnRoundOver += GameManager_OnRoundOver; ;
	}

  

    protected virtual void OnDisable()
	{
		// Unhook the events
		LeanTouch.OnFingerDown -= OnFingerDown;
		LeanTouch.OnFingerUp -= OnFingerUp;
		LeanTouch.OnFingerTap -= OnFingerTap;
		LeanTouch.OnFingerSwipe -= OnFingerSwipe;
 		GameManager.OnRoundOver -= GameManager_OnRoundOver;
		GameManager.OnGamestateChange -= GameManager_OnGamestateChange;

	}

	public void OnFingerDown(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerDown) RestartGame();
	}



	public void OnFingerUp(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerUp) RestartGame();
	}

	public void OnFingerTap(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerTap) RestartGame();
	}

	public void OnFingerSwipe(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerSwipe) RestartGame();
	}

	private void GameManager_OnGamestateChange(EGameStates Param1)
	{
		if(Param1!=EGameStates.RoundOver)return;
		childRoundOver.SetActive(true);
		canvasGroup?.DOFade(1, fadeTime).OnComplete(() =>
		{
			Destroy(canvasGroup);

			bCanRestart = true;
		});
	}
	private void GameManager_OnRoundOver()
	{
		print("RoundOver");

		

		
	}

	private void RestartGame()
	{
		if(!bCanRestart)return;
		if (bClicked) return;
		bClicked = true;

		GameManager.Instance.RestartGame();

		 
	}

}

 
