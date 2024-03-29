using UnityEngine;
using System.Collections;

/* http://wiki.unity3d.com/index.php?title=DraggableGUIElement
Usage
	Add this script to any GameObject with a GUITexture or GUIText element. 
	Set the border property to be the minimum and maximum values in viewport 
	space that the object can inhabit. In case you don't remember what viewport 
	space is, the coordinates 0,0 are the lower left of the game view, and 1,1 
	is the upper right.
Advanced Usage
	Arrange a dialog box using GUITexture and GUIText elements, probably using 
	Button and ToggleButton to handle the buttons. Assign ForwardAllMouseEvents 
	to individual GUITexture elements of your dialog box that you want to be 
	draggable. A good choice would be a GUITexture that represents the title 
	bar of the window. On each of these GUITextures to be draggable, assign 
	the ForwardAllMouseEvents script. Set the target of each ForwardAllMouseEvents 
	script to the parent GameObject of which all the dialog box elements are 
	children of.

Assign this script, DraggableGUIElement, to the parent GameObject. Now this script 
will receive mouse events from parts of your dialog box, and will move around 
the whole dialog box when you drag those certain parts. 

*/
public class DraggableGUIElement : MonoBehaviour
{
    [System.Serializable]
    public class Border
    {
        public float minX,maxX,minY,maxY;
    }
 
    public Border border;
 
    Vector3 lastMousePosition;
 
    void OnMouseDown()
    {
        lastMousePosition = GetClampedMousePosition();
    }
 
    Vector3 GetClampedMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x = Mathf.Clamp(mousePosition.x, 0f, Screen.width);
        mousePosition.y = Mathf.Clamp(mousePosition.y, 0f, Screen.height);
 
        return mousePosition;
    }
 
    void OnMouseDrag()
    {
        Vector3 delta = GetClampedMousePosition() - lastMousePosition;
 
        delta = Camera.main.ScreenToViewportPoint(delta);
 
        transform.position += delta;
 
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, border.minX, border.maxX);
        position.y = Mathf.Clamp(position.y, border.minY, border.maxY);
 
        transform.position = position;
 
        lastMousePosition = GetClampedMousePosition();
    }
}