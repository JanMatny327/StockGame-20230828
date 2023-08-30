using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using static Unity.Collections.AllocatorManager;
using UnityEditor.Experimental.GraphView;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;
using System.ComponentModel.Design;

public class Stock : MonoBehaviour
{
    public Daily daily;
    public Color StartColor;
    public Color EndColor;
    public float Timer;
    public GameObject BroadCast;
    public GameObject Jun;
    public GameObject Jundie;
    public GameObject Sang;
    public GameObject Sangdie;
    public GameObject Chan;
    public GameObject Chandie;
    public GameObject Yea;
    public GameObject Yeadie;
    public GameObject Hisu;
    public GameObject Hisudie;
    public TMP_Text StockTimerText;
    public TMP_Text JunText;
    public TMP_Text SangText;
    public TMP_Text ChanText;
    public TMP_Text YeaText;
    public TMP_Text HisuText;
    public TMP_Text Jun2Text;
    public TMP_Text Sang2Text;
    public TMP_Text Chan2Text;
    public TMP_Text Yea2Text;
    public TMP_Text Hisu2Text;
    public TMP_Text Money1;
    public TMP_Text BroadCastText;
    public TMP_Text holdingJunstock;
    public TMP_Text holdingSangstock;
    public TMP_Text holdingChanstock;
    public TMP_Text holdingYeastock;
    public TMP_Text holdingHisustock;
    public int holding_Junstock = 0;
    public int holding_Sangstock = 0;
    public int holding_Chanstock = 0;
    public int holding_Yeastock = 0;
    public int holding_Hisustock = 0;
    public int Junstockcounting;
    public int Sangstockcounting;
    public int Chanstockcounting;
    public int Yeastockcounting;
    public int Hisustockcounting;
    public int money;
    float minpercent = -45;
    float maxpercent = 45;
    public float Nope = 0.5f;
    public float RandomEventTimer = 0;
    public float RandomEventTimer1 = 0;
    public float RandomEventTimer2 = 10;
    public float NopeCount = -10;
    public float EventCount = 10;
    public int EventCount1 = 0;
    public int EventCount2 = 9;
    public float minuspercent1 = -10;
    public float minuspercent2 = -30;
    public float pluspercent1 = +10;
    public float pluspercent2 = +30;
    public bool EventCheck = false;
    public float RandomEventTime;
    float Stockpercent;
    float Stockpercent1;
    float Stockpercent2;
    float Stockpercent3;
    float Stockpercent4;
    float Stockpercent5;
    float stockChange;
    float stockChange1;
    float stockChange2;
    float stockChange3;
    float stockChange4;
    float stockChange5;
    public bool OnBroadCast = false;


    void Start()
    {
        
    }
    void Update()
    {
        CheckEventCount();
        RandomEvent();
        StartCoroutine(BroadCastCheck());
        MyInfo();
        StockCheck();
        RandomStock();
        Timer -= Time.deltaTime;
        RandomEventTimer += Time.deltaTime;
        StockTimerText.text = (int)Timer + "초";
        Money1.text = GetThousandcommaText(money) + "원";

    }
    IEnumerator BroadCastCheck()
    {
        while (StartColor.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            StartColor.a = StartColor.a - 0.1f * Time.deltaTime;
            BroadCastText.color = StartColor;
            BroadCastText.text = "";

            if (!OnBroadCast)
            {
                StartColor.a = 200;
                yield break;
            }
        }
    }

    public void RandomStock()
    {
        if (Timer <= 0)
        {
            Timer = 180;


            Stockpercent = Random.Range(minpercent, maxpercent);
            Stockpercent2 = Random.Range(minpercent, maxpercent);
            Stockpercent3 = Random.Range(minpercent, maxpercent);
            Stockpercent4 = Random.Range(minpercent, maxpercent);
            Stockpercent5 = Random.Range(minpercent, maxpercent);
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
            JunText.text = "준식당 : " + GetThousandcommaText(Junstockcounting) + "원";
            SangText.text = "상희공장 : " + GetThousandcommaText(Sangstockcounting) + "원";
            ChanText.text = "찬영컴퍼니 : " + GetThousandcommaText(Chanstockcounting) + "원";
            YeaText.text = "예찬게임즈 : " + GetThousandcommaText(Yeastockcounting) + "원";
            HisuText.text = "희수전자 : " + GetThousandcommaText(Hisustockcounting) + "원";
            Jun2Text.text = "변동값 : " + (int)stockChange + "(" + Stockpercent + "%)";
            Sang2Text.text = "변동값 : " + (int)stockChange2 + "(" + Stockpercent2 + "%)";
            Chan2Text.text = "변동값 : " + (int)stockChange3 + "(" + Stockpercent3 + "%)";
            Yea2Text.text = "변동값 : " + (int)stockChange4 + "(" + Stockpercent4 + "%)";
            Hisu2Text.text = "변동값 : " + (int)stockChange5 + "(" + Stockpercent5 + "%)";
            OnBroadCast = true;
        }        
    }

