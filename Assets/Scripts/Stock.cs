using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using static Unity.Collections.AllocatorManager;
using UnityEditor.Experimental.GraphView;

public class Stock : MonoBehaviour
{
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
    public bool OnBroadCast = false;

    void Start()
    {
        
    }
    void Update()
    {
        StartCoroutine(BroadCastCheck());
        MyInfo();
        StockCheck();
        RandomStock();
        Timer -= Time.deltaTime;
        StockTimerText.text = (int)Timer + "초";
        Money1.text = GetThousandcommaText(money) + "원";
    }
    IEnumerator BroadCastCheck()
    {
        if (OnBroadCast == true)
        {
            BroadCastText.color = StartColor;

            while (StartColor.a > 0)
            {
                yield return new WaitForSeconds(0.1f);
                StartColor.a = StartColor.a - 0.1f * Time.deltaTime;
                BroadCastText.color = StartColor;
                BroadCastText.text = "";
            }
        }
        OnBroadCast = false;
        yield break;
    }

    public void RandomStock()
    {
        if (Timer <= 0)
        {
            Timer = 180;


            float Stockpercent = Random.Range(minpercent, maxpercent);
            float Stockpercent2 = Random.Range(minpercent, maxpercent);
            float Stockpercent3 = Random.Range(minpercent, maxpercent);
            float Stockpercent4 = Random.Range(minpercent, maxpercent);
            float Stockpercent5 = Random.Range(minpercent, maxpercent);
            float stockChange = Junstockcounting * (Stockpercent / 100.0f);
            Junstockcounting += (int)stockChange;
            float stockChange2 = Sangstockcounting * (Stockpercent2 / 100.0f);
            Sangstockcounting += (int)stockChange2;
            float stockChange3 = Sangstockcounting * (Stockpercent3 / 100.0f);
            Chanstockcounting += (int)stockChange3;
            float stockChange4 = Yeastockcounting * (Stockpercent4 / 100.0f);
            Yeastockcounting += (int)stockChange4;
            float stockChange5 = Hisustockcounting * (Stockpercent5 / 100.0f);
            Hisustockcounting += (int)stockChange5;
            BroadCastText.text = "주식이 변동되었습니다.";
            StockTimerText.text = (int)Timer + "초";
            JunText.text = "준식당 : " + GetThousandcommaText(Junstockcounting) + "원";
            SangText.text = "상희공장 : " + GetThousandcommaText(Sangstockcounting) + "원";
            ChanText.text = "찬영컴퍼니 : " + GetThousandcommaText(Chanstockcounting) + "원";
            YeaText.text = "예찬게임즈 : " + GetThousandcommaText(Yeastockcounting) + "원";
            HisuText.text = "희수전자 : " + GetThousandcommaText(Hisustockcounting) + "원";
            Jun2Text.text = "변동값 : " + (int)stockChange + "("+Stockpercent+"%)";
            Sang2Text.text = "변동값 : " + (int)stockChange2 + "("+ Stockpercent2 +"%)";
            Chan2Text.text = "변동값 : " + (int)stockChange3 + "("+ Stockpercent3 +"%)";
            Yea2Text.text = "변동값 : " + (int)stockChange4 + "("+ Stockpercent4 +"%)";
            Hisu2Text.text = "변동값 : " + (int)stockChange5 + "("+ Stockpercent5 +"%)";
            OnBroadCast = true;
        }
        return;
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
        if (money >= 0)
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

