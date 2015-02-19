using UnityEngine;
using System.Collections;

public class Inventory_Load : MonoBehaviour {

	public GameObject[] inventoryItems;

	public void fillInventory(){
		if(Game_SaveLoad.birthdayCard){
			inventoryItems[0].SetActive (true);
		}
	
		if(Game_SaveLoad.explanationLetter){
			inventoryItems[1].SetActive (true);
		}

		if(Game_SaveLoad.map){
			inventoryItems[2].SetActive (true);
		}

		if(Game_SaveLoad.jar){
			inventoryItems[3].SetActive (true);
		}

		if(Game_SaveLoad.plecs){
			inventoryItems[4].SetActive (true);
		}

		if(Game_SaveLoad.boardwalk){
			inventoryItems[5].SetActive (true);
		}

		if(Game_SaveLoad.medal){
			inventoryItems[6].SetActive (true);
		}

		if(Game_SaveLoad.kite){
			inventoryItems[7].SetActive (true);
		}

		if(Game_SaveLoad.pond){
			inventoryItems[8].SetActive (true);
		}

		if(Game_SaveLoad.picnicBench){
			inventoryItems[9].SetActive (true);
		}

		if(Game_SaveLoad.polaroid){
			inventoryItems[10].SetActive (true);
		}

		if(Game_SaveLoad.openPresent){
			inventoryItems[11].SetActive (true);
		}
	}

}
