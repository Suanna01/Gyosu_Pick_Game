using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TalkManager : MonoBehaviour//, IPointerDownHandler
{
  /*  
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;
    public Queue<string> sentences;

    private string currentSentence;

    public float typingSpeed = 0.1f;
    private bool istyping;

    public static TalkManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void OnDialogue(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;

        NextSentence();
    }
    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            istyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialoguegroup.alpha =0;
            dialoguegroup.blocksRaycasts = false;
        }
    }
    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Update()
    {
        if (dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            istyping = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!istyping)
        NextSentence();
    }
    */



    /*
    //<objectid, talk>
    Dictionary<int, string[]> talkData;    //여러 문장이 들어있을 경우 string[] 사용
    
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();    //빈 공간 생성
        GenerateData();    //빈 공간에 데이터 삽입하는 함수
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "우리 학교를 지원한 이유가 어떻게 되나요?" });    //대화 데이터 입력 추가    //(objectid, 대화데이터)
    }

    //지정된 대화 문장 반환하는 함수
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
    */
}
