using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("적 현재 상태")]
    public float EnemyHp = 3f;
    public float speed = 2.5f;


    PlayerController playerController;

    private void Awake()
    {
        GetComponent<PlayerController>();
    }

    private void Update()
    {
        
    }

    private void EnemyAutoMove()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerController.hp > 0)
            {
                playerController.hp -= 1;
                Destroy(this.gameObject);
            }
            else if (playerController.hp <= 0)
            {
                return;   
            }
        }
        
    }

    
}
