using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
	public PlayerMovement player;
    // Start is called before the first frame update
    void Start() 
    {
        if(!player.photonView.IsMine)
        {
            this.gameObject.SetActive(false);
        }
        else {
        	transform.parent = player.appearance;
        }
    }
}
