using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 어떤 컴포넌트들을 코드에 넣을지 생각
// 2. 점프, 사망 bool 변수 선언
// 3. 점프 가능한 범위

public class PlayerController : MonoBehaviour
{
    [SerializeField]private AudioSource source;
    [SerializeField]private AudioClip deathClip;
    [SerializeField]private Rigidbody2D rb2D;
    [SerializeField]private Animator animator;
    private float jumpForce = 700f;     // 점프력
    private int jumpCount = 0;          // 누적 점프 횟수
    bool isDie = false;                 // 사망 여부
    bool isGrounded = false;            // 땅에 닿았는가
    private readonly string deadZone = "DeadZone";

    void Start()
    {
        source = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //deathClip = Resources.Load("die") as AudioClip;
        deathClip = Resources.Load<AudioClip>("Audio[BGM,SFX]/die");
    }

    void Update()
    {
        if (isDie) return;
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            rb2D.velocity = Vector3.zero;   // 점프 직전에 속도를 0으로 변경
            rb2D.AddForce(new Vector2(0f, jumpForce));  // y축으로 Force를 점프력만큼 적용
            source.Play();
        }
        else if (Input.GetMouseButtonUp(0) && rb2D.velocity.y > 0f) // 점프중일 때, 마우스를 떼면
        {
            rb2D.velocity = rb2D.velocity * 0.5f;   // 현재 속도를 절반으로 변경
        }
        animator.SetBool("IsGrounded", isGrounded); // Animator 파라미터값을 동일하게 적용 (현재 둘다 bool)
    }

    void Die()
    {
        animator.SetTrigger("DieTrigger");
        source.clip = deathClip;
        source.Play();
        rb2D.velocity = Vector2.zero;
        isDie = true;
        
    }
    private void OnTriggerEnter2D(Collider2D other)      // Trigger Collider을 가진 장애물과 충돌감지
    {
        if (other.CompareTag(deadZone) && !isDie)
        {
            GameManager.instance.isGameOver = true;
            Destroy(other.gameObject);
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)// 바닥에 닿았음을 감지
    {
        if (collision.contacts[0].normal.y > 0.7f)        // 바닥
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", true);
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) // 바닥에 벗어났음을 감지
    {
        if (jumpCount > 0)
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
        }
    }
}
