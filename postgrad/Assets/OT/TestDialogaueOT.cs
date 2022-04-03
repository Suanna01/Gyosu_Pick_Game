using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogaueOT : MonoBehaviour
{
    [SerializeField]    //inspector â�� ���� ����
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
    //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
    private void Update()
    {
        if (isPlaying == 0)
        {
            if (Input.GetMouseButtonDown(1))   // ��Ŭ����   ��ȭ ����   //�� �ѹ��� �Ͼ���� �ؾ���.
            {
                isPlaying = 1;
                theDM.ShowDialogue(dialogue);
            }
        }
    }
}
