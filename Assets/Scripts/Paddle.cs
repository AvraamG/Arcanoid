using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Vector3 storedPosition;

    void InitializePaddle()
    {

    }
    void Move()
    {
        //TODO Calculate the offset and move it


        if (storedPosition != Input.mousePosition)
        {
            float positionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            const float positionY = -4.15f;
            const float positionZ = 1f;
            this.transform.position = new Vector3(positionX, positionY, positionZ);
        }


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
