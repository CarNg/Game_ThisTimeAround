using UnityEngine;
using System.Collections;

public class Inventory_ItemInfoAlt : MonoBehaviour {
	
	public bool checkLake;
	public Texture2D altInfo;

	void Start () {
		if (checkLake) {
			if (Game_SaveLoad.lakeFinished) {
				gameObject.GetComponent<Inventory_ItemInfo>().informationTexture = altInfo;		
			}		
		}
		else {
			if (Game_SaveLoad.parkFinished) {
				gameObject.GetComponent<Inventory_ItemInfo>().informationTexture = altInfo;		
			}	
		}
	}

}
