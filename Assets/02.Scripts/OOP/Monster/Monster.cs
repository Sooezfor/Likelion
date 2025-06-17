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

    private void OnMouseDown()//마우스 클릭 시 반응하는 함수,유니티 기본 함수
    {
        Hit(1); //데미지 1
    }
    private void Hit(float damage) //그냥 게임뷰 상에서 마우스로 클릭하면 상호작용됨
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Debug.Log("몬스터 죽음");
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1; //방향 반대로
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }
}
