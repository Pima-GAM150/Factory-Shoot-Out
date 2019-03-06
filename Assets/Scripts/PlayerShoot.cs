using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShoot : MonoBehaviourPun
{
    public Transform spawnTarget;
    public Bullet BulletPrefab;
    public Camera playerCamera;
    public Rigidbody2D body;
    public Animator animator;
    public float timer;
    public float maxTime;
    public bool shooting;
    public float NumberofBullets;
    public float BulletsShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        if(Input.GetButtonDown("Fire1"))
        {
            if (BulletsShot < NumberofBullets)
            {
                animator.SetBool("Shoot", true);
                gameObject.GetComponent<PlayerMovement>().speed = 0;
                BulletsShot = 1+BulletsShot;
                Vector3 worldMousePos = playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

                photonView.RPC("SpawnBullet", RpcTarget.All, (Vector2)worldMousePos);
                shooting = true;
            }   
        }
        if (Input.GetButtonDown("Fire2"))
        {
            BulletsShot = 0;
        }

        if (shooting == true)
        {
            timer += Time.deltaTime;
        }
        if (timer > maxTime)
        {
            animator.SetBool("Shoot", false);
            gameObject.GetComponent<PlayerMovement>().speed = 10;
            timer = 0;
            shooting = false;
        }
    }

    [PunRPC]
    public void SpawnBullet( Vector2 target )
    {
        Bullet newBullet = Instantiate<Bullet>(BulletPrefab, spawnTarget.position, Quaternion.identity);
        Vector2 dirToTarget = (target - (Vector2)spawnTarget.transform.position).normalized;

        newBullet.transform.right = (Vector3)dirToTarget;
    }
}
