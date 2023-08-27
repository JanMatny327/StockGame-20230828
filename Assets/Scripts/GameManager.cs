using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Stock stock;
    public int GameLife = 3;
    public TMP_Text GameLifeText;

    private void Update()
    {
        MinusMoneyCheck();
    }
    public void MinusMoneyCheck()
    {
        GameLifeText.text = "Game Life : " + GameLife;

        if (stock.money < 0)
        {
            if (GameLife > 0)
            {
                stock.money = 30000;

                GameLife = GameLife - 1;
            }
        }

        if (GameLife == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}