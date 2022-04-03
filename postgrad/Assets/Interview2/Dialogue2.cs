using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //Inspector창에 띄울 수 있게 함.
public class Dialogue2  //커스텀 클래스이므로 : MonoBehaviour 지움
{
    [TextArea(1, 2)]   // 문장 두 줄 까지 가능
    public string[] sentences;    //문장을 배열로 만듦.
    public Sprite[] sprites;    //ex) 교수님 그림
    public Sprite[] dialogueWindows;    //대화창 -> 누가 대화하는지에 따라 바뀌게 배열로 설정함.
}
