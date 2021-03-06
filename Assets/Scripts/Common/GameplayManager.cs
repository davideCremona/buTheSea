﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using POLIMIGameCollective;
/// <summary>
/// The GameplayManager deals with the major coordination inside the gameplay scene. Changes scene and initialized all GameObjects Pools
/// </summary>
public class GameplayManager : MonoBehaviour {



	public string m_towerDefenseSceneName = "TowerDefense";
	public string m_platformSceneName = "Platform";

	// Use this for initialization
	void Start () {
		//Make the music start
		//MusicManager.Instance.PlayMusic ("GameplayMusic");
		// Start listening in order to change scene when needed
		EventManager.StartListening ("PassToPlatformScene", GoToPlatformScene);
		// Start listening to the GameOverScreen Event
		EventManager.StartListening("GameOverScreen", GoToGameOverScene);
		EventManager.StartListening ("MenuScreen",GoToMenu);
		//EventManager.StartListening ("PassToTowerDefenseScene",GoToTowerDefenseScene);

		EventManager.StartListening ("Entity_Player_died", GoToTowerDefenseScene);
		EventManager.StartListening ("Entity_Treasure_died", GoToTowerDefenseScene);
		EventManager.StartListening ("EndAction_PlayerWins", GoToTowerDefenseScene);

	}

	// Update is called once per frame
	void Update () {}

	void GoToTowerDefenseScene(){
		MusicManager.Instance.StopAll ();
		MusicManager.Instance.PlayMusic ("GameplayMusic");
		SceneManager.LoadScene (m_towerDefenseSceneName);
	}


	void GoToPlatformScene(){
		SavedInfo.instance.setNotFirstSceneAnymore ();
		//Debug.Log ("Not First scene anymore");
		MusicManager.Instance.StopAll();
		MusicManager.Instance.PlayMusic ("PlatformMusic");
		SceneManager.LoadScene (m_platformSceneName);

	}

	void GoToGameOverScene(){
		SceneManager.LoadScene ("GameOverScene");

	}

	void GoToMenu(){
		SceneManager.LoadScene ("Menu");
	}

}
