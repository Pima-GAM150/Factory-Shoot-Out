using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExplosivePlacement : MonoBehaviourPun
{
    //public Explosion explosivePrefab;
    public float numberOfExplosivesMax;
    public float numberOfExplosivesPlaced;
    //public PlayerAppearance appearance;
    public Transform position;

    private void Update()
    {

        if (this.photonView.IsMine)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (numberOfExplosivesPlaced < numberOfExplosivesMax)
                {
                    photonView.RPC("SpawnExplosive", RpcTarget.All);
                    numberOfExplosivesPlaced++;
                }
            }

        }
    }

    [PunRPC]
    public void SpawnExplosive()
    {
        PhotonNetwork.Instantiate("Explosive", position.position, Quaternion.identity, 0);
    }
}
