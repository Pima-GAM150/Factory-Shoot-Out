using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun, IPunObservable
{
    public float speed
    {
        get { return _speed; }
        set { _speed = value; print("Set speed to " + value); }
    }
    float _speed;

    public float lerpSpeed;
    /*float x;
    float y;*/

    public Transform appearance;
    Vector3 lastSynchedPos;

    public Rigidbody2D body;
    public CapsuleCollider2D Player;

    //bool Shooting;
    //public Rigidbody2D body;
    public Animator animator;
    //float timer;
    //public float trigger;
    void Start()
    {
        animator.SetBool("Shoot", false);
        Player.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal") * speed;
            float y = Input.GetAxis("Vertical") * speed;

            body.velocity = new Vector2(x, y);
            
            appearance.position = body.transform.position;
        }
        else
        {
            appearance.position = Vector3.Lerp(appearance.position, body.transform.position, lerpSpeed);
        }
    }

    public void OnPhotonSerializeView( PhotonStream stream, PhotonMessageInfo info)
    {
        if( stream.IsWriting)
        {
            stream.SendNext(body.transform.position);
        }
        else
        {
            body.transform.position = (Vector3)stream.ReceiveNext();
        }
    }

    public void Hit()
    {
        Player.enabled = false;
        speed = 0;
        print("Set speed to " + speed);
        animator.SetBool("Dead", true);
    }
}
