using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playobj;
        public GameObject introUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

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
                {
                    playobj.SetActive(true);
                    introUI.SetActive(false);
                    nameTextUI.text = inputField.text;
                }                        
         }
    }
}
