using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //UI ���̺귯�� �ʼ�
using UnityEngine.SceneManagement;

public class DialogueManagerOT : MonoBehaviour
{
    public static DialogueManagerOT instance;

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

    public Text text;
    public SpriteRenderer rendererSprite;    //Sprite(������)�� ���� �� => SpriteRenderer Component
    public SpriteRenderer rendererDialogueWindow;

    private List<string> listSentences2;    //Dialogue.cs�� �迭�� �ֱ� ����(�迭�� ũ�Ⱑ �����Ǿ� ������,  ����Ʈ�� ũ�� ���� �����ϹǷ�)
    private List<Sprite> listSprites2;
    private List<Sprite> listDialogueWindows2;

    private int count; // ��ȭ ���� ��Ȳ ī��Ʈ.

    public Animator animSprite;    //Sprite animation ����(appear, disappear)
    public Animator animDialogueWindow;    //��ȭâ animation ����(appear, disappear)


    //public string typeSound;
    //public string enterSound;

    //private AudioManager theAudio;

    public bool talking = false;    //��ȭ�ϰ� ���� ���� ��, ��Ŭ�� �Է� ���� ����.
    private TestDialogaueOT Dial;
    //private bool keyActivated = false;

    // Use this for initialization
    void Start()
    {
        //�ʱ�ȭ
        count = 0;
        text.text = "";
        listSentences2 = new List<string>();    //����Ʈ �ʱ�ȭ
        listSprites2 = new List<Sprite>();
        listDialogueWindows2 = new List<Sprite>();
        //theAudio = FindObjectOfType<AudioManager>();
        Dial = FindObjectOfType<TestDialogaueOT>();

    }

    //***************************************************************************************************************************//
    //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
    public void ShowDialogue(DialogueOT dialogue2)    //��ȭâ�� ��Ÿ���� �Լ�, ���� Ŀ���� Ŭ������ �μ��� �ѱ�.
    {
        talking = true;   //��ȭâ�� ��Ÿ���� ��Ŭ�� ������.

        for (int i = 0; i < dialogue2.sentences2.Length; i++)    //�μ��� ���� dialogue�� �� ����Ʈ�� ����.
        {
            //Debug.Log("Iiiiiiiiiiii : " + i);
            //Debug.Log("dialogue.sentences2[i] : " + dialogue2.sentences2[i]);
            listSentences2.Add(dialogue2.sentences2[i]);
            listSprites2.Add(dialogue2.sprites2[i]);
            listDialogueWindows2.Add(dialogue2.dialogueWindows2[i]);
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
        listSentences2.Clear();
        listSprites2.Clear();
        listDialogueWindows2.Clear();
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
            if (listDialogueWindows2[count] != listDialogueWindows2[count - 1])   //��ȭâ�� �޶��� ��� ��ȭâ�� ������ �̹��� ��ü(�����Ժ�)
            {
                animSprite.SetBool("Change", true);   //��������Ʈ �̹��� ���� ��ü
                animDialogueWindow.SetBool("Appear", false);    //��ȭâ �������
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows2[count];    //��ȭâ ��ü �۾�
                rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites2[count];    //��������Ʈ �̹��� ��ü��.
                animDialogueWindow.SetBool("Appear", true);     //��ȭâ ��Ÿ����
                animSprite.SetBool("Change", false);   //��������Ʈ �̹��� ���� ��ü
            }
            else    //��ȭâ, �������� ���� ���
            {
                if (listSprites2[count] != listSprites2[count - 1])   //�������� ������ ������ �̹����� �ٲ� ���(ǥ�� ��ȭ) �̹��� ��ü��.
                {
                    animSprite.SetBool("Change", true);    //��������Ʈ Ȱ��ȭ, ���� ����
                    yield return new WaitForSeconds(0.1f);    //���ð�
                    rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites2[count];  //�̹��� ��ü��. 
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
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows2[count];    //ù �̹����̹Ƿ� �翬�� �̹��� ��ü
            rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites2[count];
        }

        //keyActivated = true;
        //�ؽ�Ʈ ���
        for (int i = 0; i < listSentences2[count].Length; i++)    //��� ����� ���� for ��
        {
            text.text += listSentences2[count][i]; // �� ������ 1���ھ� �����.
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

                //Debug.Log("count: " + count);    //��� Ȯ���ϱ�
                if (count == listSentences2.Count)    //count �迭�� ����Ʈ ������ ���� ���  == �� �о��ٴ� ���̹Ƿ� ����.
                {
                    StopAllCoroutines();   //�ڸ�ƾ ����.
                    if (count >= 9)
                    {
                        //Debug.Log("count: " + count);    //��� Ȯ���ϱ�
                        int shim_point = PlayerPrefs.GetInt("shim");
                        int kim_point = PlayerPrefs.GetInt("kim");
                        int lee_point = PlayerPrefs.GetInt("lee");
                        int max = 0;
                        max = ((shim_point > kim_point) && (shim_point > lee_point)) ? shim_point : ((kim_point > shim_point) && (kim_point > lee_point)) ? kim_point : lee_point;
                        Debug.Log("max : " + max);
                        Debug.Log("�� : " + shim_point);
                        Debug.Log("��: " + kim_point);
                        Debug.Log("�� : " + lee_point);
                        if (max == shim_point)
                        {
                            SceneManager.LoadScene("OT_Sim");
                        }
                        if (max == kim_point)
                        {
                            SceneManager.LoadScene("OT_Kim");
                        }
                        if (max == lee_point)
                        {
                            SceneManager.LoadScene("OT_Lee");
                        }

                    }
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
