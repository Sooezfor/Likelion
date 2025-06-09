using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;

public class StudyCoroutine : MonoBehaviour
{

    bool isStop = false;
    private void Start()
    {
        StartCoroutine(BombRoutine());
    }

    IEnumerator BombRoutine()
    {
        int t = 10;
        while (t>0)
        {
            Debug.Log($"{t}�� ���ҽ��ϴ�.");
            yield return new WaitForSeconds(1f);
            t--;

            if(isStop)
            {
                Debug.Log("��ź�� �����Ǿ����ϴ�.");
                yield break;
            }
        }

        Debug.Log("��ź�� �������ϴ�.");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
         {
            isStop = true;
        }
    }
}
