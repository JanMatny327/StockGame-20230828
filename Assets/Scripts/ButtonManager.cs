using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject InGameUI;
    public GameObject JunStock;
    public GameObject SangStock;
    public GameObject ChanStock;
    public GameObject YeaStock;
    public GameObject HisuStock;
    public GameObject MyInfoUI;
    public GameObject StockButton_2;
    public GameObject Cancel;
    public void ButtonInput_JunStock()
    {
        InGameUI.SetActive(false);
        JunStock.SetActive(true);
        StockButton_2.SetActive(false);
        Cancel.SetActive(false);
    }

    public void ButtonInput_SangStock()
    {
        InGameUI.SetActive(false);
        SangStock.SetActive(true);
        StockButton_2.SetActive(false);
        Cancel.SetActive(false);
    }

    public void ButtonInput_ChanStock()
    {
        InGameUI.SetActive(false);
        ChanStock.SetActive(true);
        StockButton_2.SetActive(false);
        Cancel.SetActive(false);
    }

    public void ButtonInput_YeaStock()
    {
        InGameUI.SetActive(false);
        YeaStock.SetActive(true);
        StockButton_2.SetActive(false);
        Cancel.SetActive(false);
    }

    public void ButtonInput_HisuStock()
    {
        InGameUI.SetActive(false);
        HisuStock.SetActive(true);
        StockButton_2.SetActive(false);
        Cancel.SetActive(false);
    }

    public void CancelButton_Jun()
    {
        InGameUI.SetActive(true);
        JunStock.SetActive(false);
        StockButton_2.SetActive(true);
        Cancel.SetActive(true);
    }

    public void CancelButton_SangStock()
    {
        InGameUI.SetActive(true);
        SangStock.SetActive(false);
        StockButton_2.SetActive(true);
        Cancel.SetActive(true);
    }

    public void CancelButton_ChanStock()
    {
        InGameUI.SetActive(true);
        ChanStock.SetActive(false);
        StockButton_2.SetActive(true);
        Cancel.SetActive(true);
    }

    public void CancelButton_YeaStock()
    {
        InGameUI.SetActive(true);
        YeaStock.SetActive(false);
        StockButton_2.SetActive(true);
        Cancel.SetActive(true);
    }

    public void CancelButton_HisuStock()
    {
        InGameUI.SetActive(true);
        HisuStock.SetActive(false);
        StockButton_2.SetActive(true);
        Cancel.SetActive(true);
    }

    public void InputMyInfo_Button()
    {
        MyInfoUI.SetActive(true);
    }

    public void CancelButton_MyInfo()
    {
        MyInfoUI.SetActive(false);
    }
    
    public void LobbyButton()
    {
        SceneManager.LoadScene("Lobby");
    }
}

