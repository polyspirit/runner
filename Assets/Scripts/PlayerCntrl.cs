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
	public float chance = 75f;
	public float resistFire = 0.25f;
	public float resistIce = 0.25f;
	public float resistLightning = 0.25f;
    public float agility = 0.5f;
	public bool stop = false;
	public Text hpText;
	public Text potionsCountText;

	private Rigidbody2D rb;

    void Start() {
        rb = GetComponent <Rigidbody2D>();
        potionsCountText.text = potions.ToString();
    }

    void Update() {
    	if(health > 0){
    		hpText.text = "HP: "+health.ToString();
    	}
    	if(!stop){
        	rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
    }
}
