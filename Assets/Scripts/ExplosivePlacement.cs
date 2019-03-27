using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExplosivePlacement : MonoBehaviourPun
{
    public Explosion explosivePrefab;
    public float numberOfExplosivesMax;
    public float numberOfExplosivesPlaced;
    public PlayerAppearance appearance;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && gameObject.GetComponent<PlayerMovement>().alive == true)
        {
            if (numberOfExplosivesPlaced < numberOfExplosivesMax)
            {
                photonView.RPC("SpawnExplosive", RpcTarget.All);
                numberOfExplosivesPlaced++;
            }
        }
    }

    [PunRPC]
    public void SpawnExplosive()
    {
        Explosion newExplosion = Instantiate<Explosion>(explosivePrefab, appearance.skin.bulletSpawnLoc.position, Quaternion.identity);
    }
}
