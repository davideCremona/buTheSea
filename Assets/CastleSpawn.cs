﻿using UnityEngine;
using System.Collections;

public class CastleSpawn : MonoBehaviour {

	// Use this for initialization
	// Triggers the event used by the tiles in order to spawn the right objects.
	void Start () {
		EventManager.TriggerEvent ("ArcherCastle");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
