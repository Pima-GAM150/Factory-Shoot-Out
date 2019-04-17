using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Explosion : MonoBehaviour
{
    public Rigidbody2D hitbox;
    public Animator animator;
    public CapsuleCollider2D box;
    public CircleCollider2D ExplosionBox;
    public void OnTriggerEnter2D(Collider2D col)
    {
        PlayerBody hitBody = col.GetComponent<PlayerBody>();
        Explosion hitBomb = col.GetComponent<Explosion>();
        if (hitBody)
        {
            hitBody.movement.Hit();


        }
        if (hitBomb)
        {
            Hit();
        }
    }
        public void Hit()
    {
        animator.SetBool("Boom", true);
        FindObjectOfType<Audiomanager>().Play("Explosion");
        box.enabled = false;
        ExplosionBox.enabled = true;
    }
    public void DoneExploding()
    {
        PhotonNetwork.Destroy(this.gameObject);
    }
}