    public void CheckEventCount()
    {
        if (EventCheck == true)
        {
            RandomEventTime = Random.Range(RandomEventTimer1, RandomEventTimer2);
            EventCheck = false;
        }
    }


    public void RandomEvent()
    {
        if (RandomEventTimer >= RandomEventTimer1 || RandomEventTimer >= RandomEventTimer2)
        {
            float RandomEventTime = Random.Range(NopeCount, EventCount);


            if (RandomEventTime == EventCount == true)
            {
                int RandomEventif = Random.Range(EventCount1, EventCount2);
                RandomEventTimer = 0;
                if (EventCount1 == 0)
                {
                    float Event1 = Random.Range(minuspercent1, minuspercent2);
                    BroadCastText.text = "준식당에서 제공하는 음식메뉴에서 벌레가 나오는 것이 확인됨!";
                    Junstockcounting = Junstockcounting - (int)Event1;
                    JunText.text = "준식당 : " + GetThousandcommaText(Junstockcounting) + "원";
                    Jun2Text.text = "변동값 : " + stockChange + "(" + Stockpercent + "%)";
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 1)
                {
                    float Event2 = Random.Range(minuspercent1, minuspercent2);
                    BroadCastText.text = "상희공장에서 제공하는 제품중에서 결함이 발견됨!";
                    Sangstockcounting = Sangstockcounting - (int)Event2;
                    SangText.text = "상희공장 : " + GetThousandcommaText(Sangstockcounting) + "원";
                    Sang2Text.text = "변동값 : " + stockChange2 + "(" + Stockpercent2 + "%)";
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 2)
                {
                    float Event3 = Random.Range(minuspercent1, minuspercent2);
                    BroadCastText.text = "찬영컴퍼니에서을 왕따하는 사건이 발켜짐!";
                    ChanText.text = "찬영컴퍼니 : " + GetThousandcommaText(Chanstockcounting) + "원";
                    Chan2Text.text = "변동값 : " + stockChange3 + "(" + Stockpercent3 + "%)";
                    Chanstockcounting = Chanstockcounting - (int)Event3;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 3)
                {
                    float Event4 = Random.Range(minuspercent1, minuspercent2);
                    BroadCastText.text = "예찬게임즈 YeaRPG게임 장비뽑기 확률조작이 발켜짐!";
                    YeaText.text = "예찬게임즈 : " + GetThousandcommaText(Yeastockcounting) + "원";
                    Yea2Text.text = "변동값 : " + stockChange4 + "(" + Stockpercent4 + "%)";
                    Yeastockcounting = Yeastockcounting - (int)Event4;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 4)
                {
                    float Event5 = Random.Range(minuspercent1, minuspercent2);
                    BroadCastText.text = "희수전자 고수사장이 돈을 갖고 해외로 도주함!";
                    HisuText.text = "희수전자 : " + GetThousandcommaText(Hisustockcounting) + "원";
                    Hisu2Text.text = "변동값 : " + stockChange5 + "(" + Stockpercent5 + "%)";
                    Hisustockcounting = Hisustockcounting - (int)Event5;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 5)
                {
                    float Event6 = Random.Range(pluspercent1, pluspercent2);
                    BroadCastText.text = "희수전자 Max폰11 출시예정 사실이 기자진을 통해 공개됨!";
                    HisuText.text = "희수전자 : " + GetThousandcommaText(Hisustockcounting) + "원";
                    Hisu2Text.text = "변동값 : " + stockChange5 + "(" + Stockpercent5 + "%)";
                    Hisustockcounting = Hisustockcounting + (int)Event6;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 6)
                {
                    float Event7 = Random.Range(pluspercent1, pluspercent2);
                    BroadCastText.text = "예찬게임즈 GG 게임 공개예정일 발표!";
                    YeaText.text = "예찬게임즈 : " + GetThousandcommaText(Yeastockcounting) + "원";
                    Yea2Text.text = "변동값 : " + stockChange4 + "(" + Stockpercent4 + "%)";
                    Yeastockcounting = Yeastockcounting - (int)Event7;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 7)
                {
                    float Event8 = Random.Range(pluspercent1, pluspercent2);
                    BroadCastText.text = "찬영컴퍼니 유럽까지 진출성공!";
                    ChanText.text = "찬영컴퍼니 : " + GetThousandcommaText(Chanstockcounting) + "원";
                    Chan2Text.text = "변동값 : " + stockChange3 + "(" + Stockpercent3 + "%)";
                    Chanstockcounting = Chanstockcounting + (int)Event8;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 8)
                {
                    float Event9 = Random.Range(pluspercent1, pluspercent2);
                    BroadCastText.text = "상희공장 희수전자와 협업하여 Max폰11 제작 지원 발표!";
                    SangText.text = "상희공장 : " + GetThousandcommaText(Sangstockcounting) + "원";
                    Sang2Text.text = "변동값 : " + stockChange2 + "(" + Stockpercent2 + "%)";
                    Sangstockcounting = Sangstockcounting - (int)Event9;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (EventCount1 == 9)
                {
                    float Event10 = Random.Range(pluspercent1, pluspercent2);
                    BroadCastText.text = "준식당에서 새로 나온 신메뉴 한국 너머 유럽까지 열광중!";
                    JunText.text = "준식당 : " + GetThousandcommaText(Junstockcounting) + "원";
                    Jun2Text.text = "변동값 : " + stockChange2 + "(" + Stockpercent2 + "%)";
                    Junstockcounting = Junstockcounting + (int)Event10;
                    OnBroadCast = true;
                    EventCheck = true;
                }
                else if (RandomEventTime == Nope == true)
                {
                    RandomEventTimer = 0;
                    EventCheck = true;
                    return;
                }
            }
        }
    }

    public string GetThousandcommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }

