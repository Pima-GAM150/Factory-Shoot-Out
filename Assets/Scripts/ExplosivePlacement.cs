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
        if (Input.GetButtonDown("Jump"))
        {
            if (numberOfExplosivesPlaced < numberOfExplosivesMax)
            {
                photonView.RPC("SpawnBullet", RpcTarget.All, explosivePrefab );
                numberOfExplosivesPlaced++;
            }
        }
    }

    [PunRPC]
    public void SpawnExplosive(Vector2 target)
    {
        Explosion newExplosion = Instantiate<Explosion>(explosivePrefab, appearance.skin.bulletSpawnLoc.position, Quaternion.identity);
    }
}
