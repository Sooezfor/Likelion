using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class knightController_joyStick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;



    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
     
    }

    void OnCollisionExit2D(Collision2D other)
    {
      
    }


    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized; //날 것의 값에 노멀라이즈해서 크기 조절

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
            knightRb.linearVelocity = inputDir * moveSpeed;

        }
    }
}