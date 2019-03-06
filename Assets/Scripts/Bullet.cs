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

    public BulletCollision bulletCollision;

    void FixedUpdate() {

        body.velocity = this.transform.right * speed;
    }

}
