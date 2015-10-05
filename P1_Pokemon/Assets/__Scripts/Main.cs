﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public struct Pokeball_Info{
	public int x, y;
	public PokemonObject place_pokemon;
	public Pokeball_Info(int x_in, int y_in, PokemonObject place_pokemon_in) { this.x = x_in; this.y = y_in;
	this.place_pokemon = place_pokemon_in;}
}
public class Main : MonoBehaviour {

//	var mainMusic : AudioClip;
	static public Main S;
	
	public bool inDialog = false;
	public bool printDialog = false;
	public bool paused = false;
	public List<Pokeball_Info> player_pokeball = new List<Pokeball_Info>();
	public List<Pokeball_Info> opponent_pokeball = new List<Pokeball_Info>();
	public bool playerTurn = true, inTurn = false, choiceMade = false;
	void Awake(){
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		//not already talking and try to get menu and not already paused
		if(Player.S.inScene0){
			if(playerTurn && Player.S.OpeningDialog && !inTurn){
				inTurn = true;
				paused = true;
				Turn_Choice_Menu.S.gameObject.SetActive(true);
			}
			if(!inDialog && Input.GetKeyDown(KeyCode.Return) && !paused && Player.S.inScene0){
				Menu.S.gameObject.SetActive(true);
				paused = true;
			}
			//exit menu when s is pushed
			else if(paused && Menu.S.gameObject.activeSelf && Input.GetKeyDown(KeyCode.S) && !Items_Menu.S.gameObject.activeSelf 
					&& !Pokemon_Menu.S.gameObject.activeSelf && !Turn_Choice_Menu.S.gameObject.activeSelf){
				Menu.S.gameObject.SetActive(false);
				paused = false;
			}
			else if(inDialog && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)) && Player.S.ChoosingPokemon){
				Pokemon_Choose.S.gameObject.SetActive(true);
				Dialog.S.HideDialogBox();
				paused = true;
			}
			else if(!inDialog && Input.GetKeyDown(KeyCode.S) && Player.S.ChoosingPokemon){
				Pokemon_Choose.S.gameObject.SetActive(false);
				Player.S.speakDictionary["Pokemon_Choose_Table"] = -1;
				Player.S.playerSpeaking = null;
				Player.S.ChoosingPokemon = false;
				paused = false;
			}
			else if(inDialog && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)) && Player.S.Healing_Pokemon){
				Heal_Pokemon.S.gameObject.SetActive(true);
				Dialog.S.HideDialogBox();
				paused = true;
			}
			else if(!inDialog && Input.GetKeyDown(KeyCode.S) && Player.S.Healing_Pokemon){
				Heal_Pokemon.S.gameObject.SetActive(false);
				Player.S.speakDictionary["Forward_Clerk"] = -1;
				Player.S.playerSpeaking = null;
				Player.S.Healing_Pokemon = false;
				paused = false;
			}
			else if(inDialog && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)) && Player.S.Mart_Options){
				Mart_Options.S.gameObject.SetActive(true);
				Dialog.S.HideDialogBox();
				paused = true;
			}
			else if(!inDialog && Input.GetKeyDown(KeyCode.S) && Player.S.Mart_Options){
				Mart_Options.S.gameObject.SetActive(false);
				Player.S.speakDictionary["Checkout_Front"] = 4;
				Player.S.playerSpeaking = null;
				Player.S.Mart_Options = false;
				paused = false;
			}
			else if(Input.GetKeyDown(KeyCode.S) && Items_Menu.S.gameObject.activeSelf ){
			
			}
		}
	}
}
