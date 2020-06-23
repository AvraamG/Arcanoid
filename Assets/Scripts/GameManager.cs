using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    #endregion

    private Session _session;

    private Avatar _currentAvatar;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCurrentAvatar(int avatarID)
    {

    }

    public void StartNewGame()
    {
        _session = new Session();
        _session.status = Session.Status.InGamePlay;
        _session.collectedPoints = 0;

    }
}
