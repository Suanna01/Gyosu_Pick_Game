using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]    //inspector â�� ���� ����
    public Dialogue dialogue;

    private DialogueManager theDM;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        //theDM.ShowDialogue(dialogue);
    }

    //***************************************************************************************************************************//
    //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))   // ��Ŭ����   ��ȭ ����   //�� �ѹ��� �Ͼ���� �ؾ���.
        {
            theDM.ShowDialogue(dialogue);
        }
    }
}
