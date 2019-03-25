using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerAppearance : MonoBehaviourPun
{
	// old
  // public Sprite[] playerColors;
  // public Sprite currentColor { get; set; }

	// new
	public PlayerSkin[] playerSkins;
	public PlayerSkin skin;

  public Camera playerCam;

  [PunRPC]
  public void SetColor( int order )
  {
  	if( skin ) Destroy( skin.gameObject );

  	skin = Instantiate<PlayerSkin>( playerSkins[order] );
    skin.transform.parent = transform;

    // handle camera
    if( !photonView.IsMine ) {
      playerCam.gameObject.SetActive( false );
    }
    else {
      playerCam.transform.parent = skin.transform;
      playerCam.transform.localPosition = new Vector3( 0f, 0f, playerCam.transform.localPosition.z );
    }
  }
}
