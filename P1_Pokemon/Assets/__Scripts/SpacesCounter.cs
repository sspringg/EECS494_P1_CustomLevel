using UnityEngine;
using System.Collections;

public class SpacesCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GUIText mytext;
		mytext = GameObject.Find ("SpacesCounter").GetComponent<GUIText> ();
		mytext.text = "SPACES MOVED : " + Player.S.spacesMoved + '/' + Player.S.moveLim;

		if (Player.S.spacesMoved >= Player.S.moveLim)
			Player.S.moving = false;
	}
}
