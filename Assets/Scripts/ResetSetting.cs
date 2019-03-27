using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSetting : MonoBehaviour
{
	public string key;
	public int val;

	void Start() {
		PlayerPrefs.SetInt( key, val );
	}
}
