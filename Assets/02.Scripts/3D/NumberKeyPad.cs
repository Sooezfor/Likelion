using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public string password;  //��й�ȣ ����
    public string keyPadNUmber; //�Է��� ���� ����
    public Animator doorAnim;
    public GameObject doorLock;

    public void ONINputNumber(string numString)
    {
        keyPadNUmber += numString;
        // Ű�е� �ѹ� �ڿ� ���ڰ� �ڿ� �ٴ´ٴ� ����. �������°Ծƴ϶�

        Debug.Log($"{numString} �Է� -> ���� �Է� : {keyPadNUmber}");
    }

    public void ONChecNumber() //enter ��ư
    {
        if(keyPadNUmber == password)
        {
            Debug.Log("�� ����");
            doorAnim.SetTrigger("Door Open");

            doorLock.SetActive(false);

        }
        else
        {
            keyPadNUmber = "";
            Debug.Log("��й�ȣ ����");
        }   
    }

}
