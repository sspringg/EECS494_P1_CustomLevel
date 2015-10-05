using UnityEngine;
using System.Collections;

public class SpacesCounter : MonoBehaviour {
	public static SpacesCounter S;
	// Use this for initialization
	void Awake(){
		S = this;
	}
	
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		GUIText mytext;
		mytext = GameObject.Find ("SpacesCounter").GetComponent<GUIText> ();
		mytext.text = "SPACES MOVED : " + Player.S.spacesMoved + '/' + Player.S.moveLim;

		if (Player.S.spacesMoved >= Player.S.moveLim){
			Player.S.moving = false;
			Main.S.playerTurn = false;
			Main.S.inTurn = false;
			Main.S.choiceMade = false;
			Main.S.paused = true;
			gameObject.SetActive(false);	
		}
	}
}
