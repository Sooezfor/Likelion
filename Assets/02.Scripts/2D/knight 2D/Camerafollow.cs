using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    Transform target;

    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 5f;

    [SerializeField] Vector2 minBound; 
    [SerializeField] Vector2 maxBound;

    InteractionEvent doorEvent; 

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 destination = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, destination, smoothSpeed * Time.deltaTime);
        //스무스 포즈 = 러프로 부드럽게 이동( 현재 위치(에서) 타겟위치(까지), 비율(만큼 부드럽게) )

        //값 할당 전에 클램프 작업해야 함. 

        smoothPos.x = Mathf.Clamp(smoothPos.x, -5.2f, 14.19f);
        smoothPos.y = Mathf.Clamp(smoothPos.y, -3.99f, 12.99f);
        // (값 , 최소값, 최대값. 값을 최소와 최대값 사이로 고정하고 벗어나면 최소값을 넣거나 최대값 넣을 것임)

        transform.position = smoothPos;
    }
}
