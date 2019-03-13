using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class Player : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    public AudioListener Audio;
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        NetworkedObjects.find.AddPlayer(this.photonView); // when the player is created, add it to a list of all players on the singleton

        if (!this.photonView.IsMine)
        {
            Destroy(Audio);
        }

    }
}