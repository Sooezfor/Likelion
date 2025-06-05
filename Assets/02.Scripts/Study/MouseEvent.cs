using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Button down");
        }
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Button");
        }
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Button up");
        }                  
    }
}
