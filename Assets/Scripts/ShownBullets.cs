using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShownBullets : MonoBehaviour
{
    public GameObject[] bullets;
    void Start()
    {
        
    }

    public void BulletShot()
    {
        if (bullets[1].activeSelf == true && bullets[2].activeSelf == true && bullets[3].activeSelf == true)
        {
            print("turned off bullet 1");
        }
        if (bullets[1].activeSelf == false && bullets[2].activeSelf == true && bullets[3].activeSelf == true)
        {
            print("turned off bullet 2");
        }
        if (bullets[1].activeSelf == false && bullets[2].activeSelf == false && bullets[3].activeSelf == true)
        {
            print("turned off bullet 3");
        }
    }
}
