using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShownBullets : MonoBehaviour
{
    public GameObject[] bullets;

    public static ShownBullets find;
    void Start()
    {
        find = this;
    }

    public void BulletShot(int BulletsShot)
    {
        print(BulletsShot);
        foreach (GameObject bullet in bullets)
        {
            bullet.SetActive(true);
        }
        for (int i = 0; i < BulletsShot; i++)
        {
            bullets[i].SetActive(false);
            print("Setting " + i + " to false");
        }
    }

    public void Reload (int BulletsShot)
    {
        foreach (GameObject bullet in bullets)
        {
            bullet.SetActive(true);
        }
    }

}
