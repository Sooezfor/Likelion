using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PinBall : MonoBehaviour
{
    public PinballManager pinballManager;//¿Ø¥œ∆º ªÛø°º≠ «“¥Á « ø‰

    void OnCollisionEnter2D(Collision2D other)
    {
            int Score = 0;
            switch (other.gameObject.tag)
            {
                case "Score10":
                    pinballManager.totalScore += 10;
                    Debug.Log("10¡° »πµÊ");
                    break;
                case "Score30":
                    pinballManager.totalScore += 30;
                    Debug.Log("30¡° »πµÊ");
                    break;
                case "Score50":
                    pinballManager.totalScore += 50;
                    Debug.Log("50¡° »πµÊ");
                    break;
            }
            pinballManager.totalScore += Score;

            if(Score != 0)
                 Debug.Log($"{Score}¡° »πµÊ");
        }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("∞‘¿” ¡æ∑·");
            Debug.Log($"√÷¡æ ¡°ºˆ : {pinballManager.totalScore}");
        }
    }
}