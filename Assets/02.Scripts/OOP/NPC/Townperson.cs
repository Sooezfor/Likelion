using UnityEngine;

public class Townperson : MonoBehaviour, ITalk, IMove
{
    //npc 
    public float hp;
    public float speed;

    public void Move()
    {
        Debug.Log("Move");
        transform.position += transform.right * speed * Time.deltaTime; 
    }

    public void Talk()
    {
        Debug.Log("Talk");
    }
}
