using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun, IPunObservable
{
    public float speed;
    /*float x;
    float y;*/

    public Transform appearance;
    public Transform target;
    Vector3 lastSynchedPos;

    //bool Shooting;
    //public Rigidbody2D body;
    public Animator animator;
    //float timer;
    //public float trigger;
    void Start()
    {
        animator.SetBool("Shoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            target.Translate(x, y, 0f);

            if (!NetworkedObjects.find.world.bounds.Contains(target.position))
            {
                target.position = NetworkedObjects.find.world.bounds.ClosestPoint(target.position);
            }
            appearance.position = target.position;
        }

        /*if (x < 0)
        {
            target.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (x > 0)
        {
            target.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Shoot", true);
        }
        if(animator.GetBool("Shoot", true))
        {
            timer += Time.time;
            if (timer > trigger)
            {
                animator.SetBool("Shoot", false);
            }
        }*/
    }

    public void OnPhotonSerializeView( PhotonStream stream, PhotonMessageInfo info)
    {
        if( stream.IsWriting)
        {
            if( lastSynchedPos != target.position)
            {
                lastSynchedPos = target.position;

                stream.SendNext(target.position);
            }
        }
        else
        {
            target.position = (Vector3)stream.ReceiveNext();
        }
    }
}
