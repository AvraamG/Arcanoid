using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Brick : MonoBehaviour
{
    //Spawn Powerups
    //Check the visuals

    protected int hitsToBreak = 3;
    public static Action<Brick> OnBrickHit;
    public static Action<Brick> OnBrickBroken;


    public abstract void TakeDamage(int ammount);

    protected virtual void Recycle()
    {

        this.gameObject.SetActive(false);
    }

    protected virtual void Recycle(float delay)
    {
        StartCoroutine(RecycleAfter(delay));

    }

    protected abstract void UpdateVisuals();


    IEnumerator RecycleAfter(float delay)
    {
        yield return new WaitForSeconds(delay);

    }


}
