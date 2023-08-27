using System.Collections;
using System.Collections.Generic;
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
    public void ButtonInput_JunStock()
    {
        InGameUI.SetActive(false);
        JunStock.SetActive(true);

    }

    public void ButtonInput_SangStock()
    {
        InGameUI.SetActive(false);
        SangStock.SetActive(true);
    }

    public void ButtonInput_ChanStock()
    {
        InGameUI.SetActive(false);
        ChanStock.SetActive(true);
    }

    public void ButtonInput_YeaStock()
    {
        InGameUI.SetActive(false);
        YeaStock.SetActive(true);
    }

    public void ButtonInput_HisuStock()
    {
        InGameUI.SetActive(false);
        HisuStock.SetActive(true);
    }

    public void CancelButton_Jun()
    {
        InGameUI.SetActive(true);
        JunStock.SetActive(false);
    }

    public void CancelButton_SangStock()
    {
        InGameUI.SetActive(true);
        SangStock.SetActive(false);
    }

    public void CancelButton_ChanStock()
    {
        InGameUI.SetActive(true);
        ChanStock.SetActive(false);
    }

    public void CancelButton_YeaStock()
    {
        InGameUI.SetActive(true);
        YeaStock.SetActive(false);
    }

    public void CancelButton_HisuStock()
    {
        InGameUI.SetActive(true);
        HisuStock.SetActive(false);
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

