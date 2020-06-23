using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Session
{
    public enum Status
    {
        InSettingsMenu,
        InGamePlay,
        InEndScreen
    }

    public Status status;
    public int collectedPoints;

}
