using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For ease of development.
[ExecuteInEditMode]
public class UtilityManager : MonoBehaviour
{
    public static Action OnResolutionChanged;

    #region Singleton
    private static UtilityManager _instance;

    public static UtilityManager Instance
    {
        get { return _instance; }
    }


    #endregion
    Resolution storedResolution;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            storedResolution = Screen.currentResolution;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        DetectResolutionChanged();
    }

    /// <summary>
    /// Checks if the resolution has changed and emmits an event so subscribers can respond to.
    /// </summary>
    private void DetectResolutionChanged()
    {
        if (storedResolution.width != Screen.currentResolution.width)
        {
            if (OnResolutionChanged != null)
            {
                storedResolution = Screen.currentResolution;

                OnResolutionChanged();
            }
        }
    }
}
