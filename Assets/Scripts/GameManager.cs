using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Net.Mail;

public class GameManager : MonoBehaviour
{
    public Stock stock;
    public int GameLife = 3;
    public TMP_Text GameLifeText;
    public TMP_Text remaining_debtText;
    public GameObject DebtInputFieldobj;
    public TMP_InputField DebtInputField;
    int debt = 500000000;
    int debtBttCount = 0;

    private void Start()
    {
        DebtInputFieldobj.SetActive(false);
    }
    void Update()
    {
        remaining_debt();
        remaining_debtText.text = "현재 남은 빚 : " +stock.GetThousandcommaText(debt) + "원";
        MinusMoneyCheck();
    }


    public void MinusMoneyCheck()
    {
        GameLifeText.text = "남은 게임목숨 : " + GameLife + "개";

        if (stock.money < 0)
        {
            if (GameLife > 0)
            {
                stock.money = 250000;

                GameLife = GameLife - 1;
            }
        }

        if (GameLife == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void remaining_debt()
    {
        if (debt <= 0)
        {
            remaining_debtText.text = "빚 상환 완료!";
            SceneManager.LoadScene("GameClear");
        }
    }

    public void InputDebt_Button()
    {
        debtBttCount++;
        if (debtBttCount == 1)
        {
            DebtInputFieldobj.SetActive(true);
        }
        else if (debtBttCount == 2)
        {
            DebtInputFieldobj.SetActive(false);
            debtBttCount = 0;
        }
    }


    public void Debt()
    {
        int count = int.Parse(DebtInputField.text);
        if (stock.money >= count)
        {
            stock.money -= count;
            debt -= count;
            DebtInputFieldobj.SetActive(false);
        }
    }
}