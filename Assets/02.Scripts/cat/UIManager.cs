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

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;


        private void Awake() //�� ����(���� ���Ӹ޴������� �ؾ���)
        {
            playobj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton); //��ŸƮ ��ư�� �����ؼ� �� Ŭ�� �̺�Ʈ ����ؼ� �ֵ帮����(ȣ�� ���ϴ¾�) ���
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
    }
}
