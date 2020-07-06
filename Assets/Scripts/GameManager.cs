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
    public Session Session
    {
        get { return _session; }

    }

    [SerializeField]
    private Player _currentPlayer;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InitializeGame();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void InitializeGame()
    {
        _session = new Session();
        _session.status = Session.Status.InGamePlay;
        _session.collectedPoints = 0;
        _session.sessionErrors = new List<Session.ErrorType>();

        GameObject player = new GameObject("Player");
        player.transform.parent = this.transform;
        player.AddComponent<Player>();
        _currentPlayer = player.GetComponent<Player>();

        Debug.Log("Game initialized");
    }

    public void DeclareError(Session.ErrorType error)
    {
        _session.sessionErrors.Add(error);
    }

    public void StartCurrentLevel()
    {
        //pass the info to the levelmanager of what to spawn for paddle and ball
        //   LevelManager.Instance.st
    }
    public void SetPlayerAvatar(Avatar avatar)
    {
        _currentPlayer.currentAvatar = avatar;
    }
}
