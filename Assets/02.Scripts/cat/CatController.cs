using Unity.VisualScripting;
using System;
using UnityEngine;
using Cat;
using System.Collections;


public class CatController : MonoBehaviour
{
    public VideoManager videoManager;
    public SoundManager soundManager;

    public GameObject gameOverUI;
    public GameObject fadeUI; 
    public GameObject PLAY; //플레이 오브젝트 담기위한 변수 

    Animator catAnim; 
    Rigidbody2D catRb;

    public float jumpPower = 10f;
    public float limitPower = 9f;
    int jumpCount;

    void Awake() //1번만 실행
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    private void OnEnable() //켜질 때마다 1번씩 실행
    {
        transform.localPosition = new Vector3(-6.3f, -4.44f, 0);

        GetComponent<CircleCollider2D>().enabled = true;

        soundManager.audioSource.Play();
        soundManager.audioSource.mute = false;
    }

    void Update()
    {
        Jump();
    }     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Melon"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<itemEvent>().particle.SetActive(true);

            GameManager.score++; //과일 먹을 때마다 플러스 1

            if(GameManager.score == 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<fadePanel>().OnFade(3f, Color.white, true);
                GetComponent<CircleCollider2D>().enabled = false; //콜라이더 기능 끄기
          
                StartCoroutine(EndingRoutine(true));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //바닥에 닿았을 때 
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();
            gameOverUI.SetActive(true); //게임오버 켜기                     
            fadeUI.SetActive(true);
           
            fadeUI.GetComponent<fadePanel>().OnFade(3f, Color.black, true);
            GetComponent<CircleCollider2D>().enabled = false; //콜라이더 기능 끄기 

            StartCoroutine(EndingRoutine(false)); 
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("IsGround", true);
            jumpCount = 0;
        }
    }
    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);

        videoManager.VideoPlay(isHappy);
        yield return new WaitForSeconds(1f);

        var newColor = isHappy ? Color.white : Color.black;
        fadeUI.GetComponent<fadePanel>().OnFade(3f, newColor, false);
        soundManager.audioSource.mute = true;

        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        PLAY.SetActive(false); //강사님과 다르게함 // 이걸 꺼버려서 이 스크립트 자체가 멈춤.  
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5) //점프 다섯 번 가능
        {
            catAnim.SetTrigger("Jump"); //애니메이터 파라미터에 접근하기
            catAnim.SetBool("IsGround", false); //점프할 때 논리값 펄스로 만들기
            jumpCount++;
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            soundManager.OnJumpSound();

            if (catRb.linearVelocityY > limitPower)
            {
                catRb.linearVelocityY = limitPower;
            }
        }
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;
    }
}
