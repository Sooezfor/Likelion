using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image heart;
    public float hp = 100f;
    public float nowhp; //현재 체력 확인용 변수

    private void Update()
    {
        //if()
    }

    IEnumerator Heartbreak()
    {
         while (heart.fillAmount< 1f) //로딩창 
            {
                heart.fillAmount += Time.deltaTime* 0.3f;

                yield return null;
            }

    }
}
