using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject LobbyImage;
    public GameObject[] Gamelist;
    public GameObject TutorialImage;
    public TMP_Text explanation;
    public GameObject NPCImage;
    public Color TutorialImageColor;

    public void ButtonInput_Tutorial()
    {   
        LobbyImage.SetActive(false);
        TutorialImage.SetActive(true);
        Gamelist[0].SetActive(false);
        Gamelist[1].SetActive(false);
        Gamelist[2].SetActive(false);
        Gamelist[3].SetActive(false);
        Gamelist[4].SetActive(false);
        NPCImage.SetActive(true);
        explanation1();
    }
    
    public void explanation1()
    {
        explanation.text = "이 게임을 설명해드리겠습니다.";
        Invoke("explanation2", 4.5f);
    }

    public void explanation2()
    {
        explanation.text = "우선 이 게임은 주식을 위주로 제작된 게임이며 30일의 시간이 존재합니다." +
            "30일이 지날때마다 월세 15만원을 납부해야하며 납부하지 못할 경우 게임라이프 1개가 깎입니다." +
            "위 게임에서의 1일은 120초마다 1일씩 깎이게 됩니다.";
        Invoke("explanation3", 4.5f);
    }

    public void explanation3()
    {
        explanation.text = "위 게임의 승리방식으로는 모은 돈을 통하여 모든 빚을 상환하면 승리하는 방식의 게임입니다.";
        Invoke("explanation4", 4.5f);
    }

    public void explanation4()
    {
        explanation.text = "우선 부가컨텐츠로는 메인로비에서 택배 배달을 클릭하면 플레이할 수 있습니다." +
            "택배 배달은 플레이어를 목적지까지 무사히 도착시키면 배달비를 얻습니다." +
            "모은 배달비를 통해 주식으로 돈을 불려 모든 빚을 상환해보세요!";
        Invoke("explanationEND", 4.5f);
    }

    public void explanationEND()
    {
        LobbyImage.SetActive(true);
        TutorialImage.SetActive(false);
        Gamelist[0].SetActive(true);
        Gamelist[1].SetActive(true);
        Gamelist[2].SetActive(true);
        Gamelist[3].SetActive(true);
        Gamelist[4].SetActive(true);
        NPCImage.SetActive(false);
    }
}
