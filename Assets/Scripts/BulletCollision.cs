using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletCollision : MonoBehaviour
{
	public float maxLifetime;

    public PlayerShoot owner;

	void Start() {
		Destroy( this.gameObject, maxLifetime );
	}

	public void OnTriggerEnter2D( Collider2D col ) {
        if (PhotonNetwork.IsMasterClient == false)
        {
            return;
        }
        PlayerBody hitBody = col.GetComponent<PlayerBody>();
        Explosion hitBomb = col.GetComponent<Explosion>();

		
        if(hitBody) {
			if(owner == hitBody.shoot) {
				return;
			}
            hitBody.movement.photonView.RPC("Hit", RpcTarget.All);

            Destroy(this.gameObject);
        }
        if (hitBomb)
        {
            hitBomb.Hit();
            Destroy(this.gameObject);
        }
        if (col.gameObject.name == "World Border")
        {
            Destroy(this.gameObject);
        }
    }
}
