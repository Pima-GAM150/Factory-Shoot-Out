using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public Vector3 mouse_pos;
    // public Transform target;
    // public Vector3 object_pos;
    // public float angle;
    public float speed;
    public Rigidbody2D body;

    void FixedUpdate() {
        body.velocity = this.transform.right * speed;
    }

    // void Start()
    // {
    //     speed = speed * Time.deltaTime;
    // }

    // private void Update()
    // {
    //     mouse_pos = Input.mousePosition;
    //     mouse_pos.z = 0f; //The distance between the camera and object
    //     object_pos = Camera.main.WorldToScreenPoint(target.position);
    //     mouse_pos.x = mouse_pos.x - object_pos.x;
    //     mouse_pos.y = mouse_pos.y - object_pos.y;
    //     angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.Euler(0f, 0f, angle);
    //     body.velocity = new Vector3(speed, 0f, 0f);

    // }
}
