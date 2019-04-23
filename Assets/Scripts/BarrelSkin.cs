using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BarrelSkin : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public CircleCollider2D circleCollider;

    public void TurnOnCollider()
    {
        circleCollider.enabled = true;
    }

    public void DoneExploding()
    {
        PhotonNetwork.Destroy(transform.parent.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        PlayerBody hitBody = col.GetComponent<PlayerBody>();
        if (hitBody)
        {
            hitBody.movement.Hit();


        }
    }
}
