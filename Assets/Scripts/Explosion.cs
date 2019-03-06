﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Rigidbody2D hitbox;
    public Animator animator;
    public CapsuleCollider2D box;
    public void OnTriggerEnter2D(Collider2D col)
    {
        PlayerBody hitBody = col.GetComponent<PlayerBody>();
        if (hitBody)
        {
            hitBody.movement.Hit();

            Destroy(this.gameObject);
        }
    }
        public void Hit()
    {
        animator.SetBool("Boom", true);
        box.enabled = false;
    }
}
