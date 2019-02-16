using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerColor : MonoBehaviourPun
{
    public Sprite[] playerColors;
    public Sprite currentColor { get; set; }
    
    [PunRPC]
    public void SetColor( int order)
    {
        currentColor = playerColors[order];
    }
}
