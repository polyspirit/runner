using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionsButton : MonoBehaviour {

	public int heal = 20;

	private PlayerCntrl pers;
	private Text buttonText;

	void Start() {
        GameObject persObj = GameObject.FindWithTag("Player");
        pers = persObj.gameObject.GetComponent<PlayerCntrl>();
        buttonText = transform.Find("PotionsCountText").GetComponent<Text>();
    }

    public void DoHeal() {
    	if(pers.potions > 0){
    		pers.potions -= 1;
    		pers.health += heal;
    		pers.hpText.text = "HP: "+pers.health.ToString();
    		buttonText.text = pers.potions.ToString();
    	}
    }
}
