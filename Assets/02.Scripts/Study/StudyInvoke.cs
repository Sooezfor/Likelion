using UnityEngine;

public class StudyInvoke : MonoBehaviour
{
    public int count = 10; 

    private void Start()
    {
        //인보크 반복 ("함수명", 처음 지연시간, 그 이후로 몇초마다 (주기) 
        InvokeRepeating("Bomb", 0f, 1f);

    }
    void Bomb()
    {
        Debug.Log($"현재 남은 시간 : {count}초");
        count--; 

        if(count == 0)
        {
            Debug.Log("폭탄이 터졌습니다.");
            CancelInvoke("Bomb");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("폭탄이 해제되었습니다.");
        }
        
    }
}
