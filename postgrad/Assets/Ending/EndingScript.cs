using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    Dictionary<int, string[]> talkDataStudent;
    Dictionary<int, string[]> talkDataShim;
    Dictionary<int, string[]> talkDataLee;
    Dictionary<int, string[]> talkDataKim;

    public GameObject default_student;
    public GameObject good_student;
    public GameObject soso_student;
    public GameObject bad_student;

    // 교수님 이미지 저장할 오브젝트, 버튼 오브젝트
    public GameObject prof_shim;
    public GameObject prof_lee;
    public GameObject prof_kim;

    void Awake()
    {
        talkDataStudent = new Dictionary<int, string[]>();
        talkDataShim = new Dictionary<int, string[]>();
        talkDataLee = new Dictionary<int, string[]>();
        talkDataKim = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        /*
        talkData.Add(0, new string[] { "기다리던 졸업식이다.", "4년동안 정들었던 학교...", });

        // 심교수님 - 이교수님 - 김교수님 순서

        // 취업엔딩 - t1
        talkData.Add(1, new string[] { "나는 제법 열심히 공부해서 바로 취업에 성공하였다.", "앗 교수님이다."});
        talkData.Add(2, new string[] { "그래, 자네는 취업에 성공했다고 들었어.", "주말이라도 같이 코딩하고 자전거 탈 수 있을까?" });
        talkData.Add(3, new string[] { "이미 취업에 성공했다고 들었는데 축하하네.", "회사에서도 잘 지내길." });
        talkData.Add(4, new string[] { "예년에 비해 취업률이 더 올라간 것 같네.", "취업 축하한다." });

        // 투명인간 취급 - t5
        talkData.Add(5, new string[] { "대학생활은 참 즐거웠지만 수업을 열심히 듣지 않아서","교수님들이 나를 잘 모른다는게 아쉽다.", "교수님이랑 친해져볼걸....", "저분이 운영체제를 가르쳐주셨던가?" });
        talkData.Add(6, new string[] { "...이름이 뭐였지?","아, 그래.", "자네 머리안의 CPU 효율이 좋지 않은 것 같네." });
        talkData.Add(7, new string[] { "자네가 내 수업을 들었던가?", "아무튼 졸업 축하한다." });
        talkData.Add(8, new string[] { "자네는 신입생인가?", "내 수업을 들었으면 내가 기억을 한텐데." });

        // 최악엔딩 - 퇴학? - t6
        talkData.Add(9, new string[] { "내가 생각해도 나는 졸업하는 것만으로도 다행인 것 같다!"});
        talkData.Add(10, new string[] { "학생이 졸업을 하긴 하는 구나.", "못할 줄 알았어요."});
        talkData.Add(11, new string[] { "자네가 왜 아직도 학교에 있지?", "이제야 졸업하는 건가?", "대단하네." });
        talkData.Add(12, new string[] { "컴퓨터공학과의 수치!"});

        // 대학원생 엔딩 - 심교수님 - t13
        talkData.Add(13, new string[] { "나는 결국 심교수님의 연구실에서 더 공부를 하기로 했다.", "대학원생이 되어 교수님이랑 더 연구할 수 있어서 기쁘다.", "어 안녕하세요 교수님." });
        talkData.Add(14, new string[] { "내가 잘 도와줄테니 열심히 공부해보세요.", "그나저나 오늘 날도 좋은데 코딩하고 자전거 타러 가지 않을텐가?" });

        // 대학원생 엔딩 - 이교수님 - t15
        talkData.Add(15, new string[] { "나는 대학원에 합격했다.", "이교수님의 연구실에서 인공지능을 공부할 것이다.","잘 할 수 있을까?... 앗 교수님!" });
        talkData.Add(16, new string[] { "인공지능 수업 때부터 대학원에 가면 좋을 것 같다고 생각했었는데.", "진짜 그렇게 돼서 신기하네.", "앞으로 열심히 해보자." });

        // 대학원생 엔딩 - 김교수님 - t17
        talkData.Add(17, new string[] { "알고리즘 수업을 들으면서 대학원생이 되는 꿈을 가졌었는데", "그 꿈을 이루게 돼서 졸업식이 더 행복하다." });
        talkData.Add(18, new string[] { "학생은 전공 뿐만 아니라 교양도 충분히 갖춘 사람이군.","타의 모범이 될 만 하네." });
        */

        // 수룡이 멘트
        talkDataStudent.Add(0, new string[] { "기다리던 졸업식이다.", "4년동안 정들었던 학교...", });
        talkDataStudent.Add(1, new string[] { "나는 제법 열심히 공부해서 바로 취업에 성공하였다.", "앗 교수님이다." });
        talkDataStudent.Add(2, new string[] { "대학생활은 참 즐거웠지만 수업을 열심히 듣지 않아서", "교수님들이 나를 잘 모른다는게 아쉽다.", "교수님이랑 친해져볼걸....", "저분이 운영체제를 가르쳐주셨던가?" });
        talkDataStudent.Add(3, new string[] { "내가 생각해도 나는 졸업하는 것만으로도 다행인 것 같다!" });
        talkDataStudent.Add(4, new string[] { "나는 결국 심교수님의 연구실에서 더 공부를 하기로 했다.", "대학원생이 되어 교수님이랑 더 연구할 수 있어서 기쁘다.", "어 안녕하세요 교수님." });
        talkDataStudent.Add(5, new string[] { "나는 대학원에 합격했다.", "이교수님의 연구실에서 인공지능을 공부할 것이다.", "잘 할 수 있을까?... 앗 교수님!" });
        talkDataStudent.Add(6, new string[] { "알고리즘 수업을 들으면서 대학원생이 되는 꿈을 가졌었는데", "그 꿈을 이루게 돼서 졸업식이 더 행복하다." });

        // 심교수님 멘트
        talkDataShim.Add(1, new string[] { "그래, 자네는 취업에 성공했다고 들었어.", "주말이라도 같이 코딩하고 자전거 탈 수 있을까?" });
        talkDataShim.Add(2, new string[] { "...이름이 뭐였지?", "아, 그래.", "자네 머리안의 CPU 효율이 좋지 않은 것 같다고 생각했었어." });
        talkDataShim.Add(3, new string[] { "학생이 졸업을 하긴 하는 구나.", "못할 줄 알았어요." });
        talkDataShim.Add(4, new string[] { "내가 잘 도와줄테니 열심히 공부해보세요.", "그나저나 오늘 날도 좋은데 코딩하고 자전거 타러 가지 않을텐가?" });
        talkDataShim.Add(5, new string[] { "자네가 대학원에 간다고?", "취업을 할 줄 알았는데...","대학원 가서도 잘 할 것 같구나." });
        talkDataShim.Add(6, new string[] { "자네가 대학원에 간다고?", "자네 이름이 뭐더라.", "운영체제 수업을 들은 게 맞나..?", "대학원 붙은 건 축하하네." });
        talkDataShim.Add(7, new string[] { "자네가 대학원에 간다고?", "나는 학생이 졸업도 못할 줄 알았어요.", "대학원은 더 힘들텐데 열심히 해봐요."});

        // 이교수님 멘트
        talkDataLee.Add(1, new string[] { "이미 취업에 성공했다고 들었는데 축하하네.", "회사에서도 잘 지내길." });
        talkDataLee.Add(2, new string[] { "자네가 내 수업을 들었던가?", "아무튼 졸업 축하한다." });
        talkDataLee.Add(3, new string[] { "자네가 왜 아직도 학교에 있지?", "이제야 졸업하는 건가?", "그것도 참 대단하네." });
        talkDataLee.Add(4, new string[] { "인공지능 수업 때부터 대학원에 가면 좋을 것 같다고 생각했었는데.", "진짜 그렇게 돼서 신기하네.", "앞으로 열심히 해보자." });
        talkDataLee.Add(5, new string[] { "대학원에 간다고 들었습니다.", "취업했어도 좋았을 텐데.", "대학원에서 열심히 공부해봐요." });
        talkDataLee.Add(6, new string[] { "대학원에 간다고 들었습니다.", "몰랐는데 공부 열심히 했군요.", "축하합니다." });
        talkDataLee.Add(7, new string[] { "대학원에 간다고 들었습니다.", "졸업한 것도 신기한데 대학원이라니."});

        // 김교수님 멘트
        talkDataKim.Add(1, new string[] { "예년에 비해 취업률이 더 올라간 것 같네.", "취업 축하한다." });
        talkDataKim.Add(2, new string[] { "자네는 신입생인가?", "내 수업을 들었으면 내가 기억을 한텐데." });
        talkDataKim.Add(3, new string[] { "컴퓨터공학과의 수치!" });
        talkDataKim.Add(4, new string[] { "학생이 대학원을 선택하다니.","학생은 전공 뿐만 아니라 교양도 충분히 갖춘 사람이었어요.", "타의 모범이 될 만 하네.", "열심히 연구해봅시다."});
        talkDataKim.Add(5, new string[] { "대학원에 합격했다는게 사실인가요?", "축하합니다.", "자네는 취업을 했어도 잘 했을 거야." });
        talkDataKim.Add(6, new string[] { "대학원에 합격했다는게 사실인가요?", "이상하네요.", "열심히 공부했으면 내가 기억할텐데.", "그래도 축하합니다." });
        talkDataKim.Add(7, new string[] { "대학원에 합격했다는게 사실인가요?", "학생을 보며 컴퓨터공학과의 수치라고 생각했었는데", "다른 수업은 열심히 들었나보네요.", "축하합니다." });


    }

    public string GetTalkStudent(int id, int talkIndex)
    {
        // 대사 다 출력돼서 index가 그 길이랑 같으면 null 리턴
        if (talkIndex == talkDataStudent[id].Length) return null;
        else // index가 있는 대사 한줄만 리턴
        {
            //Change_student(id);
            return talkDataStudent[id][talkIndex];
        }
           
    }

    public string GetTalkShim(int id, int talkIndex)
    {
        prof_shim.GetComponent<SpriteRenderer>().sortingOrder = 2;
        // 대사 다 출력돼서 index가 그 길이랑 같으면 null 리턴
        if (talkIndex == talkDataShim[id].Length) return null;
        else // index가 있는 대사 한줄만 리턴
        {
            if (talkIndex > 0)
            {
                Change_student(id);
            }
            return talkDataShim[id][talkIndex];
        }
    }

    public string GetTalkLee(int id, int talkIndex)
    {
        prof_lee.GetComponent<SpriteRenderer>().sortingOrder = 2;
        // 대사 다 출력돼서 index가 그 길이랑 같으면 null 리턴
        if (talkIndex == talkDataLee[id].Length) return null;
        else // index가 있는 대사 한줄만 리턴
        {
            if (talkIndex > 0)
            {
                Change_student(id);
            }
            return talkDataLee[id][talkIndex];
        }
    }

    public string GetTalkKim(int id, int talkIndex)
    {
        prof_kim.GetComponent<SpriteRenderer>().sortingOrder = 2;
        // 대사 다 출력돼서 index가 그 길이랑 같으면 null 리턴
        if (talkIndex == talkDataKim[id].Length) return null;
        else // index가 있는 대사 한줄만 리턴
        {
            if (talkIndex > 0)
            {
                Change_student(id);
            }
            return talkDataKim[id][talkIndex];
        }
    }

    void Change_student(int id)
    {
        if (id == 1)
        {
            default_student.SetActive(true);
            good_student.SetActive(false);
            soso_student.SetActive(false);
            bad_student.SetActive(false);
        }
        else if (id == 2)
        {
            default_student.SetActive(false);
            good_student.SetActive(false);
            soso_student.SetActive(true);
            bad_student.SetActive(false);
        }
        else if (id == 3)
        {
            default_student.SetActive(false);
            good_student.SetActive(false);
            soso_student.SetActive(false);
            bad_student.SetActive(true);
        }
        else if (id == 4)
        {
            default_student.SetActive(false);
            good_student.SetActive(true);
            soso_student.SetActive(false);
            bad_student.SetActive(false);
        }
        else if (id == 5)
        {
            Change_student(1);
        }
        else if (id == 6)
        {
            Change_student(2);
        }
        else if (id == 7)
        {
            Change_student(3);
        }
    }
}
