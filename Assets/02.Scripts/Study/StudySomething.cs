using UnityEngine;

public class StudySomething : MonoBehaviour
{

    public int currentLevel = 10;
    public int maxLevel = 99; 
    void Start()
    {
        // 비교연산에 의한 결과를 bool 값으로 받는 코드
        bool isMax = currentLevel >= maxLevel;

        string msg = currentLevel >= maxLevel ? "현재 만렙입니다." : "현재 만렙이 아닙니다.";

        int LevelPoint = currentLevel >= maxLevel ? 0 : 1; // 만렙이라면 레벨 포인트 0. 아니라면 1

        currentLevel += LevelPoint;

        Debug.Log(msg);
       
    }

}