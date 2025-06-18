using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    [SerializeField] GameObject[] items;
    //n�ʸ��� ���͸� �������� �����ϴ� ��� 

    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);

            var randomIndex = Random.Range(0, monsters.Length); //0,1
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 5);

            var spawnPos = new Vector3(randomX, randomY, 0); 

            Instantiate(monsters[randomIndex], spawnPos, Quaternion.identity);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse); //���� ���ư��� ������ 
        itemRb.AddForceY(2f, ForceMode2D.Impulse); //���� ���ư��� ����, position ���� 

        float ranPower = Random.Range(-0.5f, 0.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse); //Rotation ����. 
    }
}
