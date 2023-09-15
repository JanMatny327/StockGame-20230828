using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("적 현재 상태")]
    public float EnemyHp = 3f;
    public float speed = 2.5f;


    [Header("컴포넌트 받아오기")]
    public GameObject EnemyObject;
    public PlayerController playerController;
    public BoxCollider2D boxCollider2D;


    private void Awake()
    {
        GetComponent<PlayerController>();
    }

    private void Update()
    {
        EnemyAutoMove();
    }
    private void EnemyAutoMove()
    {
        transform.Translate(Vector2.left * Time.deltaTime * this.speed);

        if (this.transform.position.x < -4.9f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.playerController = collision.GetComponent<PlayerController>();
            if (playerController.hp != 0)
            {
                playerController.hp -= 1;
                Destroy(this.gameObject);
            }
            else if (playerController.hp == 0)
            {
                return;   
            }
        }
        
    }

    
}
