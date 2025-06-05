using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("MOuse enter");
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }
    private void OnMouseDown()
    {
        Debug.Log("MOuse down");
    }
    private void OnMouseDrag()
    {
        Debug.Log("Mouse Drag");
    }
    private void OnMouseUp()
    {
        Debug.Log("MOuse up");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse As button");
    }
    private void OnMouseExit()
    {
        Debug.Log("On MOuse exit");
    }

}
