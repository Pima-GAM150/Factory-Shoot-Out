using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinTracker : MonoBehaviour
{
    int playersLeftAlive = 0;
    Player lastPlayerAlive = null;

    void Update()
    {
 
        foreach( Player player in NetworkedObjects.find.Players)
        {
            if(player.GetComponent<PlayerMovement>().alive)
            {
                lastPlayerAlive = player;
                playersLeftAlive++;
            }

            if ( playersLeftAlive == 1)
            {
                SceneManager.LoadScene(Random.Range(3,6));
            }
        }
    }
}
