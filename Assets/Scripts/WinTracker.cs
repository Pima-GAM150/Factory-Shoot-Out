using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinTracker : MonoBehaviour
{
    public int playersLeftAlive = 0;
    public PhotonView lastPlayerAlive = null;


    void Update()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Wait());
        foreach ( PhotonView player in NetworkedObjects.find.Players)
        {
            
            if (player.GetComponent<PlayerMovement>().alive)
            {
                lastPlayerAlive = player;
                playersLeftAlive++;
            }
        }

        if (playersLeftAlive == 1)
        {
            winnersCrown();
            //SceneManager.LoadScene(Random.Range(3, 6));
            //gameObject.GetComponent<lastPlayerAlive>
        }
    }
    public void winnersCrown()
    {
        print("Winner!");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }
}
