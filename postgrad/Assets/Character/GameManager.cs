using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScriptManager ScriptManager;
    public GameObject talkPanel;
    public int talkIndex;
    public Text talkText;
    //public bool isAction;
    GameObject shim;
    GameObject kim;
    GameObject lee;
    GameObject yesButton;
    GameObject noButton;

    int i = 1;

    void Start()
    {
        this.shim = GameObject.Find("shim_full");
        this.kim = GameObject.Find("kim_full");
        this.lee = GameObject.Find("lee_full");
        this.yesButton = GameObject.Find("Yes_Button");
        this.noButton = GameObject.Find("No_Button");

        //캐릭터 소개 나오는 동안 버튼 숨김
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("클릭되었다..");
            if (i < 5)
            {
                // 각 캐릭터를 설명할 때 그림도 보이게 함
                if (i == 1) this.shim.GetComponent<SpriteRenderer>().color = Color.white;
                else if (i == 2) this.kim.GetComponent<SpriteRenderer>().color = Color.white;
                else if (i == 3) this.lee.GetComponent<SpriteRenderer>().color = Color.white;
                Talk(i);
                
            }

            // 멘트 다 나오고나서 버튼 활성화
            if (i == 5)
            {
                yesButton.SetActive(true);
                noButton.SetActive(true);
            }

            //text 자체를 숨김
            //talkPanel.SetActive(isAction);

        }
    }

    void Talk(int id)
    {
        string talkData = ScriptManager.GetTalk(id, talkIndex);


        if (talkData == null)
        {
            //isAction = false;
            talkIndex = 0;
            i++;
            return;
        }

        talkText.text = talkData;
        talkIndex++;
        //isAction = true;

    }

    public void ClickYes()
    {
        Debug.Log("yes");
        SceneManager.LoadScene("Interview2");
    }

    public void ClickNo()
    {
        Debug.Log("no");
        SceneManager.LoadScene("Intro");
    }
}
