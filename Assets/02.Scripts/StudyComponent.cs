using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    GameObject ob; // 큐브 게임오브젝트를 가져오고싶다

    public string changeName;

    void Start()
    {
        ob = GameObject.Find("Main Camera"); // 메인 카메라 오브젝트를 찾아서 할당하는 기능. 못 찾으면 none. 

        ob.name = changeName;    


    }
}
