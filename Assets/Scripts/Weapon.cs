using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject[] weapons;
	public int damage = 10;

	private Outline outline;
	private bool active = false;
	private PlayerCntrl pers;

	void Start() {
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        GameObject persObj = GameObject.FindWithTag("Player");
        pers = persObj.gameObject.GetComponent<PlayerCntrl>();
    }

	void OnMouseDown() {
		foreach (GameObject weapon in weapons) {
			Outline otherOutline = weapon.GetComponent<Outline>();
			otherOutline.enabled = false;
        }
        outline = GetComponent<Outline>();
        outline.enabled = true;
        active = true;
        pers.damage = damage;

        GameObject persWeapon = GameObject.FindWithTag("PersWeapon");
        persWeapon.GetComponent<SpriteRenderer>().sprite = GetComponent<Image>().sprite;
    }
}
