using System;
using UnityEngine;
using System.Collections.Generic;

public class StudyCasting : MonoBehaviour
{

    private void Start()
    {
        MonsterClass m = new MonsterClass();
        //Orc o1 = m; // �Ͻ��� ����ȯ �ȵ�. 
        //Orc o = (Orc)m; //����� ����ȯ O, �ٵ� �ȵɼ������� �ϴ� �����Ϸ� �󿡼� ���� 

        Orc o = m as Orc; //�����ϸ� �ǰ� ���� �� null ����. �ٵ� �����ؼ� null ����. 
        if (o != null)
            Debug.Log(o);
        
        else
            Debug.Log("����ȯ ��������");

    }
}
