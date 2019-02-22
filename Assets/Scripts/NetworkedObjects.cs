using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;

public class NetworkedObjects : MonoBehaviour
{
    public BoxCollider2D[] spawnBoxes;

    [HideInInspector] public List<PhotonView> Players = new List<PhotonView>();

    public static NetworkedObjects find;

    int seed;
    private void Awake()
    {
        find = this;        
    }
    // Update is called once per frame
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            seed = DateTime.Now.Millisecond + System.Threading.Thread.CurrentThread.GetHashCode();
        }

        BoxCollider2D spawnBox = spawnBoxes[ UnityEngine.Random.Range( 0, spawnBoxes.Length ) ];

        float xRange = UnityEngine.Random.Range(-spawnBox.bounds.extents.x, spawnBox.bounds.extents.x);
        float yRange = UnityEngine.Random.Range(-spawnBox.bounds.extents.y, spawnBox.bounds.extents.y);

        Vector3 spawnPos = spawnBox.bounds.center + new Vector3(xRange, yRange, 0f);
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
