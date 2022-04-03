using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    public Choice choice;
    private ChoiceManager theChoice;
    //public Dialague dialague1;
    //public Dialague dialague2;
    //public Dialague dialague3;
    //public Dialague dialague4;

    // Start is called before the first frame update
    void Start()
    {
        theChoice = FindObjectOfType<ChoiceManager>();
    }

    IEnumerator ACoroutine()    //���߿� public Dialague dialague1; ���� ���� ���ϰ��� ���� ������ ������� ���� ������
    {
        theChoice.ShowChoice(choice);
        yield return new WaitUntil(() => theChoice.choiceIng); //���� ��ٸ�
        Debug.Log(theChoice.GetResult());
    }
}
