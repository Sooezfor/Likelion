using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetTile : MonoBehaviour
{
    public GameObject tilePrefab;
    public int rows = 5, cols = 5;  //��� 5x5 
    public Button[] buttons;
    public static int turretIndex;

    private void Awake()
    {
        for(int i = 0; i<5; i++)
        {
            int j = i; 
            buttons[i].onClick.AddListener(() => ChangeIndex(j)); // �̷��� ���� �� �ȵǴ� ������ Closure �̽�.
                                                                  // �ݺ����� �Ű������� ���ٽ��� ���� �Ҷ� i��� ���� ���� ���� �ȵ�. 
                                                                  // �ݺ����� ������ i�� ��������� 5�� ��. �ذ��ϱ� ���ؼ��� ���������� ��Ƽ� ���� ��.
        }
    }

    IEnumerator Start()
    {
        for(int i = 0; i < rows; i++) //�� 
        { 
            for(int j = 0; j < cols; j++)//��
            {
                var pos = new Vector3(j, 0, i);//x��� z�� �������� Ÿ���� ������Ű�� �ִ� ��.

                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                Renderer renderer = tile.GetComponent<Renderer>();

                if((i+j)%2 ==0) //¦��
                {
                    renderer.material.color = Color.white; 
                }
                else //Ȧ��
                {
                    renderer.material.color = Color.black; 
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void ChangeIndex(int index)
    {
        turretIndex = index;
    }
}
