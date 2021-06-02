using UnityEngine;


[CreateAssetMenu]
public class Level : ScriptableObject
{

    public int levelID;

    public Texture2D heatmap;
    public Texture2D backGround;
    public Texture2D wall;


    //TODO I encapsulate stuff with private setters
}

//Cheat Sheet

//Black is empty space

//I need a Color to Int (ID) so the prefab manager can work
