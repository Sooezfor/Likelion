using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTImeUI;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        playTImeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer); //:F1 �� �Ҽ��� ���ڸ��������� ����. 
    }
}
