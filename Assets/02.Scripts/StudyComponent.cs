using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    GameObject ob; // ť�� ���ӿ�����Ʈ�� ��������ʹ�

    public string changeName;

    void Start()
    {
        ob = GameObject.Find("Main Camera"); // ���� ī�޶� ������Ʈ�� ã�Ƽ� �Ҵ��ϴ� ���. �� ã���� none. 

        ob.name = changeName;    


    }
}
