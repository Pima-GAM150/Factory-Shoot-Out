using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSettings : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
 
    public float setSpeed = 0;
    public float setBulletLimit = 0;
    public float setExplosiveMax = 0;
    public float setWinLimit = 0;

    public float oldSpeed;
    public float oldBulletLimit;
    public float oldExplosiveMax;
    public float oldWinLimit;

    public void SettingsSpeed( float setSpeed)
    {
        oldSpeed = setSpeed;
    }
    
    public void SettingsBulletLimit( float setBulletLimit)
    {
        oldBulletLimit = setBulletLimit;
    }

    public void SettingsExplosiveMax( float setExplosiveMax)
    {
        oldExplosiveMax = setExplosiveMax;
    }

    public void SettingsWinLimit( float setWinLimit)
    {
        oldWinLimit = setWinLimit;
    }
}
