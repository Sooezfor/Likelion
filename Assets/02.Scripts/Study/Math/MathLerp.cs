using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    Vector3 startPos;
    float timer, percent; 
    public float lerpTime; 

    private void Start()
    {
        startPos = transform.position; //시작 지점 저장, 목표지점까지 기준점
    }

    private void Update()
    {
        timer += Time.deltaTime; //시간 조각
        percent = timer / lerpTime; 

        transform.position = Vector3.Lerp(startPos, targetPos, percent); //일정하게 선형 이동
    }
}
