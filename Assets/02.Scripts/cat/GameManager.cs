using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TextMeshProUGUI playTImeUI;
        public TextMeshProUGUI scoreUI;
        float timer;
        public static int score;//멜론 먹은 개수. static을 사용해 다른 스크립트에서 접근 용이하게
        public static bool isPlay;

        private void Start()
        {
            soundManager.SetBGMSound("Intro");

        }

        private void Update()
        {
            if (!isPlay) 
                return;

            timer += Time.deltaTime;
            //playTImeUI.text = string.Format("플레이 시간 : {0:F1}초", timer); //:F1 은 소수점 한자리까지만을 말함. 
            playTImeUI.text = $"플레이 시간: {timer:F1}초";
            scoreUI.text = $"X {score}";
        }
    }   
}
