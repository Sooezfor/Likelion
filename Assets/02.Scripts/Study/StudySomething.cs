using UnityEngine;

public class StudySomething : MonoBehaviour
{

    public int currentLevel = 10;
    public int maxLevel = 99; 
    void Start()
    {
        // �񱳿��꿡 ���� ����� bool ������ �޴� �ڵ�
        bool isMax = currentLevel >= maxLevel;

        string msg = currentLevel >= maxLevel ? "���� �����Դϴ�." : "���� ������ �ƴմϴ�.";

        int LevelPoint = currentLevel >= maxLevel ? 0 : 1; // �����̶�� ���� ����Ʈ 0. �ƴ϶�� 1

        currentLevel += LevelPoint;

        Debug.Log(msg);
       
    }

}