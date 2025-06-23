using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetTile : MonoBehaviour
{
    public GameObject tilePrefab;
    public int rows = 5, cols = 5;  //행렬 5x5 
    public Button[] buttons;
    public static int turretIndex;

    private void Awake()
    {
        for(int i = 0; i<5; i++)
        {
            int j = i; 
            buttons[i].onClick.AddListener(() => ChangeIndex(j)); // 이렇게 했을 때 안되는 이유는 Closure 이슈.
                                                                  // 반복문에 매개변수에 람다식을 쓰고 할때 i라는 값이 정상 전달 안됨. 
                                                                  // 반복문이 끝날때 i는 결과적으로 5가 됨. 해결하기 위해서는 지역변수에 담아서 쓰면 됨.
        }
    }

    IEnumerator Start()
    {
        for(int i = 0; i < rows; i++) //행 
        { 
            for(int j = 0; j < cols; j++)//열
            {
                var pos = new Vector3(j, 0, i);//x축과 z축 기준으로 타일을 생성시키고 있는 것.

                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                Renderer renderer = tile.GetComponent<Renderer>();

                if((i+j)%2 ==0) //짝수
                {
                    renderer.material.color = Color.white; 
                }
                else //홀수
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
