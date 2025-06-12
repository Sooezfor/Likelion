using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public GameObject playobj;
        public GameObject introUI;
        public GameObject playUI;
        public GameObject videoPanel; 

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;
        public Button restartButton; 


        private void Awake() //�� ����(���� ���Ӹ޴������� �ؾ���)
        {

            playobj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton); //��ŸƮ ��ư�� �����ؼ� �� Ŭ�� �̺�Ʈ ����ؼ� �ֵ帮����(ȣ�� ���ϴ¾�) ���
            restartButton.onClick.AddListener(OnRestartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if(isNoText)
            {
                Debug.Log("�Է� ����");
             }
            else
            { //start ��ư �������� ����Ǵ� �ֵ��� �� ������ִ°�. 
                soundManager.SetBGMSound("Play");
                GameManager.isPlay = true;

                playobj.SetActive(true);
                playUI.SetActive(true);
                introUI.SetActive(false);
                nameTextUI.text = inputField.text;
            }                        
         }

        void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            playobj.SetActive(true);
            videoPanel.SetActive(false);
        }
    }
}
