using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    void Move()
    {
        float positionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        const float positionY = 1f;
        const float positionZ = 1f;

        this.transform.position = new Vector3(positionX, positionY, positionZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
