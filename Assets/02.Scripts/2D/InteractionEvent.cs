using System.Reflection;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType { Sign, Door, Npc }
    public InteractionType type;

    public GameObject signPopup; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }
    }
    void Interaction(Transform player)
    {
        switch(type)
        {
            case InteractionType.Sign:
                signPopup.SetActive(true);
                break;
            case InteractionType.Door:

                break;

            case InteractionType.Npc:

                break;
        }
    }

}
