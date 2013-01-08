#pragma strict

var inventory : GameObject;

function Start () {
	inventory.SetActive(false);
}

function Update () {
	if (Input.GetKeyUp(KeyCode.I))
	{
		// if inventory is just a guiTexture...
		//inventory.guiTexture.enabled = !inventory.guiTexture.enabled;
		
		// if inventory is a GameObject container...
//		inventory.active = !inventory.active; // obsolete
		inventory.SetActive(!inventory.activeSelf);

		// set the GUI variable to match		
		UnityGUI.showInventory = inventory.activeSelf;
	}
}