using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    Animator anim;

    public string openKey;//유니티에서 직접 넣을 예정
    public string closeKey; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger(openKey);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger(closeKey);
        }
    }


}
