using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageButton : MonoBehaviour {

	public float effectTime = 2f;
	public float awaitingTime = 1f;
    
    private PlayerCntrl pers;
    private bool effectWorks = false;
    private Button button;
    private float effectTimeConst;
    private float awaitingTimeConst;

    void Start() {
    	button = GetComponent<Button>();
        GameObject persObj = GameObject.FindWithTag("Player");
        pers = persObj.gameObject.GetComponent<PlayerCntrl>();

        effectTimeConst = effectTime;
        awaitingTimeConst = awaitingTime;
    }

    public void DoubleDamage() {
    	button.interactable = false;
        pers.damage = pers.damage*2;
        effectWorks = true;
    }

    void Update() {
    	if(effectWorks){
	    	effectTime -= Time.deltaTime;
	    	if(effectTime <= 0) {
	    		pers.damage = pers.damage/2;
	    		effectWorks = false;
	    	}
    	}else{
    		if(effectTime <= 0) { // already used
    			awaitingTime -= Time.deltaTime;
    			if(awaitingTime <= 0) {
    				effectTime = effectTimeConst;
    				awaitingTime = awaitingTimeConst;
    				button.interactable = true;
    			}
    		}
    	}
    }
}
