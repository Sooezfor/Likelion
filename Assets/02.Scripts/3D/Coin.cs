using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CoinCount.coinCount++;
            Debug.Log($"������� {CoinCount.coinCount} ���� ȹ��!");
            Destroy(gameObject);
        }       
    }
}
