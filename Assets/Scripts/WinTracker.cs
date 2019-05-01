using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinTracker : MonoBehaviour
{
    public int playersLeftAlive = 0;
    public PhotonView lastPlayerAlive = null;
    public int wait;


   /* void Update()
    {
        DontDestroyOnLoad(gameObject);
        
        foreach ( PhotonView player in NetworkedObjects.find.Players)
        {
            
            if (player.GetComponent<PlayerMovement>().alive == false)//&& playersLeftAlive > 0)
            {
                lastPlayerAlive = player;
                playersLeftAlive--;
                print(playersLeftAlive);
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
        print("Waiting for" + wait + "seconds");
        yield return new WaitForSeconds(wait);
    }*/
}
