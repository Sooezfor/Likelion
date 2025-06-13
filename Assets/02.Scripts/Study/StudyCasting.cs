using System;
using UnityEngine;
using System.Collections.Generic;

public class StudyCasting : MonoBehaviour
{

    private void Start()
    {
        MonsterClass m = new MonsterClass();
        //Orc o1 = m; // 암시적 형변환 안됨. 
        //Orc o = (Orc)m; //명시적 형변환 O, 근데 안될수도있음 일단 컴파일러 상에서 가능 

        Orc o = m as Orc; //성공하면 되고 실패 시 null 나옴. 근데 실패해서 null 나옴. 
        if (o != null)
            Debug.Log(o);
        
        else
            Debug.Log("형변환 되지않음");

    }
}
