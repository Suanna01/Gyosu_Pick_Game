using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestChoiceKim2 : MonoBehaviour
{
    [SerializeField]
    public Choice2 choice;

    //public Dialogue2 dialague1;
    //public Dialogue2 dialague2;
    //public Dialogue2 dialague3;
    //public Dialogue2 dialague4;

    //private ChoiceManager2 theOrder;
    private ChoiceManager2 theChoice;

    GameObject test;

    public bool flag;

    private bool state;

    //부딪히면 실행되게 함.           //고쳐야하는 부분
    void Start()
    {
        //theOrder = FindObjectOfType<OrderManager>();
        theChoice = FindObjectOfType<ChoiceManager2>();
        test = GameObject.Find("TestChoice");
        state = true;
    }

    ////부딪히면 코르틴이 실행됨
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!flag)
    //    {
    //        StartCoroutine(ACoroutine());
    //    }
    //}

    //***************************************************************************************************************************//
    //유튜브에서는 플레이어가 닿았을 때로 함.
    private void Update()
    {
        //if (!flag) 
        //{
        if (Input.GetKeyDown(KeyCode.M))   //c키 누를시   대화 생성   //단 한번만 일어나도록 해야함.
        {
            StartCoroutine(ACoroutine());
            //if (state == true)
            //{
            //    test.GetComponent<TestChoice>().enabled = false;
            //    Debug.Log("disable script");
            //    state = false;
            //}
            //else
            //{
            //    test.GetComponent<TestChoice>().enabled = true;
            //    Debug.Log("enable");
            //    state = true;
            //}
        }
        //}
    }

    IEnumerator ACoroutine()    //나중에 public Dialague dialague1; 별로 만들어서 리턴값을 따로 변수에 저장시켜 조건 나누기
    {
        //flag = true;    //한번만 실행되도록

        //theOrder.NotMove();    //오브젝트 안움직이도록하는 코드(쯔꾸르용임 필요 없음)
        theChoice.ShowChoice(choice);    //선택지 불러옴.
        yield return new WaitUntil(() => !theChoice.choiceIng); //선택지 끝날 때까지 기다림 choiceIng가 false일 경우에만 대기 true가 되면 탈출  
        Debug.Log(theChoice.GetResult());    //결과 확인하기
                                             //theOrder.Move();    //오브젝트 움직이도록하는 코드(쯔꾸르용임 필요 없음)

        //1,2,3,4분기에 따라 GetResult return값을 따로 변수에 저장하고 그 값에 따라 조건 나누기
        
        if (theChoice.GetResult() == 0)
        {
            PlayerPrefs.SetInt("kim", PlayerPrefs.GetInt("kim")-5);
            Debug.Log("김교수님 : " + PlayerPrefs.GetInt("kim"));    //결과 확인하기
            SceneManager.LoadScene("Shim_Event1");
        }

        if (theChoice.GetResult() == 1)
        {
            PlayerPrefs.SetInt("kim", PlayerPrefs.GetInt("kim") + 10);
            Debug.Log("김교수님 : " + PlayerPrefs.GetInt("kim"));    //결과 확인하기
            SceneManager.LoadScene("Shim_Event1");
        }
    }
}
