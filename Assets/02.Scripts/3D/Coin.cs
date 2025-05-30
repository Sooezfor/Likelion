using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CoinCount.coinCount++;
            Debug.Log($"ÇöÀç±îÁö {CoinCount.coinCount} ÄÚÀÎ È¹µæ!");
            Destroy(gameObject);
        }       
    }
}
