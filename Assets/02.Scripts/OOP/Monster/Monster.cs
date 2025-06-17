using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public SpriteRenderer sRenderer;
    [SerializeField] protected float Hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;

    private int dir = 1;

    public abstract void Init();

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        Init();
    }
    private void Update()
    {
        Move();
    }

    private void OnMouseDown()//���콺 Ŭ�� �� �����ϴ� �Լ�,����Ƽ �⺻ �Լ�
    {
        Hit(1); //������ 1
    }
    private void Hit(float damage) //�׳� ���Ӻ� �󿡼� ���콺�� Ŭ���ϸ� ��ȣ�ۿ��
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Debug.Log("���� ����");
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1; //���� �ݴ��
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }
}
