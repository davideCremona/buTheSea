﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//NEEDS TO BE IN ALL SCENES!!

public class SavedInfo : MonoBehaviour {

	public static SavedInfo instance;


	bool very_first_scene=true;

	private int player_water_resource=0;
	private int player_sand_resource=0;
	private int current_level=0;

	//GameObjects call this class method when they born in order to initialize themselves.
	//Every GameObject to be initialized call its corresponding method offered by this Singletor, static class

	//Tile informations
	private Dictionary<int, BuildableEnum> tiles_informations = new Dictionary<int, BuildableEnum>();

	// Tower Buttons informations
	private Dictionary<BuildableEnum, int> tower_buttons_informations = new Dictionary <BuildableEnum, int>();

	//



	void Awake(){
		if (instance== null) {
			DontDestroyOnLoad (this.gameObject); //Such that my object will persist between different scenes
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		Debug.Log ("Still alive");
	}

	//Tells the SavedInfo class that when it's no more the first scene

	public void setNotFirstSceneAnymore(){
		very_first_scene=false;
	}
	//Tells the SavedInfo class that when it's no more the first scene

	public bool isFirstScene(){
		return very_first_scene;
	}






	//Save Information Methods: Everything at the end

	public void SaveTile(int tile_id, BuildableEnum building){
		tiles_informations.Add (tile_id, building);
	}
		

	public void SaveTowerButton(BuildableEnum button_type, int number_of_towers){
		tower_buttons_informations.Add (button_type,number_of_towers);
	}

	public void SavePlayerResources(int sand, int water){
		player_sand_resource = sand;
		player_water_resource = water;
	}


	public void SaveLevel(int level_number){
		current_level = level_number;
	}


		


	 // Infromation Retrieval methods:


	public BuildableEnum LoadTileInformation(int tile_id){
		BuildableEnum building = tiles_informations [tile_id];
		return building;
	}

	//Each button call this with a different type: everyone with its own
	public int LoadTowerButtonInformation(BuildableEnum button_type){
		int number_of_tower_stored = tower_buttons_informations [button_type];
		return number_of_tower_stored;
	}

	public int LoadSandResource(){
		return player_sand_resource;
	}


	public int LoadWaterResource(){
		return player_water_resource;
	}

	public int LoadCurrentLevel(){
		return current_level;
	}







	// Last thing to do: check it out how this does work for the resources. Check out the ResourcesManager
}