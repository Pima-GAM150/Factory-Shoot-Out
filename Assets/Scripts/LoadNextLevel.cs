﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoadNextLevel : MonoBehaviour
{
	void Start() {
		if( PhotonNetwork.IsMasterClient ) {
		    PhotonNetwork.LoadLevel(Random.Range(3, 6));
		}
	}
}