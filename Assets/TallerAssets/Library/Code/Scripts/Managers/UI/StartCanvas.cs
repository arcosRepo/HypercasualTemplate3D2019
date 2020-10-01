using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Lean.Touch;
using Taller;
using DG.Tweening;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
	public TouchTypes StartTouch;
	private bool bClicked;
	private CanvasGroup canvasGroup;
	public float fadeTime=1;

    private void Awake()
    {
		canvasGroup=GetComponent<CanvasGroup>();
		if(canvasGroup==null)
		   canvasGroup = GetComponentInChildren<CanvasGroup>();

		 
    }
    // Start is called before the first frame update
    protected virtual void OnEnable()
	{
		// Hook into the events we need
		LeanTouch.OnFingerDown += OnFingerDown;
 		LeanTouch.OnFingerUp += OnFingerUp;
		LeanTouch.OnFingerTap += OnFingerTap;
		LeanTouch.OnFingerSwipe += OnFingerSwipe;
		LeanTouch.OnGesture += OnGesture;
	}

	protected virtual void OnDisable()
	{
		// Unhook the events
		LeanTouch.OnFingerDown -= OnFingerDown;
 		LeanTouch.OnFingerUp -= OnFingerUp;
		LeanTouch.OnFingerTap -= OnFingerTap;
		LeanTouch.OnFingerSwipe -= OnFingerSwipe;
		LeanTouch.OnGesture -= OnGesture;
	}

	public void OnFingerDown(LeanFinger finger)
	{
	    if(StartTouch==TouchTypes.OnFingerDown) BeginGame();
	}

	 

	public void OnFingerUp(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerUp) BeginGame();
	}

	public void OnFingerTap(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerTap) BeginGame();
	}

	public void OnFingerSwipe(LeanFinger finger)
	{
		if (StartTouch == TouchTypes.OnFingerSwipe) BeginGame();
	}

	public void OnGesture(List<LeanFinger> fingers)
	{
		 
		
	}

	private void BeginGame()
    {
		if(bClicked)return;
		bClicked=true;

		GameManager.Instance.ChangeGameState(EGameStates.GameBegin);
        canvasGroup?.DOFade(0, fadeTime).OnComplete(() =>
        {
			Destroy(canvasGroup);

			gameObject.SetActive(false);

        });
	}

}
