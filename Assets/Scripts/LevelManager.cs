using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _instance;

    public static LevelManager Instance
    {
        get { return _instance; }
    }

    #endregion

    [Tooltip("The levels that are avaialble for the game.")]
    [SerializeField]
    List<Level> _avaliableLevels = new List<Level>();

    [Tooltip("The levels that are avaialble for the game.")]
    [SerializeField]
    GameObject emptyPaddlePrefab;

    [Tooltip("The levels that are avaialble for the game.")]
    [SerializeField]
    GameObject emptyBallPrefab;


    private Level _currentLevel;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            UpdateLevelList();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void UpdateLevelList()
    {
        _avaliableLevels = Resources.LoadAll("ScriptableObjects/Levels", typeof(Level)).Cast<Level>().ToList();
        if (_avaliableLevels.Count == 0)
        {
            GameManager.Instance.DeclareError(Session.ErrorType.CantLoadAssets);
        }

    }

    public void SelectLevel(int levelID)
    {
        for (int i = 0; i < _avaliableLevels.Count; i++)
        {
            if (_avaliableLevels[i].levelID == levelID)
            {
                _currentLevel = _avaliableLevels[i];
            }
        }
        if (_currentLevel == null)
        {
            GameManager.Instance.DeclareError(Session.ErrorType.CantLoadAssets);
        }
    }



    public void AssembleCurrentLevel()
    {
        //Initialize to full transparency
        Color pixelColor = new Color(0, 0, 0, 0);

        for (int i = 0; i < _currentLevel.heatmap.width; i++)
        {
            for (int y = 0; y < _currentLevel.heatmap.height; y++)
            {
                pixelColor = _currentLevel.heatmap.GetPixel(i, y);
                int itemID = GetBlockIDFromColor(pixelColor);


            }
        }

    }



    //I need a Brick Dictionary
    List<ColorIDItem> knownColors = new List<ColorIDItem>();

    int GetBlockIDFromColor(Color currentPixelColor)
    {
        int id = -1;
        for (int i = 0; i < knownColors.Count; i++)
        {
            if (currentPixelColor == knownColors[i].color)
            {
                id = knownColors[i].objectID;
            }
        }

        return id;
    }

}

struct ColorIDItem
{
    public Color color;
    public int objectID;
}


