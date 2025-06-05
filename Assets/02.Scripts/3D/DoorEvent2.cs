using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    Animator anim;

    public string openKey;//����Ƽ���� ���� ���� ����
    public string closeKey;
    public GameObject doorLock;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorLock.SetActive(true);
           //anim.SetTrigger(openKey); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(false);
         // anim.SetTrigger(closeKey);
        }
    }
}
