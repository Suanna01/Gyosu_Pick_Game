using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]    //inspector 창에 띄우기 위해
    public Dialogue dialogue;

    private DialogueManager theDM;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        //theDM.ShowDialogue(dialogue);
    }

    //***************************************************************************************************************************//
    //유튜브에서는 플레이어가 닿았을 때로 함.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))   // 좌클릭시   대화 생성   //단 한번만 일어나도록 해야함.
        {
            theDM.ShowDialogue(dialogue);
        }
    }
}
