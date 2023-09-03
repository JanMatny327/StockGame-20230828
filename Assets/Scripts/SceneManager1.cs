using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    public GameObject[] SceneobjBox;
    public GameObject Courierobj;
    public GameObject StockUI;
 
    public void GameStart_Button()
    {
        SceneManager.LoadScene("InGame");
    }

    public void GameStop_Button()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void CreditUI_Button()
    {
        SceneobjBox[0].SetActive(true);
    }

    public void CreditUI_CancelButton()
    {
        SceneobjBox[0].SetActive(false);
    }

    public void StockButton()
    {
        StockUI.SetActive(true);
    }

    public void CancelStock()
    {
        StockUI.SetActive(false);
    }

    public void CourierButton()
    {
        Courierobj.SetActive(true);
    }

    public void CourierCancel()
    {
        Courierobj.SetActive(false);
    }
}
