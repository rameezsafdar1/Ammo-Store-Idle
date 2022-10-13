using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
using GameAnalyticsSDK;
using Facebook.Unity;

public class Analytics : MonoBehaviour
{
    Dictionary<string, string> purchaseEvent = new Dictionary<string, string>();
    public static Analytics instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GameAnalytics.Initialize();
            if (!FB.IsInitialized)
            {
                FB.Init();
            }
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AFEventStart(string eventName)
    {
        if (!purchaseEvent.ContainsKey(eventName))
        {
            purchaseEvent.Add(eventName, AFInAppEvents.LEVEL_ACHIEVED);
            AppsFlyer.sendEvent("day_start_", purchaseEvent);
        }
    }

    public void AFEventEnd(string eventName)
    {

        if (!purchaseEvent.ContainsKey(eventName))
        {
            purchaseEvent.Add(eventName, AFInAppEvents.LEVEL);
            AppsFlyer.sendEvent("day_end_", purchaseEvent);
        }

    }

}
