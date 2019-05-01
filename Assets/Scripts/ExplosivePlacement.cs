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
                    numberOfExplosivesPlaced++;
                    ShownBullets.find.BarrelPlaced(numberOfExplosivesPlaced);
                    SpawnExplosive();
                    
                }
            }

        }
    }

    //[PunRPC]
    public void SpawnExplosive()
    {
        GameObject barrel = PhotonNetwork.Instantiate("Explosive", position.position, Quaternion.identity, 0);

        barrel.GetComponent<PhotonView>().RPC("SetColor", RpcTarget.AllBuffered, GetComponent<PlayerAppearance>().order);
    }
}
