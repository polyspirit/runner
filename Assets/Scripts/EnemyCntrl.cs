using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCntrl : MonoBehaviour
{

	public int health = 50;
	public int damage = 5;
	public int damageFire = 0;
	public int damageIce = 0;
	public int damageLightning = 0;
	public int money = 10;
	public float chance = 60f;
	public float resistFire = 0.25f;
	public float resistIce = 0.25f;
	public float resistLightning = 0.25f;
	public float agility = 0.5f;

	private GameObject player_obj;
	private PlayerCntrl player;
	private Text score;

	void Start() {
		score = GameObject.Find("score").GetComponent<Text>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			player_obj = other.gameObject;
			player = other.gameObject.GetComponent<PlayerCntrl>();
			player.stop = true;
			float agilitySumm = player.agility + agility;
			InvokeRepeating("PlayerTurn", 0.001f, agilitySumm);
			InvokeRepeating("EnemyTurn", (agilitySumm/2), agilitySumm);
		}
	}

	void PlayerTurn() {
		float random = Random.Range(0f, 100f);
		int cur_damage = 0;
		
		if(random < player.chance){ // damage
			cur_damage = player.damage;
			cur_damage += (int)( player.damageFire * (1f-resistFire) ) + (int)( player.damageIce * (1f-resistIce) ) + (int)( player.damageLightning * (1f-resistLightning) );
			health -= cur_damage;
			player_obj.transform.Translate(Vector2.right * 0.05f);
		}
		if(health <= 0){ // enemy death
			player.score += money;
			score.text = "Score: "+player.score.ToString();
			CancelInvoke();
			Destroy(gameObject);
			player.stop = false;
		}
		// Debug.Log("Выпало: "+random + ", игрок нанес " + cur_damage + " урона");
 	}

	void EnemyTurn() {
		float random = Random.Range(0f, 100f);
		int cur_damage = 0;
		
		if(random < chance){
			cur_damage = damage;
			cur_damage += (int)( damageFire * (1f-player.resistFire) ) + (int)( damageIce * (1f-player.resistIce) ) + (int)( damageLightning * (1f-player.resistLightning) );
			player.health -= cur_damage;
			transform.Translate(Vector2.left * 0.05f);
		}		
		if(player.health <= 0){
			Debug.Log("DEATH");
			CancelInvoke();
			player.stop = true;
			player.hpText.text = "Game Over";
		}
		// Debug.Log("Выпало: "+random + ", враг нанес " + cur_damage + " урона");
 	}
}
