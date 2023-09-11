using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using static Unity.Collections.AllocatorManager;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;
using System.ComponentModel.Design;

public class StockBox : MonoBehaviour
{
    [Header("스크립트 오브젝트 관리")]
    public GameObject[] objBox;
    public Stock stock;
    public TMP_Text[] Stocklist;
    public TMP_Text[] StockChangedlist;
    public TMP_Text StockTimerText;
    public TMP_Text BroadCastText;
    public GameObject BroadCast;

    [Header ("주식 관리")]
    public float Timer = 30;
    public float Stockpercent;
    public float Stockpercent2;
    public float Stockpercent3;
    public float Stockpercent4;
    public float Stockpercent5;
    public float stockChange;
    public float stockChange2;
    public float stockChange3;
    public float stockChange4;
    public float stockChange5;
    public float minpercent = -50;
    public float maxpercent = 50;
    public bool OnBroadCast = false;

    [Header("주식 현재 가격 카운팅")]
    public int Junstockcounting = 55000;
    public int Sangstockcounting = 35000;
    public int Chanstockcounting = 100000;
    public int Yeastockcounting = 70000;
    public int Hisustockcounting = 60000;


    private void Update()
    {
        CheckStockUI();
        RandomStock();
        StockCheck();
        Timer -= Time.deltaTime;
        if (Timer > 0)
        {
            StockTimerText.text = FormatTime((int)Timer);
        }
        else if (Timer <= 0)
        {
            StockTimerText.text = ""+(int)Timer;
        }
    }

    public void RandomStock()
    {
        if (Timer <= 0)
        {
            Timer = 180;


            Stockpercent = UnityEngine.Random.Range(minpercent, maxpercent);
            Stockpercent2 = UnityEngine.Random.Range(minpercent, maxpercent);
            Stockpercent3 = UnityEngine.Random.Range(minpercent, maxpercent);
            Stockpercent4 = UnityEngine.Random.Range(minpercent, maxpercent);
            Stockpercent5 = UnityEngine.Random.Range(minpercent, maxpercent);
            stockChange = Junstockcounting * (Stockpercent / 100.0f);
            Junstockcounting += (int)stockChange;
            stockChange2 = Sangstockcounting * (Stockpercent2 / 100.0f);
            Sangstockcounting += (int)stockChange2;
            stockChange3 = Sangstockcounting * (Stockpercent3 / 100.0f);
            Chanstockcounting += (int)stockChange3;
            stockChange4 = Yeastockcounting * (Stockpercent4 / 100.0f);
            Yeastockcounting += (int)stockChange4;
            stockChange5 = Hisustockcounting * (Stockpercent5 / 100.0f);
            Hisustockcounting += (int)stockChange5;
            BroadCastText.text = "주식이 변동되었습니다.";
            StockTimerText.text = (int)Timer + "초";
            StockChangedlist[0].text = "변동값 : " + (int)stockChange + "(" + Stockpercent + "%)";
            StockChangedlist[1].text = "변동값 : " + (int)stockChange2 + "(" + Stockpercent2 + "%)";
            StockChangedlist[2].text = "변동값 : " + (int)stockChange3 + "(" + Stockpercent3 + "%)";
            StockChangedlist[3].text = "변동값 : " + (int)stockChange4 + "(" + Stockpercent4 + "%)";
            StockChangedlist[4].text = "변동값 : " + (int)stockChange5 + "(" + Stockpercent5 + "%)";
            OnBroadCast = true;
        }
    }

    public void CheckStockUI()
    {
        Stocklist[0].text = "준식당 : " + stock.GetThousandcommaText(Junstockcounting) + "원";
        Stocklist[1].text = "상희공장 : " + stock.GetThousandcommaText(Sangstockcounting) + "원";
        Stocklist[2].text = "찬영컴퍼니 : " + stock.GetThousandcommaText(Chanstockcounting) + "원";
        Stocklist[3].text = "예찬게임즈 : " + stock.GetThousandcommaText(Yeastockcounting) + "원";
        Stocklist[4].text = "희수전자 : " + stock.GetThousandcommaText(Hisustockcounting) + "원";
    }


    public void StockBuy()
    {
        
    }

    public void StockCheck()
    {
        if (Junstockcounting <= 100)
        {
            objBox[0].SetActive(false);
            objBox[5].SetActive(true);
            BroadCast.SetActive(true);
            OnBroadCast = true;
        }

        if (Sangstockcounting <= 100)
        {
            objBox[1].SetActive(false);
            objBox[6].SetActive(true);
            BroadCast.SetActive(true);
            OnBroadCast = true;
        }

        if (Chanstockcounting <= 100)
        {
            objBox[2].SetActive(false);
            objBox[7].SetActive(true);
            BroadCast.SetActive(true);
            OnBroadCast = true;
        }

        if (Yeastockcounting <= 100)
        {
            objBox[3].SetActive(false);
            objBox[8].SetActive(true);
            BroadCast.SetActive(true);
            OnBroadCast = true;
        }

        if (Hisustockcounting <= 100)
        {
            objBox[4].SetActive(false);
            objBox[9].SetActive(true);
            BroadCast.SetActive(true);
            Hisustockcounting = 0;
            OnBroadCast = true;
        }
    }

    public string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int hours = Mathf.FloorToInt(minutes / 60);

        string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        return timeText;
    }
}
