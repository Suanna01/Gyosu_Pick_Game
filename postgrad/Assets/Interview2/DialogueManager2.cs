using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //UI 라이브러리 필수

public class DialogueManager2 : MonoBehaviour
{
    public static DialogueManager2 instance;

    /*#region Singleton
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
    #endregion Singleton*/

    public Text text;
    public SpriteRenderer rendererSprite;    //Sprite(교수님)가 속한 곳 => SpriteRenderer Component
    public SpriteRenderer rendererDialogueWindow;

    private List<string> listSentences;    //Dialogue.cs의 배열을 넣기 위함(배열은 크기가 고정되어 있지만,  리스트는 크기 조절 가능하므로)
    private List<Sprite> listSprites;
    private List<Sprite> listDialogueWindows;

    private int count; // 대화 진행 상황 카운트.

    public Animator animSprite;    //Sprite animation 통제(appear, disappear)
    public Animator animDialogueWindow;    //대화창 animation 통제(appear, disappear)


    //public string typeSound;
    //public string enterSound;

    //private AudioManager theAudio;

    public bool talking = false;    //대화하고 있지 않을 때, 좌클릭 입력 막기 위함.
    private TestDialogue2 Dial;
    //private bool keyActivated = false;

    // Use this for initialization
    void Start()
    {
        //초기화
        count = 0;
        text.text = "";
        listSentences = new List<string>();    //리스트 초기화
        listSprites = new List<Sprite>();
        listDialogueWindows = new List<Sprite>();
        //theAudio = FindObjectOfType<AudioManager>();
        Dial = FindObjectOfType<TestDialogue2>();
    }

    //***************************************************************************************************************************//
    //유튜브에서는 플레이어가 닿았을 때로 함.
    public void ShowDialogue(Dialogue2 dialogue)    //대화창이 나타나는 함수, 만든 커스텀 클래스를 인수로 넘김.
    {
        talking = true;   //대화창이 나타나면 좌클릭 가능함.

        for (int i = 0; i < dialogue.sentences.Length; i++)    //인수로 받은 dialogue를 세 리스트에 넣음.
        {
            listSentences.Add(dialogue.sentences[i]);
            listSprites.Add(dialogue.sprites[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }

        animSprite.SetBool("Appear", true);    //대화가 시작되기 전에(코르틴 시작 전에) 이미지, 대화창을 화면으로 불러옴
        animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());   //코르틴 시작(IEnumerator StartDialogueCoroutine() 함수 시작) == 대화가 시작됨.
    }
    public void ExitDialogue()    //대화창, 이미지 사라지는 함수
    {
        //초기화
        text.text = "";
        count = 0;
        listSentences.Clear();
        listSprites.Clear();
        listDialogueWindows.Clear();
        animSprite.SetBool("Appear", false);    //모두 false로 바꿈
        animDialogueWindow.SetBool("Appear", false);
        talking = false;   //대화 끝나면 대화 불가능
    }

    //리스트에 담긴 것 하나씩 뽑아냄. == 코르틴 == 대화가 시작됨 
    IEnumerator StartDialogueCoroutine()
    {
        //스프라이트 교체
        if (count > 0)   //아래 조건문에서 count 가 0 이면 인덱스가 -1이 될 수 있으므로 오류 방지
        {
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])   //대화창이 달라질 경우 대화창과 교수님 이미지 교체(교수님별)
            {
                animSprite.SetBool("Change", true);   //스프라이트 이미지 투명도 교체
                animDialogueWindow.SetBool("Appear", false);    //대화창 사라지게
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];    //대화창 교체 작업
                rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];    //스프라이트 이미지 교체함.
                animDialogueWindow.SetBool("Appear", true);     //대화창 나타나게
                animSprite.SetBool("Change", false);   //스프라이트 이미지 투명도 교체
            }
            else    //대화창, 교수님이 같을 경우
            {
                if (listSprites[count] != listSprites[count - 1])   //교수님은 같은데 교수님 이미지가 바뀔 경우(표정 변화) 이미지 교체함.
                {
                    animSprite.SetBool("Change", true);    //스프라이트 활성화, 투명도 조절
                    yield return new WaitForSeconds(0.1f);    //대기시간
                    rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];  //이미지 교체함. 
                    //rendererSprite.sprite = listSprites[count];   //위 문장 이걸로 바꿔도 됨.
                    animSprite.SetBool("Change", false);      //투명도 조절
                }
                else   //대화창, 교수님 표정변화 모두 그대로일 경우
                {
                    yield return new WaitForSeconds(0.05f);   //대기
                }
            }

        }

        else    //count가 0일 경우
        {
            yield return new WaitForSeconds(0.05f);
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];    //첫 이미지이므로 당연히 이미지 교체
            rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
        }

        //keyActivated = true;
        //텍스트 출력
        for (int i = 0; i < listSentences[count].Length; i++)    //대사 출력을 위한 for 문
        {
            text.text += listSentences[count][i]; // 각 문장의 1글자씩 출력함.
            //if (i % 7 == 1)
            //{
            //    theAudio.Play(typeSound);
            //}
            yield return new WaitForSeconds(0.01f);   //대기 시간
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (talking)    //대화중일 때만, 오른쪽 화살표 좌클릭 가능
                        // && keyActivated
        {
            //***************************************************************************************************************************//
            //유튜브에서는 플레이어가 닿았을 때로 함.
            if (Input.GetKeyDown(KeyCode.Z))    //Z키 누르면 다음 질문 출력  Input.GetKeyDown(KeyCode.Z)
            {
                //keyActivated = false;
                count++;    //다음 질문으로 넘기는 행위는 현재 문장을 읽었다는 뜻이므로 count 증가함.
                text.text = "";     //좌클릭을 질문이 다 나오기 전에 클릭할 것을 대비하기 위해 초기화 필수
                //theAudio.Play(enterSound);

                if (count == listSentences.Count)    //count 배열의 리스트 개수와 같을 경우  == 다 읽었다는 것이므로 끝냄.
                {
                    StopAllCoroutines();   //코르틴 끝냄.
                    ExitDialogue();    //대화창 사라지는 함수 호출
                }
                else   //다 읽었으면 다음 문장 출력함.
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());    //다시 시작
                }
            }
        }
    }
}
