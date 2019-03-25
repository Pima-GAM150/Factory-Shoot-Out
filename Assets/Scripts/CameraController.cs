using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
	public PlayerAppearance appearance;
    // Start is called before the first frame update
    void Start() 
    {
        if(!appearance.photonView.IsMine)
        {
            this.gameObject.SetActive(false);
        }
        else {
        	transform.parent = appearance.transform;
        }
    }
}
