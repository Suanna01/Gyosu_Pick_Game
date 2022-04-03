using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestDialogue2 : MonoBehaviour
{
    [SerializeField]    //inspector â�� ���� ����
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
    //��Ʃ�꿡���� �÷��̾ ����� ���� ��.
    private void Update()
    {
        if (isPlaying == 0)
        {
            if (Input.GetMouseButtonDown(0))   // ��Ŭ����   ��ȭ ����   //�� �ѹ��� �Ͼ���� �ؾ���.
            {
                isPlaying = 1;
                theDM.ShowDialogue(dialogue);
            }
        }
    }
}
