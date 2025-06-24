using UnityEngine;
using UnityEngine.EventSystems;

public class joyStickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] knightController_joyStick knightController;
    [SerializeField] GameObject backgroundUI;
    [SerializeField] GameObject handlerUI;

    Vector2 startPos, currPos; 

    void Start()
    {
        backgroundUI.SetActive(false); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true); //���콺 Ŭ���� ���� ��� ������
        backgroundUI.transform.position = eventData.position; //��׶��� ��ġ ���콺 ��ġ��
        startPos = eventData.position;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f); //drag dir�� 100 �߿� �ּҰ��� ã�ڴٴ� ��.���콺 �����ͷ� �巡�� �ϰ��ִ� ��

        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;//�ڵ鷯 ��ġ ���콺������ ��ġ�� �ű�� 
        knightController.InputJoystick(dragDir.x, dragDir.y);//���̽�ƽ �� ����
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        knightController.InputJoystick(0, 0); //�ܿ��� ���� �ʵ��� �ʱ�ȭ(���콺 ���� ���ߵ���)
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
    }
}
