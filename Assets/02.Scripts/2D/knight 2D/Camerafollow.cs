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
        //������ ���� = ������ �ε巴�� �̵�( ���� ��ġ(����) Ÿ����ġ(����), ����(��ŭ �ε巴��) )

        //�� �Ҵ� ���� Ŭ���� �۾��ؾ� ��. 

        smoothPos.x = Mathf.Clamp(smoothPos.x, -5.2f, 14.19f);
        smoothPos.y = Mathf.Clamp(smoothPos.y, -3.99f, 12.99f);
        // (�� , �ּҰ�, �ִ밪. ���� �ּҿ� �ִ밪 ���̷� �����ϰ� ����� �ּҰ��� �ְų� �ִ밪 ���� ����)

        transform.position = smoothPos;
    }
}
