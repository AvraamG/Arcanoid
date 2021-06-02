using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Ball : MonoBehaviour
{


    Rigidbody2D _rigidBody;
    Animator _animator;

    [Tooltip("The speed the ball is going to have on Y Axis when released.")]
    [SerializeField]
    const float initialYForce = 400;
    [Tooltip("The speed the ball is going to have on X Axis when released.")]
    [SerializeField]
    const float initialXForce = 0f;

    public int damageModifier = 1;

    private void OnEnable()
    {
        InitializeBall();
    }

    void InitializeBall()
    {
        _rigidBody = this.GetComponent<Rigidbody2D>();
        _rigidBody.isKinematic = true;

        _animator = this.GetComponent<Animator>();
    }
    public void ReleaseCurrentBall()
    {
        _rigidBody.isKinematic = false;
        _rigidBody.AddForce(new UnityEngine.Vector2(initialXForce, initialYForce));

    }

    public void PaddleHit(float xForce)
    {

    }

    bool gameHasStarted;
    private void Update()
    {
        if (!gameHasStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ReleaseCurrentBall();
                gameHasStarted = true;
            }



            float positionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            const float positionY = -4.15f;
            const float positionZ = 1f;
            this.transform.position = new Vector3(positionX, positionY + 1, positionZ);



        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Paddle")
        {
            float offset;

            Vector2 pointOfContact = collision.contacts[0].point;

            _rigidBody.velocity = Vector2.zero;


            offset = pointOfContact.x - collision.gameObject.transform.position.x;
            if (offset > 0)
            {
                Vector2 force = new Vector2((Mathf.Abs(offset * 400)), initialYForce);
                _rigidBody.AddForce(force);

            }
            else
            {
                Vector2 force = new Vector2(-(Mathf.Abs(offset * 400)), initialYForce);
                _rigidBody.AddForce(force, ForceMode2D.Force);
            }

            _animator.SetTrigger("Wobble");


        }
        else if (collision.gameObject.tag == "Brick")
        {
            Debug.Log("I have hit a Brick");

            collision.gameObject.GetComponent<Brick>().TakeDamage(damageModifier);
        }

        //TODO Wobble


    }
}
