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
        backgroundUI.SetActive(true); //마우스 클릭할 때만 잠깐 켜지기
        backgroundUI.transform.position = eventData.position; //백그라운드 위치 마우스 위치로
        startPos = eventData.position;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f); //drag dir과 100 중에 최소값을 찾겠다는 뜻.마우스 포인터로 드래그 하고있는 값

        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;//핸들러 위치 마우스포인터 위치로 옮기기 
        knightController.InputJoystick(dragDir.x, dragDir.y);//조이스틱 값 전달
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        knightController.InputJoystick(0, 0); //잔여값 남지 않도록 초기화(마우스 떼면 멈추도록)
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
    }
}
