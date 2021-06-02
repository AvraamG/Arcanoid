using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Session
{
    public enum Status
    {
        Error,
        InSettingsMenu,
        InGamePlay,
        InEndScreen
    }

    public enum ErrorType
    {
        None,
        CantLoadAssets,

    }

    public List<ErrorType> sessionErrors;
    public Status status;
    public int collectedPoints;

    public Avatar currentAvatar;

}
