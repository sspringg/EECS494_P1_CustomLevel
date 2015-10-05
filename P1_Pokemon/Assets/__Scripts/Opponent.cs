using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
public class Opponent : MonoBehaviour {

	public static Opponent S;

	public	Sprite	upSprite;
	public	Sprite	downSprite;
	public	Sprite	leftSprite;
	public	Sprite	rightSprite;
	public bool moveTowardPlayer = false;
	public SpriteRenderer	sprend;
	
	void Awake(){
		S = this;
	}
	
	void Start () {	
		sprend = gameObject.GetComponent<SpriteRenderer>();
		sprend.sprite = upSprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Main.S.playerTurn){
			
		
		}
		else if(moveTowardPlayer){
			if((gameObject.transform.position.x - Player.S.transform.position.x) > 1){
				transform.position += Vector3.left * (Time.deltaTime * 4);
			}
			else if((Player.S.transform.position.x - gameObject.transform.position.x) > 1){
				gameObject.transform.position += Vector3.right * (Time.deltaTime * 4);
			}
			else if((gameObject.transform.position.y - Player.S.transform.position.y) > 1){
				gameObject.transform.position += Vector3.down * (Time.deltaTime * 4);
			}
			else if((Player.S.transform.position.y - gameObject.transform.position.y) > 1){
				gameObject.transform.position += Vector3.up * (Time.deltaTime * 4);
			}
			else{
				//if character ends up kiddy korner move them up or down one square
				if(Math.Abs(gameObject.transform.position.y - Player.S.transform.position.y) + Math.Abs(gameObject.transform.position.x - Player.S.transform.position.x) > 1.9){
					if(Player.S.transform.position.y > gameObject.transform.position.y)
						gameObject.transform.position += Vector3.up;
					else
						gameObject.transform.position += Vector3.down;
				}	
				moveTowardPlayer = false;
				if(gameObject.transform.position.x > Player.S.transform.position.x)
					Player.S.sprend.sprite = Player.S.rightSprite;
				else if(Player.S.transform.position.x > gameObject.transform.position.x)
					Player.S.sprend.sprite = Player.S.leftSprite;
				else if(transform.position.y > Player.S.transform.position.y)
					Player.S.sprend.sprite = Player.S.upSprite;
				else if(Player.S.transform.position.y > gameObject.transform.position.y)
					Player.S.sprend.sprite = Player.S.downSprite;
				Player.S.inScene0 = false;
				Application.LoadLevelAdditive("_Scene_2");
			}
		
		}
	}
	
}
