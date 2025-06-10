using Unity.VisualScripting;
using System;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject fadeUI; 
    public SoundManager soundManager;
    Animator catAnim; 
    Rigidbody2D catRb;
    public float jumpPower = 10f;
    public float limitPower = 9f;
    int jumpCount;

    public GameObject happyVideo;
    public GameObject sadVideo;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    void Update()
    {
        //�����̽��� ������ ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5) //���� �ټ� �� ����
        {
            catAnim.SetTrigger("Jump"); //�ִϸ����� �Ķ���Ϳ� �����ϱ�
            catAnim.SetBool("IsGround", false); //������ �� ���� �޽��� �����
            jumpCount++;
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);         
            soundManager.OnJumpSound();

            if(catRb.linearVelocityY > limitPower)
                {
                  catRb.linearVelocityY = limitPower; 
                }
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;

    }     
    private void OnCollisionEnter2D(Collision2D other) //�ٴڿ� ����� �� 
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();

            gameOverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<fadePanel>().OnFade(3f, Color.black);

            this.GetComponent<CircleCollider2D>().enabled = false;

            Invoke("SadVideo", 5f);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("IsGround", true);
            jumpCount = 0;
        }
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
                fadeUI.GetComponent<fadePanel>().OnFade(3f, Color.white);
                this.GetComponent<CircleCollider2D>().enabled = false;

                Invoke("HappyVideo", 5f);

            }
        }
       
    }
    void HappyVideo()
    {
        happyVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
    void SadVideo()
    {
        sadVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }

}
