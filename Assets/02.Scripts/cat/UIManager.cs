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
            startButton.onClick.AddListener(OnStartButton); //스타트 버튼에 접근해서 온 클릭 이벤트 등록해서 애드리스너(호출 당하는애) 등록
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if(isNoText)
                {
                Debug.Log("입력 없음");
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
