using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    // ��ũ��Ʈ �������� ���� �͵�
    public EndingScript EndingScript;
    public GameObject talkPanel;
    public int talkIndex;
    public Text talkText;

    // ǥ���� ������ �̹���
    public GameObject default_student;
    public GameObject good_student;
    public GameObject soso_student;
    public GameObject bad_student;

    // ������ �̹��� ������ ������Ʈ, ��ư ������Ʈ
    public GameObject prof_shim;
    public GameObject prof_lee;
    public GameObject prof_kim;

    // ���� ������ �� ������ ��ư 2��
    GameObject returnBtn;
    GameObject quitBtn;

    // ȣ���� ���� �迭, �ε��� 0�� ��� ���� ����
    // Scores[shim] = �ɱ����� ȣ����
    // �迭�� ũ��� ������ + 1
    int[] Scores = new int[4];
    int shim = 1;
    int lee = 2;
    int kim = 3;

    // ����Ʈ Talk ������ �� ����� ���� i
    int i = 0;

    // ���п��� ������ �ƴ� ��� ȣ������ ����� ��� / �����ΰ� / �־� �� �������� ����
    // ��� = 1, �����ΰ� = 2, �־� = 3
    int endingLevel = 0;
    
    // ��� ������ ������ 2��, ������ 1����, �� 5���� Talk �Լ��� ȣ���ؾ���.
    // count�� Talk ȣ�� Ƚ�� ������ ����
    int count = 0;

    // ���п� ������ ��� �� �����Ժ� ȣ������ ���� �ٸ� ������Ʈ ����ؾ���
    // Index[]�� �� �����Ժ� ��Ʈ�� id�� ������ �迭
    int[] Index = new int[4]; //{ 0, 0, 0, 0 }

    // ���п� ������ �ƴ� ��� ����� ������ ����
    int avg = 0;


    const int postGradTalk = 4; //���п� ������Ʈ ����� ��

    // GetID�� ���п� ������ �� ����
    // score�� ���� �ٸ� id ���� ��ȯ���ش�.
    int GetID(int score)
    {
        if (score >= 40) return (postGradTalk + 1); //���п� ������Ʈ ���� �ε����� ��� ��Ʈ ����
        else if (score >= 20) return (postGradTalk + 2); //�״����� �����ΰ� ��Ʈ����
        else return (postGradTalk + 3); //�״����� �־� ���� ��Ʈ����
    }

    // SetIndex�� ȣ������ ���� ���� �������� ���п� ���� ��Ʈ id��,
    // ������ �������� �� ȣ������ ���� �ٸ� ���� ��Ʈ id�� ���� ��
    // Index �迭�� �����Ժ� ������Ʈ id�� ����ȴ�
    // Index[shim] = �ɱ������� ���� ȣ������ �´� ������Ʈ id
    void SetIndex(int max)
    {
        Index[0] = max;
        Index[max] = postGradTalk;
        for (int id = 1; id < Index.Length; id++){
            if (id != max)
                Index[id] = GetID(Scores[id]);
        }
    }

    void Start()
    {
        Scores[shim] = PlayerPrefs.GetInt("shim");
        Scores[lee] = PlayerPrefs.GetInt("lee");
        Scores[kim] = PlayerPrefs.GetInt("kim");

        ///////////////////////////
        //Scores[shim] = 10;
        //Scores[lee] = 30;
        //Scores[kim] = 70;
        ///////////////////////////

        // ó�� �����̰� ���� ���� ����Ʈ ǥ���� ���̰� ��
        good_student.SetActive(false);
        soso_student.SetActive(false);
        bad_student.SetActive(false);

        // ��ư ��������, �ϴ��� �Ⱥ��̰� �ϱ�
        returnBtn = GameObject.Find("Return_Button");
        quitBtn = GameObject.Find("Quit_Button");
        returnBtn.SetActive(false);
        quitBtn.SetActive(false);

        // �����Ժ� ȣ������ ��� 60 ������ ��� ���п� ���� �Ұ���
        // �� ȣ������ ��� ���� ���� ������� ending ������ ����
        if (Scores[shim] < 60 && Scores[lee] < 60 && Scores[kim] < 60)
        {
            avg = (Scores[shim]+ Scores[lee]+ Scores[kim]) / 3;
            if (avg >= 40) endingLevel = 1;
            else if (avg >= 20) endingLevel = 2;
            else endingLevel = 3;
        }

        // �Ѹ��̶� ȣ������ 60 �̻��� ���
        // �ش� �������� ���п� ���� id�� �����ϰ�, ������ �������� ȣ������ ���� ��Ʈ�� ���п� ���� ��Ʈ�� �ִ� id�� ���� ��
        else
        {
            //�ɱ����� ���п�
            if (Scores[shim] >= Scores[lee] && Scores[shim] >= Scores[kim])
            {
                SetIndex(shim);
            }
            //�̱����� ���п�
            else if (Scores[lee] >= Scores[kim] && Scores[lee] >= Scores[shim])
            {
                SetIndex(lee);
            }

            //�豳���� ���п�
            else if (Scores[kim] >= Scores[lee] && Scores[kim] >= Scores[shim])
            {
                SetIndex(kim);
            }
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // endingLevel�� 0�� �ƴϸ� ���п������� �ƴ϶�� �ǹ�
            if (endingLevel != 0)
            {
                if (count <= 1) Talk_default(i);
                else if (count == 2) Talk_Shim(endingLevel);
                else if (count == 3) Talk_Lee(endingLevel);
                else if (count == 4) Talk_Kim(endingLevel);
                else Show_Button();
            }
            else // ���������� 0�� ��� = ���п��� ����
            {
                if (Index[0] == shim) //�ɱ����� ���п��� ����
                {
                    if (count == 0) Talk_default(i);
                    else if (count == 1) Talk_default(postGradTalk);
                    else if (count == 2) Talk_Shim(Index[shim]);
                    else if (count == 3) Talk_Lee(Index[lee]);
                    else if (count == 4) Talk_Kim(Index[kim]);
                }
                else if (Index[0] == lee) //�̱����� ���п��� ����
                {
                    if (count == 0) Talk_default(i);
                    else if (count == 1) Talk_default(postGradTalk+1);
                    else if (count == 2) Talk_Lee(Index[lee]);
                    else if (count == 3) Talk_Kim(Index[kim]);
                    else if (count == 4) Talk_Shim(Index[shim]);
                }
                else if(Index[0]==kim) // �豳���� ���п���
                {
                    if (count == 0) Talk_default(i);
                    else if (count == 1) Talk_default(postGradTalk + 2);
                    else if (count == 2) Talk_Kim(Index[kim]);
                    else if (count == 3) Talk_Shim(Index[shim]);
                    else if (count == 4) Talk_Lee(Index[lee]);
                }


            if (count == 5) Show_Button();

            }
        }


    }

    void Talk_default(int id)
    {
        string talkData = EndingScript.GetTalkStudent(id, talkIndex);


        if (talkData == null)
        {
            // GetTalkStudent���� null�� ���ϵǸ� Index�� 0���� �ʱ�ȭ
            talkIndex = 0;
            count++;
            i += endingLevel;
            return;
        }
        talkText.text = talkData;
        talkIndex++;
    }

    void Talk_Shim(int id)
    {
        string talkData = EndingScript.GetTalkShim(id, talkIndex);

        if (talkData == null)
        {
            count++;
            talkIndex = 0;
            prof_shim.GetComponent<SpriteRenderer>().sortingOrder = 0;
            return;
        }

        talkText.text = talkData;
        talkIndex++;
    }

    void Talk_Lee(int id)
    {
        string talkData = EndingScript.GetTalkLee(id, talkIndex);

        if (talkData == null)
        {
            count++;
            talkIndex = 0;
            prof_lee.GetComponent<SpriteRenderer>().sortingOrder = 0;
            return;
        }
        talkText.text = talkData;
        talkIndex++;
    }

    void Talk_Kim(int id)
    {
        string talkData = EndingScript.GetTalkKim(id, talkIndex);

        if (talkData == null)
        {
            count++;
            talkIndex = 0;
            prof_kim.GetComponent<SpriteRenderer>().sortingOrder = 0;
            return;
        }
        talkText.text = talkData;
        talkIndex++;
    }


    // ������ ������ ��Ʈ�� ������ ���ư���/���� ��ư ���̰� ��
    void Show_Button()
    {
        returnBtn.SetActive(true);
        quitBtn.SetActive(true);
    }

    public void Click_Return()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Click_quit()
    {
        Application.Quit();
    }
}
