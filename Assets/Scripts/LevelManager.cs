using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _instance;

    public static LevelManager Instance
    {
        get { return _instance; }
    }

    #endregion


    [SerializeField]
    List<Level> levels;

    Level currentLevel;


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


    //Level has the info that I need to spawn stuff. 



    void AssembleLevel()
    {
        //Initialize to full transparency
        Color pixelColor = new Color(0, 0, 0, 0);

        for (int i = 0; i < currentLevel.heatmap.width; i++)
        {
            for (int y = 0; y < currentLevel.heatmap.height; y++)
            {
                pixelColor = currentLevel.heatmap.GetPixel(i, y);
                int itemID = GetBlockIDFromColor(pixelColor);
                //SpawnManager.SpawnItem(itemID)


            }
        }

    }

    //I need a Brick Dictionary
    List<KnownColor> knownColors = new List<KnownColor>();

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

struct KnownColor
{
    public Color color;
    public int objectID;
}


