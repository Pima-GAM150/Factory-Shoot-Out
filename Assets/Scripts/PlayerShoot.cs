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
    float timer;
    public float maxTime;
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
            timer = Time.time;
            animator.SetBool("Shoot", true);
            gameObject.GetComponent<PlayerMovement>().speed = 0;
            Vector3 worldMousePos = playerCamera.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, transform.position.z ) );

            photonView.RPC( "SpawnBullet", RpcTarget.All, (Vector2)worldMousePos );
            if (timer > maxTime)
            {
                animator.SetBool("Shoot", false);
                gameObject.GetComponent<PlayerMovement>().speed = 10;
            }

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