    public void StockCheck()
    {
        if (Junstockcounting <= 0)
        {
            Jun.SetActive(false);
            Jundie.SetActive(true);
            BroadCast.SetActive(true);
            BroadCastText.text = "준식당 주식이 상장폐지되었습니다.";
            OnBroadCast = true;
        }

        if (Sangstockcounting <= 0)
        {
            Sang.SetActive(false);
            Sangdie.SetActive(true);
            BroadCast.SetActive(true);
            BroadCastText.text = "상희공장 주식이 상장폐지되었습니다.";
            OnBroadCast = true;
        }

        if (Chanstockcounting <= 0)
        {
            Chan.SetActive(false);
            Chandie.SetActive(true);
            BroadCast.SetActive(true);
            BroadCastText.text = "찬영컴퍼니 주식이 상장폐지되었습니다.";
            OnBroadCast = true;
        }

        if (Yeastockcounting <= 0)
        {
            Yea.SetActive(false);
            Yeadie.SetActive(true);
            BroadCast.SetActive(true);
            BroadCastText.text = "예찬게임즈 주식이 상장폐지되었습니다.";
            OnBroadCast = true;
        }

        if (Hisustockcounting <= 0)
        {
            Hisu.SetActive(false);
            Hisudie.SetActive(true);
            BroadCast.SetActive(true);
            BroadCastText.text = "희수전자 주식이 상장폐지되었습니다.";
            OnBroadCast = true;
        }
        return;
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
        if (money >= Junstockcounting)
        {
            money = money - Junstockcounting;
            holding_Junstock = holding_Junstock + 1;
        }
        return;
    }

    public void SellJunstock()
    {
        if (holding_Junstock > 0)
        {
            money = money + Junstockcounting;
            holding_Junstock = holding_Junstock - 1;
        }
        return;
    }

    public void Buy_Sangstock()
    {
        if (money >= Sangstockcounting)
        {
            money = money - Sangstockcounting;
            holding_Sangstock = holding_Sangstock + 1;
        }
        return;
    }

    public void SellSangstock()
    {
        if (holding_Sangstock > 0)
        {
            money = money + Sangstockcounting;
            holding_Sangstock = holding_Sangstock - 1;
        }
        return;
    }

    public void Buychanstock()
    {
        if (money >= Chanstockcounting)
        {
            money = money - Chanstockcounting;
            holding_Chanstock = holding_Chanstock + 1;
        }
        return;
    }

    public void Sellchanstock()
    {
        if (holding_Chanstock > 0)
        {
            money = money + Chanstockcounting;
            holding_Chanstock = holding_Chanstock - 1;
        }
    }

    public void BuyYeastock()
    {
        if (money >= Yeastockcounting)
        {
            money = money - Yeastockcounting;
            holding_Yeastock = holding_Yeastock + 1;
        }
        return;
    }

    public void SellYeastock()
    {
        if (holding_Yeastock > 0 )
        {
            money = money + Yeastockcounting;
            holding_Yeastock = holding_Yeastock - 1;
        }
        return;
    }
    public void BuyHisustock()
    {
        if (money >= Hisustockcounting)
        {
            money = money - Hisustockcounting;
            holding_Hisustock = holding_Hisustock + 1;
        }
        return;
    }

    public void SellHisustock()
    {
        if (holding_Hisustock > 0)
        {
            money = money + Hisustockcounting;
            holding_Hisustock = holding_Hisustock - 1;
        }
        return;
    }
}

