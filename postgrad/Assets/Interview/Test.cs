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

    IEnumerator ACoroutine()    //나중에 public Dialague dialague1; 별로 만들어서 리턴값을 따로 변수에 저장시켜 조건 나누기
    {
        theChoice.ShowChoice(choice);
        yield return new WaitUntil(() => theChoice.choiceIng); //선택 기다림
        Debug.Log(theChoice.GetResult());
    }
}
