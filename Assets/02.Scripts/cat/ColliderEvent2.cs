using UnityEngine;

public class ColliderEvent2 : MonoBehaviour
{

    public GameObject fadeUI;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            fadeUI.SetActive(true);
        }
    }
}
