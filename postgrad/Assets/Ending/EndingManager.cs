using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    // 스크립트 가져오기 위한 것들
    public EndingScript EndingScript;
    public GameObject talkPanel;
    public int talkIndex;
    public Text talkText;

    // 표정별 수룡이 이미지
    public GameObject default_student;
    public GameObject good_student;
    public GameObject soso_student;
    public GameObject bad_student;

    // 교수님 이미지 저장할 오브젝트, 버튼 오브젝트
    public GameObject prof_shim;
    public GameObject prof_lee;
    public GameObject prof_kim;

    // 게임 끝났을 때 나오는 버튼 2개
    GameObject returnBtn;
    GameObject quitBtn;

    // 호감도 담을 배열, 인덱스 0은 사용 하지 않음
    // Scores[shim] = 심교수님 호감도
    // 배열의 크기는 교수님 + 1
    int[] Scores = new int[4];
    int shim = 1;
    int lee = 2;
    int kim = 3;

    // 디폴트 Talk 가져올 때 사용할 변수 i
    int i = 0;

    // 대학원생 엔딩이 아닐 경우 호감도의 평균이 취업 / 투명인간 / 최악 중 무엇인지 저장
    // 취업 = 1, 투명인간 = 2, 최악 = 3
    int endingLevel = 0;
    
    // 모든 엔딩은 수룡이 2번, 교수님 1번씩, 총 5번만 Talk 함수를 호출해야함.
    // count는 Talk 호출 횟수 저장할 변수
    int count = 0;

    // 대학원 엔딩일 경우 각 교수님별 호감도에 따라 다른 엔딩멘트 출력해야함
    // Index[]는 각 교수님별 멘트의 id를 저장할 배열
    int[] Index = new int[4]; //{ 0, 0, 0, 0 }

    // 대학원 엔딩이 아닐 경우 평균을 저장할 변수
    int avg = 0;


    const int postGradTalk = 4; //대학원 엔딩멘트 저장된 곳

    // GetID는 대학원 엔딩일 때 사용됨
    // score에 따라 다른 id 값을 반환해준다.
    int GetID(int score)
    {
        if (score >= 40) return (postGradTalk + 1); //대학원 엔딩멘트 다음 인덱스에 취업 멘트 저장
        else if (score >= 20) return (postGradTalk + 2); //그다음에 투명인간 멘트저장
        else return (postGradTalk + 3); //그다음에 최악 엔딩 멘트저장
    }

    // SetIndex는 호감도가 가장 높은 교수님은 대학원 엔딩 멘트 id를,
    // 나머지 교수님은 각 호감도에 따라 다른 엔딩 멘트 id를 갖게 함
    // Index 배열에 교수님별 엔딩멘트 id가 저장된다
    // Index[shim] = 심교수님의 현재 호감도에 맞는 엔딩멘트 id
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

        // 처음 수룡이가 말할 때는 디폴트 표정만 보이게 함
        good_student.SetActive(false);
        soso_student.SetActive(false);
        bad_student.SetActive(false);

        // 버튼 가져오고, 일단은 안보이게 하기
        returnBtn = GameObject.Find("Return_Button");
        quitBtn = GameObject.Find("Quit_Button");
        returnBtn.SetActive(false);
        quitBtn.SetActive(false);

        // 교수님별 호감도가 모두 60 이하인 경우 대학원 엔딩 불가능
        // 각 호감도를 모두 더해 구한 평균으로 ending 레벨을 정함
        if (Scores[shim] < 60 && Scores[lee] < 60 && Scores[kim] < 60)
        {
            avg = (Scores[shim]+ Scores[lee]+ Scores[kim]) / 3;
            if (avg >= 40) endingLevel = 1;
            else if (avg >= 20) endingLevel = 2;
            else endingLevel = 3;
        }

        // 한명이라도 호감도가 60 이상인 경우
        // 해당 교수님을 대학원 엔딩 id를 갖게하고, 나머지 교수님은 호감도에 따른 멘트와 대학원 축하 멘트가 있는 id를 갖게 함
        else
        {
            //심교수님 대학원
            if (Scores[shim] >= Scores[lee] && Scores[shim] >= Scores[kim])
            {
                SetIndex(shim);
            }
            //이교수님 대학원
            else if (Scores[lee] >= Scores[kim] && Scores[lee] >= Scores[shim])
            {
                SetIndex(lee);
            }

            //김교수님 대학원
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
            // endingLevel이 0이 아니면 대학원엔딩이 아니라는 의미
            if (endingLevel != 0)
            {
                if (count <= 1) Talk_default(i);
                else if (count == 2) Talk_Shim(endingLevel);
                else if (count == 3) Talk_Lee(endingLevel);
                else if (count == 4) Talk_Kim(endingLevel);
                else Show_Button();
            }
            else // 엔딩레벨이 0일 경우 = 대학원생 엔딩
            {
                if (Index[0] == shim) //심교수님 대학원생 엔딩
                {
                    if (count == 0) Talk_default(i);
                    else if (count == 1) Talk_default(postGradTalk);
                    else if (count == 2) Talk_Shim(Index[shim]);
                    else if (count == 3) Talk_Lee(Index[lee]);
                    else if (count == 4) Talk_Kim(Index[kim]);
                }
                else if (Index[0] == lee) //이교수님 대학원생 엔딩
                {
                    if (count == 0) Talk_default(i);
                    else if (count == 1) Talk_default(postGradTalk+1);
                    else if (count == 2) Talk_Lee(Index[lee]);
                    else if (count == 3) Talk_Kim(Index[kim]);
                    else if (count == 4) Talk_Shim(Index[shim]);
                }
                else if(Index[0]==kim) // 김교수님 대학원생
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
            // GetTalkStudent에서 null이 리턴되면 Index를 0으로 초기화
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


    // 교수님 엔딩별 멘트가 끝나면 돌아가기/종료 버튼 보이게 함
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
