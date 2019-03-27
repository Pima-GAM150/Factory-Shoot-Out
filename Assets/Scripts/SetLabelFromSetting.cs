using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLabelFromSetting : MonoBehaviour
{
	public Text label;
	public string settingKey;

	void Start() {
		label.text = PlayerPrefs.GetInt( settingKey ).ToString();
	}
}
