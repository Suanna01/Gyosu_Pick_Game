using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //Inspectorâ�� ��� �� �ְ� ��.
public class Dialogue2  //Ŀ���� Ŭ�����̹Ƿ� : MonoBehaviour ����
{
    [TextArea(1, 2)]   // ���� �� �� ���� ����
    public string[] sentences;    //������ �迭�� ����.
    public Sprite[] sprites;    //ex) ������ �׸�
    public Sprite[] dialogueWindows;    //��ȭâ -> ���� ��ȭ�ϴ����� ���� �ٲ�� �迭�� ������.
}
