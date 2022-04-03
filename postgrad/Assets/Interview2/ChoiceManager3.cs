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

    // private AudioManager theAudio; // ���� ���.

    private string question2;    //Choice2�� ���� ����
    private List<string> answerList2;    //Choice2�� �亯 �迭 ����

    //��ٸ����ε�
    public GameObject go; // ��ҿ� ��Ȱ��ȭ ��ų �������� ����. setActive.

    public Text question_Text2;
    public Text[] answer_Text2;
    public GameObject[] answer_Panel2;

    //2
    /*
    private string question2;    //Choice2�� ���� ����
    private List<string> answerList2;    //Choice2�� �亯 �迭 ����
    public Text question_Text2;
    public Text[] answer_Text2;
    */

    public Animator anim;

    // public string keySound;
    // public string enterSound;

    public bool choiceIng; // ���. ()=> !choiceIng   �����ϱ� ���� ��ȭ �Ѿ�� �� ���� 
    private bool keyInput; // Űó�� Ȱ��ȭ, �� Ȱ��ȭ.    //������ �߸� Ű Ȱ��ȭ(�����ϴ� Ű), ������ ������ Ű ��Ȱ��ȭ

    private int count; // �迭�� ũ��
    private int result; // ������ ����â.

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Use this for initialization
    void Start()
    {
        //�ʱ�ȭ ��Ű��
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

    //������ ���̰��ϱ�
    public void ShowChoice(Choice2 _choice)
    {
        choiceIng = true;
        go.SetActive(true);     //������Ʈ Ȱ��ȭ  ��ٸ����ε�
        result = 0;
        question2 = _choice.question2;
        for (int i = 0; i < _choice.answers2.Length; i++)
        {
            //�迭 ũ�⸸ŭ �亯 ����Ʈ�� ��
            answerList2.Add(_choice.answers2[i]);
            answer_Panel2[i].SetActive(true);    //�г� Ȱ��ȭ
            count = i;    //count == �迭�� ũ��
        }
        anim.SetBool("Appear", true);    //�ִϸ��̼� Ȱ��ȭ
        Selection();    //�������� ������ ����ٲٱ� �Լ�
        StartCoroutine(ChoiceCoroutine());

    }

    //2
    /*
    //������ ���̰��ϱ�
    public void ShowChoice2(Choice2 _choice)
    {
        choiceIng = true;
        go.SetActive(true);     //������Ʈ Ȱ��ȭ  ��ٸ����ε�
        result = 0;
        question2 = _choice.question2;
        for (int i = 0; i < _choice.answers2.Length; i++)
        {
            //�迭 ũ�⸸ŭ �亯 ����Ʈ�� ��
            answerList2.Add(_choice.answers2[i]);
            answer_Panel[i].SetActive(true);    //�г� Ȱ��ȭ
            count = i;    //count == �迭�� ũ��
        }
        anim.SetBool("Appear", true);    //�ִϸ��̼� Ȱ��ȭ
        Selection();    //�������� ������ ����ٲٱ� �Լ�
        StartCoroutine(ChoiceCoroutine());
    }
    */


    //�� ������ �� �������� �Լ�
    public int GetResult()
    {
        go.SetActive(false);
        return result;                              //�� ����� �б� ¥�� ��.
    }

    //������ ���� �Լ�
    public void ExitChoice()
    {
        //�ʱ�ȭ
        question_Text2.text = "";
        for (int i = 0; i <= count; i++)
        {
            answer_Text2[i].text = "";
            answer_Panel2[i].SetActive(false);
        }
        answerList2.Clear();
        anim.SetBool("Appear", false);
        choiceIng = false;
        //go.SetActive(false);        //������Ʈ ��Ȱ��ȭ ��ٸ����ε�
    }


    //2
    /*
    //������ ���� �Լ�
    public void ExitChoice2()
    {
        //�ʱ�ȭ
        question_Text2.text = "";
        for (int i = 0; i <= count; i++)
        {
            answer_Text2[i].text = "";
            answer_Panel[i].SetActive(false);
        }
        answerList2.Clear();
        anim.SetBool("Appear", false);
        choiceIng = false;
        //go.SetActive(false);        //������Ʈ ��Ȱ��ȭ ��ٸ����ε�
    }
    */

    IEnumerator ChoiceCoroutine()
    {
        yield return new WaitForSeconds(0.2f);   //��� ��� ��Ű��(�ִϸ��̼� �ð�����)

        //�Ʒ��� ���� �ڸ�ƾ �Լ� ��� �����.
        StartCoroutine(TypingQuestion());    //������ ������ �����
        StartCoroutine(TypingAnswer_0());   //������ ������ �亯 1���� �������־���ϹǷ� 1���亯�� ������ �����.
        if (count >= 1)                               //������ ������ ����Ʈ�� �ԷµǾ� ������ �����.
            StartCoroutine(TypingAnswer_1());
        if (count >= 2)
            StartCoroutine(TypingAnswer_2());
        if (count >= 3)
            StartCoroutine(TypingAnswer_3());

        yield return new WaitForSeconds(0.5f);    //���
        keyInput = true;   //������ ���� Ű Ȱ��ȭ
    }

    //���� �ڸ�ƾ

    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingQuestion()
    {
        for (int i = 0; i < question2.Length; i++)
        {
            question_Text2.text += question2[i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_0()
    {
        yield return new WaitForSeconds(0.4f);    //���� ȿ��
        for (int i = 0; i < answerList2[0].Length; i++)
        {
            answer_Text2[0].text += answerList2[0][i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_1()
    {
        yield return new WaitForSeconds(0.5f);   //���� ȿ��
        for (int i = 0; i < answerList2[1].Length; i++)
        {
            answer_Text2[1].text += answerList2[1][i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_2()
    {
        yield return new WaitForSeconds(0.6f);   //���� ȿ��
        for (int i = 0; i < answerList2[2].Length; i++)
        {
            answer_Text2[2].text += answerList2[2][i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_3()
    {
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < answerList2[3].Length; i++)
        {
            answer_Text2[3].text += answerList2[3][i];
            yield return waitTime;
        }
    }

    //����� �Լ� ������ ���� ����
    //���ÿ� ������ ���(4��)�� ����ϹǷ� �ڸ�ƾ�� �׸�ŭ �߰��ؾ���.
    //�׷��� �ϳ��� �ڸ�ƾ���� �ؽ�Ʈ(���) ������ ����ϸ� ������.
    //��) 1�� ��� ��� �߿� 2�� ��� ����ϸ� ù��° �ڸ�ƾ�� ���� ��������� ����


    //2
    /*

    IEnumerator ChoiceCoroutine2()
    {
        yield return new WaitForSeconds(0.2f);   //��� ��� ��Ű��(�ִϸ��̼� �ð�����)

        //�Ʒ��� ���� �ڸ�ƾ �Լ� ��� �����.
        StartCoroutine(TypingQuestion2());    //������ ������ �����
        StartCoroutine(TypingAnswer_0_2());   //������ ������ �亯 1���� �������־���ϹǷ� 1���亯�� ������ �����.
        if (count >= 1)                               //������ ������ ����Ʈ�� �ԷµǾ� ������ �����.
            StartCoroutine(TypingAnswer_1_2());
        if (count >= 2)
            StartCoroutine(TypingAnswer_2_2());
        if (count >= 3)
            StartCoroutine(TypingAnswer_3_2());

        yield return new WaitForSeconds(0.5f);    //���
        keyInput = true;   //������ ���� Ű Ȱ��ȭ
    }

    //���� �ڸ�ƾ

    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingQuestion2()
    {
        for (int i = 0; i < question2.Length; i++)
        {
            question_Text2.text += question2[i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_0_2()
    {
        yield return new WaitForSeconds(0.4f);    //���� ȿ��
        for (int i = 0; i < answerList2[0].Length; i++)
        {
            answer_Text2[0].text += answerList2[0][i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_1_2()
    {
        yield return new WaitForSeconds(0.5f);   //���� ȿ��
        for (int i = 0; i < answerList2[1].Length; i++)
        {
            answer_Text2[1].text += answerList2[1][i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
    IEnumerator TypingAnswer_2_2()
    {
        yield return new WaitForSeconds(0.6f);   //���� ȿ��
        for (int i = 0; i < answerList2[2].Length; i++)
        {
            answer_Text2[2].text += answerList2[2][i];
            yield return waitTime;
        }
    }
    //�ѱ��ھ� ��µǰ� �ϴ� �Լ�
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
        //������ ���� Ű ���ǹ�
        if (keyInput)    //������ ���� Ű�� true�� �Ǹ� ���õ� ���� ������ �ǹǷ�
        {
            //result�� �ش� ������ ���� ���� ������ ��
            if (Input.GetKeyDown(KeyCode.UpArrow))     //���� ȭ��ǥ
            {
                //theAudio.Play(keySound);
                if (result > 0)
                    result--;             //
                else
                    result = count;    //result�� 0�̸� �迭�� ũ�⸸ŭ �ѱ�
                Selection();    //�����ϰ� �ִ� ������ ���� �ٲٱ� �Լ�
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))   //�Ʒ��� ȭ��ǥ
            {
                // theAudio.Play(keySound);
                if (result < count)
                    result++;     //�迭�� ũ�Ⱑ �Ǳ� ������ plus   
                else
                    result = 0;    //�迭�� ũ��� �Ȱ��� ���� 0����
                Selection();    //�����ϰ� �ִ� ������ ���� �ٲٱ� �Լ�
            }
            //����Ű Z
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                // theAudio.Play(enterSound);
                keyInput = false;     //ZŰ�� ������ ������ �� �亯�� �����ߴٴ� ���̹Ƿ� ���̻��� Ű�Է� ��Ȱ��ȭ 
                ExitChoice();    //������ ���� �Լ� ȣ��
            }
        }

    }

    //������ �� ������ ���õǾ����� �������� Ȯ���ϱ� ���� �Լ�
    public void Selection()
    {
        Color color = answer_Panel2[0].GetComponent<Image>().color;
        color.a = 0.75f;
        //��� �г�(������) ���� ����
        for (int i = 0; i <= count; i++)
        {
            //��� ������
            answer_Panel2[i].GetComponent<Image>().color = color;
        }
        //���õ� �͸� ��
        color.a = 1f;
        answer_Panel2[result].GetComponent<Image>().color = color;
    }
}
