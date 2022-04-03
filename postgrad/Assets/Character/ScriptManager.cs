using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1, new string[] { "�ɱ������̴�.", "�ü�� ������ �ð� �ִ�" });
        talkData.Add(2, new string[] { "�豳����", "���� ���� �׻� �ٻڽô�.", "�˰��� ������ �ð� �ִ�." });
        talkData.Add(3, new string[] { "�̱�����", "����̸� Ű��Ŵ�.", "�ΰ������� ����Ű�Ŵ�."});
        talkData.Add(4, new string[] { "...","�����Ե��� ������ �峪��?", "��ǻ�Ͱ��а��� �����غ��ڽ��ϱ�?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else
            return talkData[id][talkIndex];
    }
}
