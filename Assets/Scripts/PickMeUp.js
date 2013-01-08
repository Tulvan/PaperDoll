#pragma strict

function Start () {

}

function Update () {

}

/*
When the object is clicked on, add it to the inventory.
*/
function OnMouseDown() {
	var GUIObject = GameObject.FindGameObjectWithTag("GUI");
	var targetScript : UnityGUI = GUIObject.GetComponent("UnityGUI");
	
	targetScript.AddToInventory(Resources.Load(transform.name) as Texture);
/*
	if (targetScript.aryInventoryImages.length < targetScript.maxInventorySize)
	{
		targetScript.aryInventoryImages.Add(Resources.Load(transform.name) as Texture);
		Debug.Log(targetScript.aryInventoryImages);
	}
	else
		Debug.Log("The inventory is full. Can't add");
*/
}

