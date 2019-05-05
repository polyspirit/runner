using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCntrl : MonoBehaviour {
    
	public int speed = 2;
	public int health = 100;
	public int damage = 10;
	public int damageFire = 0;
	public int damageIce = 0;
	public int damageLightning = 0;
	public int potions = 2;
	public int score = 0;
	public int gameLevel = 0;
	public float chance = 75f;
	public float resistFire = 0.25f;
	public float resistIce = 0.25f;
	public float resistLightning = 0.25f;
    public float agility = 0.5f;
	public bool stop = false;
	public bool newGame = false;
	public Text hpText;
	public Text potionsCountText;

	private Rigidbody2D rb;
	private Slider healthbar;

    void Start() {
    	// LOAD
    	if(newGame){
    		PlayerPrefs.SetInt("health", health);
			PlayerPrefs.SetInt("potions", potions);
			PlayerPrefs.SetInt("score", score);
    		PlayerPrefs.SetInt("gameLevel", 0);
    		newGame = false;
    	}
    	if(PlayerPrefs.HasKey("gameLevel")){
    		gameLevel = PlayerPrefs.GetInt("gameLevel");
    	}
    	if(gameLevel > 0 && PlayerPrefs.HasKey("health")){
    		Debug.Log("LOAD");
    		health = PlayerPrefs.GetInt("health");
    		potions = PlayerPrefs.GetInt("potions");
    		score = PlayerPrefs.GetInt("score");
    	}

        rb = GetComponent <Rigidbody2D>();
        potionsCountText.text = potions.ToString();

        Text scoreTxt = GameObject.Find("score").GetComponent<Text>();
        scoreTxt.text = "Score: "+score.ToString();

        healthbar = GameObject.Find("Healthbar").GetComponent<Slider>();
    }

    void Update() {
    	if(health > 0){
    		healthbar.value = health;
    		hpText.text = "HP: "+health.ToString();
    	}else{
    		healthbar.value = 0;
    	}
    	if(!stop){
        	rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
    }
}
