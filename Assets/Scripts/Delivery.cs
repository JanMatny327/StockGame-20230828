
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    [Header("변수 관리")]
    public float ClearDistanceMin = 20f;
    public float ClearDistanceMax = 40f;
    public float ClearDistance;
    public void ButtonInput_Delivery()
    {
        SceneManager.LoadScene("Courier");
        ClearDistance = Random.Range(ClearDistanceMin, ClearDistanceMax);
    }


}
