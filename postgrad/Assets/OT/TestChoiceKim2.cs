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

    //�ε����� ����ǰ� ��.           //���ľ��ϴ� �κ�
    void Start()
    {
        //theOrder = FindObjectOfType<OrderManager>();
        theChoice = FindObjectOfType<ChoiceManager2>();
        test = GameObject.Find("TestChoice");
        state = true;
    }

    ////�ε����� �ڸ�ƾ�� �����
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!flag)
    //    {
    //        StartCoroutine(ACoroutine());
    //    }
    //}

    //***************************************************************************************************************************//
    //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
    private void Update()
    {
        //if (!flag) 
        //{
        if (Input.GetKeyDown(KeyCode.M))   //cŰ ������   ��ȭ ����   //�� �ѹ��� �Ͼ���� �ؾ���.
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

    IEnumerator ACoroutine()    //���߿� public Dialague dialague1; ���� ���� ���ϰ��� ���� ������ ������� ���� ������
    {
        //flag = true;    //�ѹ��� ����ǵ���

        //theOrder.NotMove();    //������Ʈ �ȿ����̵����ϴ� �ڵ�(��ٸ����� �ʿ� ����)
        theChoice.ShowChoice(choice);    //������ �ҷ���.
        yield return new WaitUntil(() => !theChoice.choiceIng); //������ ���� ������ ��ٸ� choiceIng�� false�� ��쿡�� ��� true�� �Ǹ� Ż��  
        Debug.Log(theChoice.GetResult());    //��� Ȯ���ϱ�
                                             //theOrder.Move();    //������Ʈ �����̵����ϴ� �ڵ�(��ٸ����� �ʿ� ����)

        //1,2,3,4�б⿡ ���� GetResult return���� ���� ������ �����ϰ� �� ���� ���� ���� ������
        
        if (theChoice.GetResult() == 0)
        {
            PlayerPrefs.SetInt("kim", PlayerPrefs.GetInt("kim")-5);
            Debug.Log("�豳���� : " + PlayerPrefs.GetInt("kim"));    //��� Ȯ���ϱ�
            SceneManager.LoadScene("Shim_Event1");
        }

        if (theChoice.GetResult() == 1)
        {
            PlayerPrefs.SetInt("kim", PlayerPrefs.GetInt("kim") + 10);
            Debug.Log("�豳���� : " + PlayerPrefs.GetInt("kim"));    //��� Ȯ���ϱ�
            SceneManager.LoadScene("Shim_Event1");
        }
    }
}
