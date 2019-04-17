using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWins : MonoBehaviour
{
    public float wins;
    public Text count;

    void Start()
    {
        wins = 0;
        count.text = "Winds: " + wins.ToString ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
