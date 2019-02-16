using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;

public class NetworkedObjects : MonoBehaviour
{
    public BoxCollider world;

    [HideInInspector] public List<PhotonView> Players = new List<PhotonView>();

    public static NetworkedObjects find;

    private void Awake()
    {
        find = this;        
    }
    // Update is called once per frame
    private void Start()
    {
        float xRange = UnityEngine.Random.Range(-world.bounds.extents.x, world.bounds.extents.x);
        float yRange = UnityEngine.Random.Range(-world.bounds.extents.y, world.bounds.extents.y);

        Vector3 spawnPos = world.bounds.center + new Vector3(xRange, yRange, 0f);
        PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity, 0);
    }
    public void AddPlayer( PhotonView player)
    {
        Players.Add(player);

        if(PhotonNetwork.IsMasterClient)
        {
            player.RPC("SetColor", RpcTarget.AllBuffered, Players.Count - 1);
        }
    }
}
