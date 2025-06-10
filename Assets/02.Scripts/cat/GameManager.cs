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
        public static int score;//��� ���� ����. static�� ����� �ٸ� ��ũ��Ʈ���� ���� �����ϰ�
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
            //playTImeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer); //:F1 �� �Ҽ��� ���ڸ��������� ����. 
            playTImeUI.text = $"�÷��� �ð�: {timer:F1}��";
            scoreUI.text = $"X {score}";
        }
    }   
}
