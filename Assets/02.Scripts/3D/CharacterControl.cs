using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private IDropItem currentItem;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform grabpos;
    private void Update()
    {
        Move();
        Interaction();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); //x축 오른쪽 왼쪽 A,D
        float v = Input.GetAxis("Vertical"); //z축 앞쪽/뒤쪽 W,S 

        Vector3 dir = new Vector3(h, 0, v).normalized; //현재 입력한 방향

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Interaction()
    {
        if (currentItem == null) 
            return;
        
        if (Input.GetMouseButtonDown(0))
            currentItem.Use();
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop();
            currentItem = null;
        }         
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item; 

            currentItem.Grab(grabpos); //주운 아이템 그랩할 위치로 전달
        }
    }
}
