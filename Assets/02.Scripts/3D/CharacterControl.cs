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
        float h = Input.GetAxis("Horizontal"); //x�� ������ ���� A,D
        float v = Input.GetAxis("Vertical"); //z�� ����/���� W,S 

        Vector3 dir = new Vector3(h, 0, v).normalized; //���� �Է��� ����

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
