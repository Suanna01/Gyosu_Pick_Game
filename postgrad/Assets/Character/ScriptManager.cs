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
        talkData.Add(1, new string[] { "심교수님이다.", "운영체제 수업을 맡고 있다" });
        talkData.Add(2, new string[] { "김교수님", "말이 많고 항상 바쁘시다.", "알고리즘 수업을 맡고 있다." });
        talkData.Add(3, new string[] { "이교수님", "고양이를 키우신다.", "인공지능을 가르키신다."});
        talkData.Add(4, new string[] { "...","교수님들이 마음에 드나요?", "컴퓨터공학과에 지원해보겠습니까?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else
            return talkData[id][talkIndex];
    }
}
