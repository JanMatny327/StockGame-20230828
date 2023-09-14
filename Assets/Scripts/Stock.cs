using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using static Unity.Collections.AllocatorManager;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;
using System.ComponentModel.Design;
using Unity.VisualScripting;

public class Stock : MonoBehaviour
{
    [Header("오브젝트 or 텍스트 or 스크립트 관리")]
    public StockBox stockBox;
    public Daily daily;
    public Color StartColor;
    public Color EndColor;
    public TMP_Text Money1;
    public TMP_Text holdingJunstock;
    public TMP_Text holdingSangstock;
    public TMP_Text holdingChanstock;
    public TMP_Text holdingYeastock;
    public TMP_Text holdingHisustock;

    [Header("주식관련 관리")]
    public int holding_Junstock = 0;
    public int holding_Sangstock = 0;
    public int holding_Chanstock = 0;
    public int holding_Yeastock = 0;
    public int holding_Hisustock = 0;
    public int money;
    public float Nope = 0.5f;
    public float RandomEventTimer = 0;
    public float RandomEventTimer1 = 0;
    public float RandomEventTimer2 = 45f;
    public float RandomEventTimer3 = 130f;
    public int RandomEventif = 0;
    public int EventCount1 = 1;
    public int EventCount2 = 10;
    public float minuspercent1 = -10f;
    public float minuspercent2 = -30f;
    public float pluspercent1 = +10f;
    public float pluspercent2 = +30f;
    public bool EventCheck = true;

    [Header("부가컨텐츠 관리")]
    public GameObject DeliveryFailText;
   
   


    void Start()
    {
        
    }
    void Update()
    {
        CheckEventCount();
        RandomEvent();
        StartCoroutine(BroadCastCheck());
        MyInfo();
        RandomEventTimer += Time.deltaTime;
        stockBox.BroadCastText.color = StartColor;

        if (money > 0)
        {
            Money1.text = GetThousandcommaText(money) + "원";
        }
        else if (money <= 0)
        {
            Money1.text = money + "원";
        }
    }

    


    IEnumerator BroadCastCheck()
    {
        while (stockBox.OnBroadCast == true)
        {
            yield return new WaitForSeconds(1f);
            StartColor.a -= 0.2f * Time.deltaTime;


            if (StartColor.a <= 0)
            {
                stockBox.BroadCastText.text = "";
                stockBox.OnBroadCast = false;
                StartColor.a = EndColor.a;
                yield break;
            }
    
        }
    }


    public void CheckEventCount()
    {
        if (EventCheck == true)
        {
            RandomEventif = 0;
            RandomEventTimer = 0;
            RandomEventTimer1 = Random.Range(RandomEventTimer2, RandomEventTimer3);
            EventCheck = false;
        }
    }


