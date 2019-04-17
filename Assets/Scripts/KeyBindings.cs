using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBindings : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI shoot, reload, barrel, up, down, left, right;

    private GameObject currentKey;

    private Color normal = new Color32(225, 246, 179, 255);
    private Color selected = new Color32(179, 188, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Shoot", KeyCode.Mouse0);
        keys.Add("Reload", KeyCode.Mouse1);
        keys.Add("Barrel", KeyCode.Space);
        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);

        shoot.text = keys["Shoot"].ToString();
        reload.text = keys["Reload"].ToString();
        barrel.text = keys["Barrel"].ToString();
        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;

    }
}
