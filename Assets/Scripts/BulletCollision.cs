using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletCollision : MonoBehaviour
{
	public float maxLifetime;

	void Start() {
		Destroy( this.gameObject, maxLifetime );
	}

	void OnTriggerEnter2D( Collider2D col ) {
		print( "Bullet hit " + col.gameObject.name );

		Player hitPlayer = col.GetComponent<Player>();

		if( hitPlayer ) {
			if( hitPlayer.photonView.IsMine ) {
				return;
			}
		}

		Destroy( this.gameObject );
	}
}
