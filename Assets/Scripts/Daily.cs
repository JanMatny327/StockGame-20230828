using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;
using JetBrains.Annotations;
using Microsoft.Win32.SafeHandles;

public class Daily : MonoBehaviour
{
    public Stock stock;
    public TMP_Text Monthly;
    public float DaliyTimer;
    public int Daliy = 30;


    private void Update()
    {
        MonthlyCheck();
        DaliyTimer += Time.deltaTime;

    }



    void MonthlyCheck()
    {
        Monthly.text = "월세납부까지 남은 일 : " + Daliy +"일";

        if (DaliyTimer >= 120)
        {
            Daliy = Daliy - 1;
            DaliyTimer = 0;
        }

        if (Daliy == 0)
        {
            Daliy = 30;
            stock.money = stock.money - 150000;
            
        }
    }
}