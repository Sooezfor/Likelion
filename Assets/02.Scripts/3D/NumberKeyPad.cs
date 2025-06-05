using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public string password;  //비밀번호 설정
    public string keyPadNUmber; //입력한 숫자 적용
    public Animator doorAnim;
    public GameObject doorLock;

    public void ONINputNumber(string numString)
    {
        keyPadNUmber += numString;
        // 키패드 넘버 뒤에 글자가 뒤에 붙는다는 뜻임. 더해지는게아니라

        Debug.Log($"{numString} 입력 -> 현재 입력 : {keyPadNUmber}");
    }

    public void ONChecNumber() //enter 버튼
    {
        if(keyPadNUmber == password)
        {
            Debug.Log("문 열림");
            doorAnim.SetTrigger("Door Open");

            doorLock.SetActive(false);

        }
        else
        {
            keyPadNUmber = "";
            Debug.Log("비밀번호 오류");
        }   
    }

}
