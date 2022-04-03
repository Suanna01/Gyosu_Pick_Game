using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogaueOT : MonoBehaviour
{
    [SerializeField]    //inspector 창에 띄우기 위해
    public DialogueOT dialogue;
    public int isPlaying = 0;

    private DialogueManagerOT theDM;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManagerOT>();
        //theDM.ShowDialogue(dialogue);
    }

    //***************************************************************************************************************************//
    //유튜브에서는 플레이어가 닿았을 때로 함.
    private void Update()
    {
        if (isPlaying == 0)
        {
            if (Input.GetMouseButtonDown(1))   // 우클릭시   대화 생성   //단 한번만 일어나도록 해야함.
            {
                isPlaying = 1;
                theDM.ShowDialogue(dialogue);
            }
        }
    }
}