    public void RandomEvent()
    {
        if (RandomEventTimer >= RandomEventTimer1)
        {
            float RandomEventif = Random.Range(EventCount1, EventCount2);
                    
            if (RandomEventif == 1)
            {
                float Event1 = Random.Range(minuspercent1, minuspercent2);
                stockBox.stockChange = stockBox.Junstockcounting * (Event1 / 100.0f);
                stockBox.Junstockcounting += (int)stockBox.stockChange;
                stockBox.BroadCastText.text = "준식당에서 제공하는 음식메뉴에서 벌레가 나오는 것이 확인됨!";
                stockBox.Stocklist[0].text = "준식당 : " + GetThousandcommaText(stockBox.Junstockcounting) + "원";
                stockBox.StockChangedlist[0].text = "변동값 : " + stockBox.stockChange + "(" + Event1 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 2)
            {
                float Event2 = Random.Range(minuspercent1, minuspercent2);
                stockBox.stockChange2 = stockBox.Sangstockcounting * (Event2 / 100.0f);
                stockBox.Sangstockcounting += (int)stockBox.stockChange2;
                stockBox.BroadCastText.text = "상희공장에서 제공하는 제품중에서 결함이 발견됨!";
                stockBox.Stocklist[1].text = "상희공장 : " + GetThousandcommaText(stockBox.Sangstockcounting) + "원";
                stockBox.StockChangedlist[1].text = "변동값 : " + stockBox.stockChange2 + "(" + Event2 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 3)
            {
                float Event3 = Random.Range(minuspercent1, minuspercent2);
                stockBox.stockChange3 = stockBox.Chanstockcounting * (Event3 / 100.0f);
                stockBox.Chanstockcounting += (int)stockBox.stockChange3;
                stockBox.BroadCastText.text = "찬영컴퍼니에서을 왕따하는 사건이 발켜짐!";
                stockBox.Stocklist[2].text = "찬영컴퍼니 : " + GetThousandcommaText(stockBox.Chanstockcounting) + "원";
                stockBox.StockChangedlist[2].text = "변동값 : " + stockBox.stockChange3 + "(" + Event3 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 4)
            {
                float Event4 = Random.Range(minuspercent1, minuspercent2);
                stockBox.stockChange4 = stockBox.Yeastockcounting * (Event4 / 100.0f);
                stockBox.Yeastockcounting += (int)stockBox.stockChange4;
                stockBox.BroadCastText.text = "예찬게임즈 YeaRPG게임 장비뽑기 확률조작이 발켜짐!";
                stockBox.Stocklist[3].text = "예찬게임즈 : " + GetThousandcommaText(stockBox.Yeastockcounting) + "원";
                stockBox.StockChangedlist[3].text = "변동값 : " + stockBox.stockChange4 + "(" + Event4 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 5)
            {
                float Event5 = Random.Range(minuspercent1, minuspercent2);
                stockBox.stockChange5 = stockBox.Hisustockcounting * (Event5 / 100.0f);
                stockBox.Hisustockcounting += (int)stockBox.stockChange5;
                stockBox.BroadCastText.text = "희수전자 고수사장이 돈을 갖고 해외로 도주함!";
                stockBox.Stocklist[4].text = "희수전자 : " + GetThousandcommaText(stockBox.Hisustockcounting) + "원";
                stockBox.StockChangedlist[4].text = "변동값 : " + stockBox.stockChange5 + "(" + Event5 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 6)
            {
                float Event6 = Random.Range(pluspercent1, pluspercent2);
                stockBox.stockChange5 = stockBox.Hisustockcounting * (Event6 / 100.0f);
                stockBox.Hisustockcounting += (int)stockBox.stockChange5;
                stockBox.BroadCastText.text = "희수전자 Max폰11 출시예정 사실이 기자진을 통해 공개됨!";
                stockBox.Stocklist[4].text = "희수전자 : " + GetThousandcommaText(stockBox.Hisustockcounting) + "원";
                stockBox.StockChangedlist[4].text = "변동값 : " + stockBox.stockChange5 + "(" + Event6 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 7)
            {
                float Event7 = Random.Range(pluspercent1, pluspercent2);
                stockBox.stockChange4 = stockBox.Yeastockcounting * (Event7 / 100.0f);
                stockBox.Yeastockcounting += (int)stockBox.stockChange4;
                stockBox.BroadCastText.text = "예찬게임즈 GG 게임 공개예정일 발표!";
                stockBox.Stocklist[3].text = "예찬게임즈 : " + GetThousandcommaText(stockBox.Yeastockcounting) + "원";
                stockBox.StockChangedlist[3].text = "변동값 : " + stockBox.stockChange4 + "(" + Event7 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 8)
            {
                float Event8 = Random.Range(pluspercent1, pluspercent2);
                stockBox.stockChange3 = stockBox.Chanstockcounting * (Event8 / 100.0f);
                stockBox.Chanstockcounting += (int)stockBox.stockChange3;
                stockBox.BroadCastText.text = "찬영컴퍼니 유럽까지 진출성공!";
                stockBox.Stocklist[2].text = "찬영컴퍼니 : " + GetThousandcommaText(stockBox.Chanstockcounting) + "원";
                stockBox.StockChangedlist[2].text = "변동값 : " + stockBox.stockChange3 + "(" + Event8 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 9)
            {
                float Event9 = Random.Range(pluspercent1, pluspercent2);
                stockBox.stockChange2 = stockBox.Sangstockcounting * (Event9 / 100.0f);
                stockBox.Sangstockcounting += (int)stockBox.stockChange2;
                stockBox.BroadCastText.text = "상희공장 희수전자와 협업하여 Max폰11 제작 지원 발표!";
                stockBox.Stocklist[1].text = "상희공장 : " + GetThousandcommaText(stockBox.Sangstockcounting) + "원";
                stockBox.StockChangedlist[1].text = "변동값 : " + stockBox.stockChange2 + "(" + Event9 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }
            else if (RandomEventif == 10)
            {
                float Event10 = Random.Range(pluspercent1, pluspercent2);
                stockBox.stockChange = stockBox.Junstockcounting * (Event10 / 100.0f);
                stockBox.Junstockcounting += (int)stockBox.stockChange;
                stockBox.BroadCastText.text = "준식당에서 새로 나온 신메뉴 한국 너머 유럽까지 열광중!";
                stockBox.Stocklist[0].text = "준식당 : " + GetThousandcommaText(stockBox.Junstockcounting) + "원";
                stockBox.Stocklist[0].text = "변동값 : " + stockBox.stockChange + "(" + Event10 + "%)";
                stockBox.OnBroadCast = true;
                EventCheck = true;
            }         
        }
    }

