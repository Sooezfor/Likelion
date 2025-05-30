using UnityEngine;

public class ChracterMovement2D : MonoBehaviour
{
    Rigidbody2D chaRb;
    public SpriteRenderer[] renderers;

    public float jumpPower = 10f;
    public float moveSpeed;
    float h;
    public bool isGround;

    private void Start()
    {
        chaRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
        //자식들 안에서 스프라이트 렌더러가 있는 애들을 가져오겠다. ture는 활성비활성 상태를 무시하고 무조건 true로 바꾸겠단 뜻
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");//-1에서 1값 사이임.
        Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other) //지면에 닿은 상태
    {
        isGround = true;

        renderers[2].gameObject.SetActive(false); //jump
    }
    private void OnCollisionExit2D(Collision2D other) //지면에 닿지 않은 상태
    {
        isGround = false;

        renderers[0].gameObject.SetActive(false); //idle.
        renderers[1].gameObject.SetActive(false); //run.
        renderers[2].gameObject.SetActive(true); //jump
    }
    /// <summary>
    /// 캐릭터 움직임에 따라 이미지의 Flip 상태가 변하는 기능
    /// </summary>
    private void Move()
    {
        if (!isGround) //만약 isGround가 펄스일때 해당 함수 실행 종료
            return;

        if(h != 0) //h가 0이 아닐 때만(움직일 때)/ 입력 키를 누를 때 
        {
            renderers[0].gameObject.SetActive(false);//idle
            renderers[1].gameObject.SetActive(true);//run

             //리지드바디를 이용한 물리적인 이동이기 때문에 Fixed update에서 
            chaRb.linearVelocityX = h * moveSpeed;

            if(h > 0) // 오른쪽볼때
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;

            }
            else if( h < 0)//왼쪽볼때
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }
        else if( h == 0)// h가 0일 때만(안 움직일 때)/키를 누르지 않을 때
        {
            renderers[0].gameObject.SetActive(true);//idle
            renderers[1].gameObject.SetActive(false); //run
        }
    }

    /// <summary>
    /// 캐릭터가 +Y 방향으로 점프하는 기능 
    /// </summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))  //Input.GetKeyDown(KeyCode.Space) 랑 똑같음
        {
            chaRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}
