using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 상태")]
    public int hp = 3;
    public float speed = 100.0f;

    float h;
    float v;
    bool hDown;
    bool hUp;
    bool vDown;
    bool vUp;

    Rigidbody2D rigid;
    bool isHorizonMove;

    public Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        PlayerMove();
        PlayerAnimation();
    }

    public void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                // W와 A를 동시에 누를 때
                transform.Translate((Vector2.up + Vector2.left).normalized * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // W와 D를 동시에 누를 때
                transform.Translate((Vector2.up + Vector2.right).normalized * speed * Time.deltaTime);
            }
            else
            {
                // W만 누를 때
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                // S와 A를 동시에 누를 때
                transform.Translate((Vector2.down + Vector2.left).normalized * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // S와 D를 동시에 누를 때
                transform.Translate((Vector2.down + Vector2.right).normalized * speed * Time.deltaTime);
            }
            else
            {
                // S만 누를 때
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // A만 누를 때
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // D만 누를 때
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    
    public void PlayerAnimation()
    {
        Animator animator = GetComponent<Animator>();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (animator.GetInteger("hAxisRaw") != h)
        {
            animator.SetBool("isChanged", true);
            animator.SetInteger("hAxisRaw", (int)h);
        }
        else if (animator.GetInteger("vAxisRaw") != v)
        {
            animator.SetBool("isChanged", true);
            animator.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            animator.SetBool("isChanged", false);
        }
    }



}