    public string GetThousandcommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }


    

    public void MyInfo()
    {
        holdingJunstock.text = "보유중인 준식당 주식 : " + holding_Junstock + "주";
        holdingSangstock.text = "보유중인 상희공장 주식 : " + holding_Sangstock + "주";
        holdingChanstock.text = "보유중인 찬영컴퍼니 주식 " + holding_Chanstock + "주";
        holdingYeastock.text = "보유중인 예찬게임즈 주식 " + holding_Yeastock + "주";
        holdingHisustock.text = "보유중인 희수전자 주식 " + holding_Hisustock + "주";
        return;
    }
    public void Holding_Stock_Jun()
    {
        if (money >= stockBox.Junstockcounting)
        {
            money = money - stockBox.Junstockcounting;
            holding_Junstock = holding_Junstock + 1;
        }
        return;
    }

    public void SellJunstock()
    {
        if (holding_Junstock > 0)
        {
            money = money + stockBox.Junstockcounting;
            holding_Junstock = holding_Junstock - 1;
        }
        return;
    }

    public void Buy_Sangstock()
    {
        if (money >= stockBox.Sangstockcounting)
        {
            money = money - stockBox.Sangstockcounting;
            holding_Sangstock = holding_Sangstock + 1;
        }
        return;
    }

    public void SellSangstock()
    {
        if (holding_Sangstock > 0)
        {
            money = money + stockBox.Sangstockcounting;
            holding_Sangstock = holding_Sangstock - 1;
        }
        return;
    }

    public void Buychanstock()
    {
        if (money >= stockBox.Chanstockcounting)
        {
            money = money - stockBox.Chanstockcounting;
            holding_Chanstock = holding_Chanstock + 1;
        }
        return;
    }

    public void Sellchanstock()
    {
        if (holding_Chanstock > 0)
        {
            money = money + stockBox.Chanstockcounting;
            holding_Chanstock = holding_Chanstock - 1;
        }
    }

    public void BuyYeastock()
    {
        if (money >= stockBox.Yeastockcounting)
        {
            money = money - stockBox.Yeastockcounting;
            holding_Yeastock = holding_Yeastock + 1;
        }
        return;
    }

    public void SellYeastock()
    {
        if (holding_Yeastock > 0 )
        {
            money = money + stockBox.Yeastockcounting;
            holding_Yeastock = holding_Yeastock - 1;
        }
        return;
    }
    public void BuyHisustock()
    {
        if (money >= stockBox.Hisustockcounting)
        {
            money = money - stockBox.Hisustockcounting;
            holding_Hisustock = holding_Hisustock + 1;
        }
        return;
    }

    public void SellHisustock()
    {
        if (holding_Hisustock > 0)
        {
            money = money + stockBox.Hisustockcounting;
            holding_Hisustock = holding_Hisustock - 1;
        }
        return;
    }
}

