using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletCollision : MonoBehaviour
{
	public float maxLifetime;

    public Player Prefab;
	void Start() {
		Destroy( this.gameObject, maxLifetime );
	}

	public void OnTriggerEnter2D( Collider2D col ) {
        PlayerBody hitBody = col.GetComponent<PlayerBody>();

		if(hitBody) {
			if( hitBody.player.photonView.IsMine ) {
				return;
			}
            Prefab.GetComponent<PlayerMovement>().Hit();

            Destroy(this.gameObject);
        }
	}
}
