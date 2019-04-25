using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyPotion : MonoBehaviour {

	public int cost = 20;

	private PlayerCntrl pers;
	private Text score;
	private Text potionsCountText;

    void Start() {
        GameObject persObj = GameObject.FindWithTag("Player");
        pers = persObj.gameObject.GetComponent<PlayerCntrl>();

        potionsCountText = GameObject.Find("PotionsCountText").GetComponent<Text>();

        score = GameObject.Find("score").GetComponent<Text>();
    }

    public void Buy() {
    	if(pers.score >= cost){
    		pers.potions ++;
    		pers.score -= cost;
    		score.text = "Score: "+pers.score.ToString();
    		potionsCountText.text = pers.potions.ToString();
    	}
    }
}
