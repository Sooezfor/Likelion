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


        private void Awake() //씬 세팅(원래 게임메니저에서 해야함)
        {

            playobj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton); //스타트 버튼에 접근해서 온 클릭 이벤트 등록해서 애드리스너(호출 당하는애) 등록
            restartButton.onClick.AddListener(OnRestartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if(isNoText)
            {
                Debug.Log("입력 없음");
             }
            else
            { //start 버튼 눌렀을때 실행되는 애들이 다 여기모여있는것. 
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
