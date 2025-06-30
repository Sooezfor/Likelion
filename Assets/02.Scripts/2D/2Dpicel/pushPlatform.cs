using UnityEngine;

public class pushPlatform : MonoBehaviour
{

    Animator anim;
    Rigidbody2D targetRb;
    [SerializeField] float pushPower = 19f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 1f);
        }
    }
    void PushCharacter()
    {
        targetRb.AddForceY(pushPower, ForceMode2D.Impulse);
        anim.SetTrigger("Push");
    }

}
