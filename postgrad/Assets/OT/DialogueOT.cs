using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //Inspectorâ�� ��� �� �ְ� ��.
public class DialogueOT  //Ŀ���� Ŭ�����̹Ƿ� : MonoBehaviour ����
{
    [TextArea(1, 2)]   // ���� �� �� ���� ����
    public string[] sentences2;    //������ �迭�� ����.
    public Sprite[] sprites2;    //ex) ������ �׸�
    public Sprite[] dialogueWindows2;    //��ȭâ -> ���� ��ȭ�ϴ����� ���� �ٲ�� �迭�� ������.
}
