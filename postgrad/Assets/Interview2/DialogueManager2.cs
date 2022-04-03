using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //UI ���̺귯�� �ʼ�

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
    public SpriteRenderer rendererSprite;    //Sprite(������)�� ���� �� => SpriteRenderer Component
    public SpriteRenderer rendererDialogueWindow;

    private List<string> listSentences;    //Dialogue.cs�� �迭�� �ֱ� ����(�迭�� ũ�Ⱑ �����Ǿ� ������,  ����Ʈ�� ũ�� ���� �����ϹǷ�)
    private List<Sprite> listSprites;
    private List<Sprite> listDialogueWindows;

    private int count; // ��ȭ ���� ��Ȳ ī��Ʈ.

    public Animator animSprite;    //Sprite animation ����(appear, disappear)
    public Animator animDialogueWindow;    //��ȭâ animation ����(appear, disappear)


    //public string typeSound;
    //public string enterSound;

    //private AudioManager theAudio;

    public bool talking = false;    //��ȭ�ϰ� ���� ���� ��, ��Ŭ�� �Է� ���� ����.
    private TestDialogue2 Dial;
    //private bool keyActivated = false;

    // Use this for initialization
    void Start()
    {
        //�ʱ�ȭ
        count = 0;
        text.text = "";
        listSentences = new List<string>();    //����Ʈ �ʱ�ȭ
        listSprites = new List<Sprite>();
        listDialogueWindows = new List<Sprite>();
        //theAudio = FindObjectOfType<AudioManager>();
        Dial = FindObjectOfType<TestDialogue2>();
    }

    //***************************************************************************************************************************//
    //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
    public void ShowDialogue(Dialogue2 dialogue)    //��ȭâ�� ��Ÿ���� �Լ�, ���� Ŀ���� Ŭ������ �μ��� �ѱ�.
    {
        talking = true;   //��ȭâ�� ��Ÿ���� ��Ŭ�� ������.

        for (int i = 0; i < dialogue.sentences.Length; i++)    //�μ��� ���� dialogue�� �� ����Ʈ�� ����.
        {
            listSentences.Add(dialogue.sentences[i]);
            listSprites.Add(dialogue.sprites[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }

        animSprite.SetBool("Appear", true);    //��ȭ�� ���۵Ǳ� ����(�ڸ�ƾ ���� ����) �̹���, ��ȭâ�� ȭ������ �ҷ���
        animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());   //�ڸ�ƾ ����(IEnumerator StartDialogueCoroutine() �Լ� ����) == ��ȭ�� ���۵�.
    }
    public void ExitDialogue()    //��ȭâ, �̹��� ������� �Լ�
    {
        //�ʱ�ȭ
        text.text = "";
        count = 0;
        listSentences.Clear();
        listSprites.Clear();
        listDialogueWindows.Clear();
        animSprite.SetBool("Appear", false);    //��� false�� �ٲ�
        animDialogueWindow.SetBool("Appear", false);
        talking = false;   //��ȭ ������ ��ȭ �Ұ���
    }

    //����Ʈ�� ��� �� �ϳ��� �̾Ƴ�. == �ڸ�ƾ == ��ȭ�� ���۵� 
    IEnumerator StartDialogueCoroutine()
    {
        //��������Ʈ ��ü
        if (count > 0)   //�Ʒ� ���ǹ����� count �� 0 �̸� �ε����� -1�� �� �� �����Ƿ� ���� ����
        {
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])   //��ȭâ�� �޶��� ��� ��ȭâ�� ������ �̹��� ��ü(�����Ժ�)
            {
                animSprite.SetBool("Change", true);   //��������Ʈ �̹��� ���� ��ü
                animDialogueWindow.SetBool("Appear", false);    //��ȭâ �������
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];    //��ȭâ ��ü �۾�
                rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];    //��������Ʈ �̹��� ��ü��.
                animDialogueWindow.SetBool("Appear", true);     //��ȭâ ��Ÿ����
                animSprite.SetBool("Change", false);   //��������Ʈ �̹��� ���� ��ü
            }
            else    //��ȭâ, �������� ���� ���
            {
                if (listSprites[count] != listSprites[count - 1])   //�������� ������ ������ �̹����� �ٲ� ���(ǥ�� ��ȭ) �̹��� ��ü��.
                {
                    animSprite.SetBool("Change", true);    //��������Ʈ Ȱ��ȭ, ���� ����
                    yield return new WaitForSeconds(0.1f);    //���ð�
                    rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];  //�̹��� ��ü��. 
                    //rendererSprite.sprite = listSprites[count];   //�� ���� �̰ɷ� �ٲ㵵 ��.
                    animSprite.SetBool("Change", false);      //���� ����
                }
                else   //��ȭâ, ������ ǥ����ȭ ��� �״���� ���
                {
                    yield return new WaitForSeconds(0.05f);   //���
                }
            }

        }

        else    //count�� 0�� ���
        {
            yield return new WaitForSeconds(0.05f);
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];    //ù �̹����̹Ƿ� �翬�� �̹��� ��ü
            rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
        }

        //keyActivated = true;
        //�ؽ�Ʈ ���
        for (int i = 0; i < listSentences[count].Length; i++)    //��� ����� ���� for ��
        {
            text.text += listSentences[count][i]; // �� ������ 1���ھ� �����.
            //if (i % 7 == 1)
            //{
            //    theAudio.Play(typeSound);
            //}
            yield return new WaitForSeconds(0.01f);   //��� �ð�
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (talking)    //��ȭ���� ����, ������ ȭ��ǥ ��Ŭ�� ����
                        // && keyActivated
        {
            //***************************************************************************************************************************//
            //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
            if (Input.GetKeyDown(KeyCode.Z))    //ZŰ ������ ���� ���� ���  Input.GetKeyDown(KeyCode.Z)
            {
                //keyActivated = false;
                count++;    //���� �������� �ѱ�� ������ ���� ������ �о��ٴ� ���̹Ƿ� count ������.
                text.text = "";     //��Ŭ���� ������ �� ������ ���� Ŭ���� ���� ����ϱ� ���� �ʱ�ȭ �ʼ�
                //theAudio.Play(enterSound);

                if (count == listSentences.Count)    //count �迭�� ����Ʈ ������ ���� ���  == �� �о��ٴ� ���̹Ƿ� ����.
                {
                    StopAllCoroutines();   //�ڸ�ƾ ����.
                    ExitDialogue();    //��ȭâ ������� �Լ� ȣ��
                }
                else   //�� �о����� ���� ���� �����.
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());    //�ٽ� ����
                }
            }
        }
    }
}
