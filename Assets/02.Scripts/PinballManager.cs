using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D leftbarRb;
    public Rigidbody2D rightbarRb;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            leftbarRb.AddTorque(40f);
        }
        else
        {
            leftbarRb.AddTorque(-25f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rightbarRb.AddTorque(-40f);
        }
        else
        {
            rightbarRb.AddTorque(25f);
        }

    }
}
