using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool Shooting;
    float horiz;
    float vert;
    public float speed;
    public Rigidbody2D body;
    public Animator animator;
    public Transform character;
    float timer;
    public float trigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal") * speed;
        vert = Input.GetAxis("Vertical") * speed;
        if (body.velocity.magnitude > 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if (horiz < 0)
        {
            character.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (horiz > 0)
        {
            character.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetButtonDown("Shoot"))
        {
            animator.SetBool("Shoot", true);
        }
        /*if(animator.GetBool("Shoot", true))
        {
            timer += Time.time;
            if (timer > trigger)
            {
                animator.SetBool("Shoot", false);
            }
        }*/
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horiz * speed, vert * speed);
    }
}
