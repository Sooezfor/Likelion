using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StudyFor : MonoBehaviour
{
  
    private void Start()
    {
        for(int i = 0; i<3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Debug.Log($"{i} / {j}");
            }
        }
    }

}
