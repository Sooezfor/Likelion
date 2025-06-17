using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private IDropItem currentItem;

    private void Update()
    {
        Move();
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
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop();
        }         
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item; 

            currentItem.Grab();
        }
    }
}
