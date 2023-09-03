using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Courier : MonoBehaviour
{
    public Stock stock;
    public TMP_Text CompletText;
    public TMP_Text BroadCast2;
    public int CourierCount = 0;
    public int CourierComplet = 0;
    public int DeliverTimer = 0;
    public bool CourierDelay = false;
    public float CourierDelayTimer = 3f;
    public float CastTimer = 2f;

    private void Update()
    {
        Delivery2();

        CompletText.text = "포장 완료한 택배 수 " + CourierComplet + "개";

        CastTimer -= Time.deltaTime;

        
        if (CastTimer <= 0)
        {
            BroadCast2.text = "";
            CastTimer = 2f;
        }

        if (CourierDelay == true)
        {
            CourierDelayTimer -= Time.deltaTime;

            if (CourierDelayTimer <= 0)
            {
                CourierDelayTimer = 0f;
                CourierDelay = false;
            }
        }
    }
    public void Courier1()
    {
        CourierCount++;

        if (CourierCount == 1)
        {
            Debug.Log("택배상자 가져옴");
        }
        else if (CourierCount == 2)
        {
            Debug.Log("물품을 택배상자에 넣음");
        }
        else if (CourierCount == 3)
        {
            CourierComplet++;
            CourierCount = 0;
        }
    }
    public void Delivery()
    {
        CourierDelayTimer = 3f;
        CourierDelay = true;
    }

    public void Delivery2()
    {
        if (CourierDelayTimer <= 0)
        {
            if (CourierComplet != 0)
            {
                for (int i = 0; i <= CourierComplet; i++)
                {
                    CourierComplet--;
                    stock.money += 1375;
                }
            }
            else if (CourierComplet == 0)
            {
                BroadCast2.text = "배송 완료!";
                CourierDelayTimer = 3f;
            }
        }
    }
}
