using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PinBall : MonoBehaviour
{
    public PinballManager pinballManager;//����Ƽ �󿡼� �Ҵ� �ʿ�

    void OnCollisionEnter2D(Collision2D other)
    {
            int Score = 0;
            switch (other.gameObject.tag)
            {
                case "Score10":
                    pinballManager.totalScore += 10;
                    Debug.Log("10�� ȹ��");
                    break;
                case "Score30":
                    pinballManager.totalScore += 30;
                    Debug.Log("30�� ȹ��");
                    break;
                case "Score50":
                    pinballManager.totalScore += 50;
                    Debug.Log("50�� ȹ��");
                    break;
            }
            pinballManager.totalScore += Score;

            if(Score != 0)
                 Debug.Log($"{Score}�� ȹ��");
        }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("���� ����");
            Debug.Log($"���� ���� : {pinballManager.totalScore}");
        }
    }
}