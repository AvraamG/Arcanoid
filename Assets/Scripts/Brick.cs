using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO not sure if I want a higher level of abstraction than this. 
public class Brick : MonoBehaviour
{
    //Spawn Powerups
    //Check the visuals

    public static Action<Brick> OnBrickHit;
    public static Action<Brick> OnBrickBroken;


    public void TakeDamage(int ammount)
    {

    }
}
