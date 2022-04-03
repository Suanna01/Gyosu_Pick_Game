using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestDialogue2 : MonoBehaviour
{
    [SerializeField]    //inspector 창에 띄우기 위해
    public Dialogue2 dialogue;
    public int isPlaying = 0;

    private DialogueManager2 theDM;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager2>();
        //theDM.ShowDialogue(dialogue);
    }

    //***************************************************************************************************************************//
    //유튜브에서는 플레이어가 닿았을 때로 함.
    private void Update()
    {
        if (isPlaying == 0)
        {
            if (Input.GetMouseButtonDown(0))   // 좌클릭시   대화 생성   //단 한번만 일어나도록 해야함.
            {
                isPlaying = 1;
                theDM.ShowDialogue(dialogue);
            }
        }
    }
}
