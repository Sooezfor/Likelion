using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTImeUI;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        playTImeUI.text = string.Format("플레이 시간 : {0:F1}초", timer); //:F1 은 소수점 한자리까지만을 말함. 
    }
}
