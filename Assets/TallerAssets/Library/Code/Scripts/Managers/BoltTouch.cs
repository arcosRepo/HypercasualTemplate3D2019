using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Lean.Touch; 
using UnityEngine.Assertions;
using Bolt;

namespace Taller
{
    
    [System.Serializable]
    public class BoltTouch : MonoBehaviour
    {
       public bool debugLog;
        private void OnEnable()
        {

            LeanTouch.OnFingerTap += LeanTouch_OnFingerTap; ; 
            LeanTouch.OnFingerSwipe += LeanTouch_OnFingerSwipe;
            LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
            LeanTouch.OnFingerExpired += LeanTouch_OnFingerExpired;
            LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
            LeanTouch.OnFingerUpdate += LeanTouch_OnFingerUp;
            LeanTouch.OnGesture += LeanTouch_OnGesture; ; 

        }

      
        private void OnDisable()
        {

            LeanTouch.OnFingerTap -= LeanTouch_OnFingerTap; ;
            LeanTouch.OnFingerSwipe -= LeanTouch_OnFingerSwipe;
            LeanTouch.OnFingerDown -= LeanTouch_OnFingerDown;
            LeanTouch.OnFingerExpired -= LeanTouch_OnFingerExpired;
            LeanTouch.OnFingerUp -= LeanTouch_OnFingerUp;
            LeanTouch.OnFingerUpdate -= LeanTouch_OnFingerUp;
            LeanTouch.OnGesture -= LeanTouch_OnGesture;
        }

        

        private void LeanTouch_OnFingerUp(LeanFinger obj)
        {
            LeanTouch_Listener(obj, "_OnFingerUp");
        }

        private void LeanTouch_OnFingerExpired(LeanFinger obj)
        {
            LeanTouch_Listener(obj, "_OnFingerExpired");
        }

        private void LeanTouch_OnFingerDown(LeanFinger obj)
        {
            LeanTouch_Listener(obj, "_OnFingerDown");
        }

        private void LeanTouch_OnFingerTap(LeanFinger obj)
        {
            LeanTouch_Listener(obj, "_OnFingerTap");
        }

        private void LeanTouch_OnFingerSwipe(LeanFinger obj)
        {
            LeanTouch_Listener(obj, "_OnFingerSwipe");
        }

        private void LeanTouch_OnGesture(List<LeanFinger> obj)
        {
            if (gameObject == null)
            {
                Debug.LogError("You must put this with your Graph");
                return;

            }
        //    CustomEvent.Trigger(gameObject, "_OnGesture", obj);

        }


        private void LeanTouch_Listener(LeanFinger obj,string TriggerName)
        {
            if(gameObject==null)
            {
                Debug.LogError("You must put this with your Graph");
                return;

            }
            if(debugLog)
            Debug.Log("TriggerName");
            CustomEvent.Trigger(gameObject, TriggerName, obj);
           
           
        }

    }


}