using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceManager3 : MonoBehaviour
{
    public Choice2 choice;
    public static ChoiceManager3 instance;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton

    // private AudioManager theAudio; // 사운드 재생.

    private string question2;    //Choice2의 질문 대입
    private List<string> answerList2;    //Choice2의 답변 배열 대입

    //쯔꾸르용인듯
    public GameObject go; // 평소에 비활성화 시킬 목적으로 선언. setActive.

    public Text question_Text2;
    public Text[] answer_Text2;
    public GameObject[] answer_Panel2;

    //2
    /*
    private string question2;    //Choice2의 질문 대입
    private List<string> answerList2;    //Choice2의 답변 배열 대입
    public Text question_Text2;
    public Text[] answer_Text2;
    */

    public Animator anim;

    // public string keySound;
    // public string enterSound;

    public bool choiceIng; // 대기. ()=> !choiceIng   선택하기 전에 대화 넘어가는 거 방지 
    private bool keyInput; // 키처리 활성화, 비 활성화.    //선택지 뜨면 키 활성화(선택하는 키), 선택지 꺼지면 키 비활성화

    private int count; // 배열의 크기
    private int result; // 선택한 선택창.

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Use this for initialization
    void Start()
    {
        //초기화 시키기
        // theAudio = FindObjectOfType<AudioManager>();
        answerList2 = new List<string>();
        for (int i = 0; i < answer_Text2.Length; i++)
        {
            answer_Text2[i].text = "";
            answer_Panel2[i].SetActive(false);
        }
        question_Text2.text = "";

        //2
        /*
        answerList2 = new List<string>();
        for (int i = 0; i < answer_Text2.Length; i++)
        {
            answer_Text2[i].text = "";
            answer_Panel[i].SetActive(false);
        }
        question_Text2.text = "";\
        */
    }

    //선택지 보이게하기
    public void ShowChoice(Choice2 _choice)
    {
        choiceIng = true;
        go.SetActive(true);     //오브젝트 활성화  쯔꾸르용인듯
        result = 0;
        question2 = _choice.question2;
        for (int i = 0; i < _choice.answers2.Length; i++)
        {
            //배열 크기만큼 답변 리스트에 들어감
            answerList2.Add(_choice.answers2[i]);
            answer_Panel2[i].SetActive(true);    //패널 활성화
            count = i;    //count == 배열의 크기
        }
        anim.SetBool("Appear", true);    //애니메이션 활성화
        Selection();    //선택중인 선택지 색상바꾸기 함수
        StartCoroutine(ChoiceCoroutine());

    }

    //2
    /*
    //선택지 보이게하기
    public void ShowChoice2(Choice2 _choice)
    {
        choiceIng = true;
        go.SetActive(true);     //오브젝트 활성화  쯔꾸르용인듯
        result = 0;
        question2 = _choice.question2;
        for (int i = 0; i < _choice.answers2.Length; i++)
        {
            //배열 크기만큼 답변 리스트에 들어감
            answerList2.Add(_choice.answers2[i]);
            answer_Panel[i].SetActive(true);    //패널 활성화
            count = i;    //count == 배열의 크기
        }
        anim.SetBool("Appear", true);    //애니메이션 활성화
        Selection();    //선택중인 선택지 색상바꾸기 함수
        StartCoroutine(ChoiceCoroutine());
    }
    */


    //고른 선택지 값 가져오는 함수
    public int GetResult()
    {
        go.SetActive(false);
        return result;                              //이 결과로 분기 짜면 됨.
    }

    //선택지 끄는 함수
    public void ExitChoice()
    {
        //초기화
        question_Text2.text = "";
        for (int i = 0; i <= count; i++)
        {
            answer_Text2[i].text = "";
            answer_Panel2[i].SetActive(false);
        }
        answerList2.Clear();
        anim.SetBool("Appear", false);
        choiceIng = false;
        //go.SetActive(false);        //오브젝트 비활성화 쯔꾸르용인듯
    }


    //2
    /*
    //선택지 끄는 함수
    public void ExitChoice2()
    {
        //초기화
        question_Text2.text = "";
        for (int i = 0; i <= count; i++)
        {
            answer_Text2[i].text = "";
            answer_Panel[i].SetActive(false);
        }
        answerList2.Clear();
        anim.SetBool("Appear", false);
        choiceIng = false;
        //go.SetActive(false);        //오브젝트 비활성화 쯔꾸르용인듯
    }
    */

    IEnumerator ChoiceCoroutine()
    {
        yield return new WaitForSeconds(0.2f);   //잠깐 대기 시키기(애니메이션 시간동안)

        //아래의 서브 코르틴 함수 모두 출력함.
        StartCoroutine(TypingQuestion());    //질문은 무조건 출력함
        StartCoroutine(TypingAnswer_0());   //질문이 있으면 답변 1개는 무조건있어야하므로 1번답변도 무조건 출력함.
        if (count >= 1)                               //나머지 질문은 리스트에 입력되어 있으면 출력함.
            StartCoroutine(TypingAnswer_1());
        if (count >= 2)
            StartCoroutine(TypingAnswer_2());
        if (count >= 3)
            StartCoroutine(TypingAnswer_3());

        yield return new WaitForSeconds(0.5f);    //대기
        keyInput = true;   //선택지 고르는 키 활성화
    }

    //서브 코르틴

    //한글자씩 출력되게 하는 함수
    IEnumerator TypingQuestion()
    {
        for (int i = 0; i < question2.Length; i++)
        {
            question_Text2.text += question2[i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_0()
    {
        yield return new WaitForSeconds(0.4f);    //연출 효과
        for (int i = 0; i < answerList2[0].Length; i++)
        {
            answer_Text2[0].text += answerList2[0][i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_1()
    {
        yield return new WaitForSeconds(0.5f);   //연출 효과
        for (int i = 0; i < answerList2[1].Length; i++)
        {
            answer_Text2[1].text += answerList2[1][i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_2()
    {
        yield return new WaitForSeconds(0.6f);   //연출 효과
        for (int i = 0; i < answerList2[2].Length; i++)
        {
            answer_Text2[2].text += answerList2[2][i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_3()
    {
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < answerList2[3].Length; i++)
        {
            answer_Text2[3].text += answerList2[3][i];
            yield return waitTime;
        }
    }

    //비슷한 함수 여러개 만든 이유
    //동시에 질문과 대답(4개)을 출력하므로 코르틴을 그만큼 추가해야함.
    //그런데 하나의 코르틴으로 텍스트(대답) 여러개 출력하면 오류남.
    //예) 1번 대답 출력 중에 2번 대답 출력하면 첫번째 코르틴에 다음 대답지까지 나옴


    //2
    /*

    IEnumerator ChoiceCoroutine2()
    {
        yield return new WaitForSeconds(0.2f);   //잠깐 대기 시키기(애니메이션 시간동안)

        //아래의 서브 코르틴 함수 모두 출력함.
        StartCoroutine(TypingQuestion2());    //질문은 무조건 출력함
        StartCoroutine(TypingAnswer_0_2());   //질문이 있으면 답변 1개는 무조건있어야하므로 1번답변도 무조건 출력함.
        if (count >= 1)                               //나머지 질문은 리스트에 입력되어 있으면 출력함.
            StartCoroutine(TypingAnswer_1_2());
        if (count >= 2)
            StartCoroutine(TypingAnswer_2_2());
        if (count >= 3)
            StartCoroutine(TypingAnswer_3_2());

        yield return new WaitForSeconds(0.5f);    //대기
        keyInput = true;   //선택지 고르는 키 활성화
    }

    //서브 코르틴

    //한글자씩 출력되게 하는 함수
    IEnumerator TypingQuestion2()
    {
        for (int i = 0; i < question2.Length; i++)
        {
            question_Text2.text += question2[i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_0_2()
    {
        yield return new WaitForSeconds(0.4f);    //연출 효과
        for (int i = 0; i < answerList2[0].Length; i++)
        {
            answer_Text2[0].text += answerList2[0][i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_1_2()
    {
        yield return new WaitForSeconds(0.5f);   //연출 효과
        for (int i = 0; i < answerList2[1].Length; i++)
        {
            answer_Text2[1].text += answerList2[1][i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_2_2()
    {
        yield return new WaitForSeconds(0.6f);   //연출 효과
        for (int i = 0; i < answerList2[2].Length; i++)
        {
            answer_Text2[2].text += answerList2[2][i];
            yield return waitTime;
        }
    }
    //한글자씩 출력되게 하는 함수
    IEnumerator TypingAnswer_3_2()
    {
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < answerList2[3].Length; i++)
        {
            answer_Text2[3].text += answerList2[3][i];
            yield return waitTime;
        }
    }

    */


    void Update()
    {
        //선택지 고르는 키 조건문
        if (keyInput)    //선택지 고르는 키가 true가 되면 선택된 값이 들어오게 되므로
        {
            //result는 해당 선택지 순서 값을 가지게 됨
            if (Input.GetKeyDown(KeyCode.UpArrow))     //위쪽 화살표
            {
                //theAudio.Play(keySound);
                if (result > 0)
                    result--;             //
                else
                    result = count;    //result가 0이면 배열의 크기만큼 넘김
                Selection();    //선택하고 있는 선택지 색상 바꾸기 함수
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))   //아래쪽 화살표
            {
                // theAudio.Play(keySound);
                if (result < count)
                    result++;     //배열의 크기가 되기 전까지 plus   
                else
                    result = 0;    //배열의 크기와 똑같아 지면 0으로
                Selection();    //선택하고 있는 선택지 색상 바꾸기 함수
            }
            //결정키 Z
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                // theAudio.Play(enterSound);
                keyInput = false;     //Z키를 누르면 선택지 중 답변을 결정했다는 뜻이므로 더이상의 키입력 비활성화 
                ExitChoice();    //선택지 끄는 함수 호출
            }
        }

    }

    //선택지 중 무엇이 선택되었는지 육안으로 확인하기 위한 함수
    public void Selection()
    {
        Color color = answer_Panel2[0].GetComponent<Image>().color;
        color.a = 0.75f;
        //모든 패널(선택지) 색상 조정
        for (int i = 0; i <= count; i++)
        {
            //모두 반투명
            answer_Panel2[i].GetComponent<Image>().color = color;
        }
        //선택된 것만 색
        color.a = 1f;
        answer_Panel2[result].GetComponent<Image>().color = color;
    }
}
