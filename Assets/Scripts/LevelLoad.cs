using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    public void Load(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
