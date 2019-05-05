using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

	private PlayerCntrl player;

    void Start(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			player = other.gameObject.GetComponent<PlayerCntrl>();
			player.stop = true;

			// SAVE
			player.gameLevel++;
			PlayerPrefs.SetInt("health", player.health);
			PlayerPrefs.SetInt("potions", player.potions);
			PlayerPrefs.SetInt("score", player.score);
			PlayerPrefs.SetInt("gameLevel", player.gameLevel);

			Debug.Log(player.gameLevel);

			SceneManager.LoadScene(player.gameLevel);
		}
	}

    void Update()
    {
        
    }
}
