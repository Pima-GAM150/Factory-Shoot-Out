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
    public float Shoottimer;
    public float ShootmaxTime;
    public bool shooting;
    public float Reloadtimer;
    public float ReloadmaxTime;
    public bool Reloading;
    public float NumberofBullets;
    public float BulletsShot;

    public AudioSource reloadSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting == true)
        {
            Shoottimer += Time.deltaTime;
        }
        if (Shoottimer > ShootmaxTime)
        {
            animator.SetBool("Shoot", false);
            shooting = false;

            if( photonView.IsMine )
            {
                gameObject.GetComponent<PlayerMovement>().speed = 10;
            }

            Shoottimer = 0;
        }

        if (!photonView.IsMine) return;

        if(Input.GetButtonDown("Fire1"))
        {
            if (BulletsShot < NumberofBullets&& shooting == false&& Reloading == false)
            {

                gameObject.GetComponent<PlayerMovement>().speed = 0;
                BulletsShot = 1+BulletsShot;
                Vector3 worldMousePos = playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

                photonView.RPC("SpawnBullet", RpcTarget.All, (Vector2)worldMousePos);
            }   
        }
        if (Input.GetButtonDown("Fire2") && shooting == false && Reloading == false )
        {
            // FindObjectOfType<Audiomanager>().Play("Reloading");

            photonView.RPC("ReloadOverNetwork", RpcTarget.All, BulletsShot);
        }
    }

    [PunRPC]
    public void SpawnBullet( Vector2 target )
    {
        animator.SetBool("Shoot", true);
        shooting = true;
        Bullet newBullet = Instantiate<Bullet>(BulletPrefab, spawnTarget.position, Quaternion.identity);
        newBullet.bulletCollision.owner = this;
        Vector2 dirToTarget = (target - (Vector2)spawnTarget.transform.position).normalized;

        newBullet.transform.right = (Vector3)dirToTarget;
    }

    IEnumerator Reload( float bulletsToReload )
    {
        Reloading = true;

        gameObject.GetComponent<PlayerMovement>().speed = 0;

        float bulletsReloaded = 0f;

        while( bulletsReloaded < bulletsToReload)
        {
            reloadSound.Play();
            bulletsReloaded += 1f;

            yield return new WaitForSeconds( 1f / bulletsToReload);
        }

        Reloading = false;

        gameObject.GetComponent<PlayerMovement>().speed = 10;
        print("Set speed to 10");
        BulletsShot = 0;
    }

    [PunRPC]
    public void ReloadOverNetwork( float bulletsToReload )
    {
        StartCoroutine(Reload( bulletsToReload ));
    }
}
