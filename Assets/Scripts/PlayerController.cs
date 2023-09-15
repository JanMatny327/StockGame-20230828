using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 상태")]
    public int hp = 3; // 플레이어 체력
    public float speed = 100.0f; // 이동속도
    public float JumpForce = 50f; // 점프높이
    public bool isJump = false; // 현재 점프상태
    public bool isGround = true; // 현재 바닥인가 여부확인
    public bool isShoot = false; // 현재 총알 발사 상태 여부확인

    float h; 
    float v;
    

    public Rigidbody2D rigid;
    public Animator animator;
    Stock stock;
    Delivery delivery;

    [Header("불러온 컴포넌트")]
    public TMP_Text HPText;


    [Header("클리어 보상")]
    public float ClearMoney;
    public float ClearMoneymin = 1000f;
    public float ClearMoneymax = 10000f;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        stock = GetComponent<Stock>();
    }

    private void Update()
    {
        PlayerStateCheck();
        PlayerAnimation();
        PlayerMove();
    }

    public void PlayerMove()
    {
        // 이동 방향키
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left  * Time.deltaTime * speed);
        }

        // 점프키
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigid.AddForce(new Vector2(0f, JumpForce));
            isJump = true;
        }
        else if (this.transform.position.y > -3.20f)
        {
            isJump = true;
            isGround = false;
        }
        else if (this.transform.position.y <= 3.20f)
        {
            isGround = true;
            isJump = false;
        }
    }

    public void InputShoot()
    {
        if (Input.GetKey(KeyCode.R))
        {
            isShoot = true;
        }
    }
    
    public void PlayerAnimation() 
    {
        Animator t_Animator = this.GetComponent<Animator>();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
        // 이동 애니메이션 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            t_Animator.SetInteger("hAxisRaw", 1);
        }
        else
        {
            t_Animator.SetInteger("hAxisRaw", 0);
        }

        // 점프 애니메이션
        if (isJump == true)
        {
            animator.SetInteger("JumpCount", 1);
        }
        else if (isGround == true &&  isJump == false)
        {
            animator.SetInteger("JumpCount", 0);
        }
    }



    public void PlayerStateCheck()
    {
        HPText.text = "현재 남은 체력 : " + hp;

        if (hp <= 0)
        {
            hp = 3;
            SceneManager.LoadScene("InGame");
            stock.DeliveryFailText.SetActive(true);
            Invoke("FailTextOff", 1.5f);
            stock.money -= 10000;
        }
    }

    private void FailTextOff()
    {
        stock.DeliveryFailText.SetActive(false);
    }

    private void DeliveryComplet()
    {
        if (this.transform.position.x >= delivery.ClearDistance)
        {
            SceneManager.LoadScene("InGame");
            ClearMoney = UnityEngine.Random.Range(ClearMoneymin, ClearMoneymax);
            stock.money += (int)ClearMoney;
            stock.ClearText.text = "목적지까지 배달을 성공하여 배달비를 받았습니다. ( 배달비 : " + (int)ClearMoney + "원)";
            stock.ClearTextobj.SetActive(true);
            Invoke("ClearTextoff", 2f);
        }
    }

    private void ClearTextoff()
    {
        stock.ClearTextobj.SetActive(false);
    }
}

