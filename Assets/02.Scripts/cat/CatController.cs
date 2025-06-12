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
    public GameObject PLAY; //�÷��� ������Ʈ ������� ���� 

    Animator catAnim; 
    Rigidbody2D catRb;

    public float jumpPower = 10f;
    public float limitPower = 9f;
    int jumpCount;

    void Awake() //1���� ����
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    private void OnEnable() //���� ������ 1���� ����
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

            GameManager.score++; //���� ���� ������ �÷��� 1

            if(GameManager.score == 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<fadePanel>().OnFade(3f, Color.white, true);
                GetComponent<CircleCollider2D>().enabled = false; //�ݶ��̴� ��� ����
          
                StartCoroutine(EndingRoutine(true));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //�ٴڿ� ����� �� 
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();
            gameOverUI.SetActive(true); //���ӿ��� �ѱ�                     
            fadeUI.SetActive(true);
           
            fadeUI.GetComponent<fadePanel>().OnFade(3f, Color.black, true);
            GetComponent<CircleCollider2D>().enabled = false; //�ݶ��̴� ��� ���� 

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
        PLAY.SetActive(false); //����԰� �ٸ����� // �̰� �������� �� ��ũ��Ʈ ��ü�� ����.  
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5) //���� �ټ� �� ����
        {
            catAnim.SetTrigger("Jump"); //�ִϸ����� �Ķ���Ϳ� �����ϱ�
            catAnim.SetBool("IsGround", false); //������ �� ���� �޽��� �����
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
