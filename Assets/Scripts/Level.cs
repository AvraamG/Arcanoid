using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Level : ScriptableObject
{
    public Vector3 paddleStartingPosition;
    public Vector3 ballStartingPosition;
    public Vector3 ballStartingForce;


    public Texture2D heatmap;


    //TODO I encapsulate stuff with private setters
}

//Cheat Sheet

//Black is empty space

//I need a Color to Int (ID) so the prefab manager can work
