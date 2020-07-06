using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float maxMovementDistance;


    const float positionY = -4.15f;
    const float positionZ = 1f;

    public float movementSpeed = 0.9f;



    void Move()
    {
        //TODO Calculate the offset and move it

        float paddleShift;
        float leftClamp = 0;
        float rightClamp = 768;
        float mousePositionPixels = Mathf.Clamp(Input.mousePosition.x, leftClamp, rightClamp);
        float mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionPixels, this.transform.position.y, this.transform.position.z)).x;


        float distance = (mousePositionWorld - this.transform.position.x);


        mousePositionWorld = (this.transform.position.x + distance);


        // this.transform.position = new Vector3(mousePositionWorld, positionY, positionZ);
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePositionWorld, positionY, positionZ), 0.2f);




    }

    private void ChangePaddleSize(int size)
    {

        this.transform.localScale = new Vector2(size, this.transform.localScale.y);
        CalculateMaxDistance();
    }

    private void CalculateMaxDistance()
    {
        maxMovementDistance = Camera.main.orthographicSize + this.transform.localScale.x / 2;

    }


    private void OnEnable()
    {
        ChangePaddleSize(1);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }


}
