using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() 
    {
        if(!GetComponentInParent<PhotonView>().IsMine)
        {
            this.gameObject.SetActive(false);
        }
    }
}
