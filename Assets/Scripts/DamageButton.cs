using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageButton : MonoBehaviour {

	public float effectTime = 2f;
	public float awaitingTime = 1f;
    
    private PlayerCntrl pers;
    private Button button;
    private bool effectWorks = false;
    private Image effectImage;
    private RectTransform effectRect;
    private float effectTimeConst;
    private float awaitingTimeConst;

    private float buttonWidth = 160f;
    private float buttonWidthCurrent = 160f;

    void Start() {
        Debug.Log("DamageButton ready");
    	button = GetComponent<Button>();
        effectImage = GameObject.Find("Effect").GetComponent<Image>();
        effectRect = effectImage.transform as RectTransform;
        buttonWidth = buttonWidthCurrent = effectRect.rect.width;

        GameObject persObj = GameObject.FindWithTag("Player");
        pers = persObj.gameObject.GetComponent<PlayerCntrl>();

        effectTimeConst = effectTime;
        awaitingTimeConst = awaitingTime;
    }

    public void DoubleDamage() {
        Debug.Log("DamageButton pressed");
    	button.interactable = false;
        pers.damage = pers.damage*2;
        effectWorks = true;
    }

    void Update() {
    	if(effectWorks){
	    	effectTime -= Time.deltaTime;
            float effectTimePercent = Time.deltaTime*100/effectTimeConst;
            float buttonWidthDelta = effectTimePercent*buttonWidth/100;
            buttonWidthCurrent -= buttonWidthDelta;
            SetWidth(effectRect, buttonWidthCurrent);
	    	if(effectTime <= 0) {
	    		pers.damage = pers.damage/2;
	    		effectWorks = false;
	    	}
    	}else{
    		if(effectTime <= 0) { // already used
    			awaitingTime -= Time.deltaTime;
                float awaitingTimePercent = Time.deltaTime*100/awaitingTimeConst;
                float buttonWidthDelta = awaitingTimePercent*buttonWidth/100;
                buttonWidthCurrent += buttonWidthDelta;
                SetWidth(effectRect, buttonWidthCurrent);
    			if(awaitingTime <= 0) {
    				effectTime = effectTimeConst;
    				awaitingTime = awaitingTimeConst;
    				button.interactable = true;
    			}
    		}
    	}
    }

    void SetSize(RectTransform trans, Vector2 newSize) {
        Vector2 oldSize = trans.rect.size;
        Vector2 deltaSize = newSize - oldSize;
        trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
    }
    void SetWidth(RectTransform trans, float newSize) {
        SetSize(trans, new Vector2(newSize, trans.rect.size.y));
    }
    void SetHeight(RectTransform trans, float newSize) {
        SetSize(trans, new Vector2(trans.rect.size.x, newSize));
    }
}
