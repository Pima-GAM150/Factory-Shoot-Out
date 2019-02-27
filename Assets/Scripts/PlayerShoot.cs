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
            Vector3 worldMousePos = playerCamera.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, playerCamera.nearClipPlane ) );

            print("Shooting at position " + worldMousePos + " with mouse pos " + Input.mousePosition);

            photonView.RPC( "SpawnBullet", RpcTarget.All, (Vector2)worldMousePos, body.velocity );
        }
    }

    [PunRPC]
    public void SpawnBullet( Vector2 target, Vector2 vel )
    {
        print("Spawning bullet with target " + target);
        Bullet newBullet = Instantiate<Bullet>(BulletPrefab, spawnTarget.position, Quaternion.identity);
        newBullet.baseVel = vel;
        print("New bullet base vel = " + newBullet.baseVel);
        Vector2 dirToTarget = (target - (Vector2)spawnTarget.transform.position).normalized;

        newBullet.transform.right = (Vector3)dirToTarget;
    }
}
