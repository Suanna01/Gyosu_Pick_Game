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

    // ������ �̹��� ������ ������Ʈ, ��ư ������Ʈ
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
        talkData.Add(0, new string[] { "��ٸ��� �������̴�.", "4�⵿�� ������� �б�...", });

        // �ɱ����� - �̱����� - �豳���� ����

        // ������� - t1
        talkData.Add(1, new string[] { "���� ���� ������ �����ؼ� �ٷ� ����� �����Ͽ���.", "�� �������̴�."});
        talkData.Add(2, new string[] { "�׷�, �ڳ״� ����� �����ߴٰ� �����.", "�ָ��̶� ���� �ڵ��ϰ� ������ Ż �� ������?" });
        talkData.Add(3, new string[] { "�̹� ����� �����ߴٰ� ����µ� �����ϳ�.", "ȸ�翡���� �� ������." });
        talkData.Add(4, new string[] { "���⿡ ���� ������� �� �ö� �� ����.", "��� �����Ѵ�." });

        // �����ΰ� ��� - t5
        talkData.Add(5, new string[] { "���л�Ȱ�� �� ��ſ����� ������ ������ ���� �ʾƼ�","�����Ե��� ���� �� �𸥴ٴ°� �ƽ���.", "�������̶� ģ��������....", "������ �ü���� �������̴ּ���?" });
        talkData.Add(6, new string[] { "...�̸��� ������?","��, �׷�.", "�ڳ� �Ӹ����� CPU ȿ���� ���� ���� �� ����." });
        talkData.Add(7, new string[] { "�ڳװ� �� ������ �������?", "�ƹ�ư ���� �����Ѵ�." });
        talkData.Add(8, new string[] { "�ڳ״� ���Ի��ΰ�?", "�� ������ ������� ���� ����� ���ٵ�." });

        // �־ǿ��� - ����? - t6
        talkData.Add(9, new string[] { "���� �����ص� ���� �����ϴ� �͸����ε� ������ �� ����!"});
        talkData.Add(10, new string[] { "�л��� ������ �ϱ� �ϴ� ����.", "���� �� �˾Ҿ��."});
        talkData.Add(11, new string[] { "�ڳװ� �� ������ �б��� ����?", "������ �����ϴ� �ǰ�?", "����ϳ�." });
        talkData.Add(12, new string[] { "��ǻ�Ͱ��а��� ��ġ!"});

        // ���п��� ���� - �ɱ����� - t13
        talkData.Add(13, new string[] { "���� �ᱹ �ɱ������� �����ǿ��� �� ���θ� �ϱ�� �ߴ�.", "���п����� �Ǿ� �������̶� �� ������ �� �־ ��ڴ�.", "�� �ȳ��ϼ��� ������." });
        talkData.Add(14, new string[] { "���� �� �������״� ������ �����غ�����.", "�׳����� ���� ���� ������ �ڵ��ϰ� ������ Ÿ�� ���� �����ٰ�?" });

        // ���п��� ���� - �̱����� - t15
        talkData.Add(15, new string[] { "���� ���п��� �հ��ߴ�.", "�̱������� �����ǿ��� �ΰ������� ������ ���̴�.","�� �� �� ������?... �� ������!" });
        talkData.Add(16, new string[] { "�ΰ����� ���� ������ ���п��� ���� ���� �� ���ٰ� �����߾��µ�.", "��¥ �׷��� �ż� �ű��ϳ�.", "������ ������ �غ���." });

        // ���п��� ���� - �豳���� - t17
        talkData.Add(17, new string[] { "�˰��� ������ �����鼭 ���п����� �Ǵ� ���� �������µ�", "�� ���� �̷�� �ż� �������� �� �ູ�ϴ�." });
        talkData.Add(18, new string[] { "�л��� ���� �Ӹ� �ƴ϶� ���絵 ����� ���� ����̱�.","Ÿ�� ����� �� �� �ϳ�." });
        */

        // ������ ��Ʈ
        talkDataStudent.Add(0, new string[] { "��ٸ��� �������̴�.", "4�⵿�� ������� �б�...", });
        talkDataStudent.Add(1, new string[] { "���� ���� ������ �����ؼ� �ٷ� ����� �����Ͽ���.", "�� �������̴�." });
        talkDataStudent.Add(2, new string[] { "���л�Ȱ�� �� ��ſ����� ������ ������ ���� �ʾƼ�", "�����Ե��� ���� �� �𸥴ٴ°� �ƽ���.", "�������̶� ģ��������....", "������ �ü���� �������̴ּ���?" });
        talkDataStudent.Add(3, new string[] { "���� �����ص� ���� �����ϴ� �͸����ε� ������ �� ����!" });
        talkDataStudent.Add(4, new string[] { "���� �ᱹ �ɱ������� �����ǿ��� �� ���θ� �ϱ�� �ߴ�.", "���п����� �Ǿ� �������̶� �� ������ �� �־ ��ڴ�.", "�� �ȳ��ϼ��� ������." });
        talkDataStudent.Add(5, new string[] { "���� ���п��� �հ��ߴ�.", "�̱������� �����ǿ��� �ΰ������� ������ ���̴�.", "�� �� �� ������?... �� ������!" });
        talkDataStudent.Add(6, new string[] { "�˰��� ������ �����鼭 ���п����� �Ǵ� ���� �������µ�", "�� ���� �̷�� �ż� �������� �� �ູ�ϴ�." });

        // �ɱ����� ��Ʈ
        talkDataShim.Add(1, new string[] { "�׷�, �ڳ״� ����� �����ߴٰ� �����.", "�ָ��̶� ���� �ڵ��ϰ� ������ Ż �� ������?" });
        talkDataShim.Add(2, new string[] { "...�̸��� ������?", "��, �׷�.", "�ڳ� �Ӹ����� CPU ȿ���� ���� ���� �� ���ٰ� �����߾���." });
        talkDataShim.Add(3, new string[] { "�л��� ������ �ϱ� �ϴ� ����.", "���� �� �˾Ҿ��." });
        talkDataShim.Add(4, new string[] { "���� �� �������״� ������ �����غ�����.", "�׳����� ���� ���� ������ �ڵ��ϰ� ������ Ÿ�� ���� �����ٰ�?" });
        talkDataShim.Add(5, new string[] { "�ڳװ� ���п��� ���ٰ�?", "����� �� �� �˾Ҵµ�...","���п� ������ �� �� �� ������." });
        talkDataShim.Add(6, new string[] { "�ڳװ� ���п��� ���ٰ�?", "�ڳ� �̸��� ������.", "�ü�� ������ ���� �� �³�..?", "���п� ���� �� �����ϳ�." });
        talkDataShim.Add(7, new string[] { "�ڳװ� ���п��� ���ٰ�?", "���� �л��� ������ ���� �� �˾Ҿ��.", "���п��� �� �����ٵ� ������ �غ���."});

        // �̱����� ��Ʈ
        talkDataLee.Add(1, new string[] { "�̹� ����� �����ߴٰ� ����µ� �����ϳ�.", "ȸ�翡���� �� ������." });
        talkDataLee.Add(2, new string[] { "�ڳװ� �� ������ �������?", "�ƹ�ư ���� �����Ѵ�." });
        talkDataLee.Add(3, new string[] { "�ڳװ� �� ������ �б��� ����?", "������ �����ϴ� �ǰ�?", "�װ͵� �� ����ϳ�." });
        talkDataLee.Add(4, new string[] { "�ΰ����� ���� ������ ���п��� ���� ���� �� ���ٰ� �����߾��µ�.", "��¥ �׷��� �ż� �ű��ϳ�.", "������ ������ �غ���." });
        talkDataLee.Add(5, new string[] { "���п��� ���ٰ� ������ϴ�.", "����߾ ������ �ٵ�.", "���п����� ������ �����غ���." });
        talkDataLee.Add(6, new string[] { "���п��� ���ٰ� ������ϴ�.", "�����µ� ���� ������ �߱���.", "�����մϴ�." });
        talkDataLee.Add(7, new string[] { "���п��� ���ٰ� ������ϴ�.", "������ �͵� �ű��ѵ� ���п��̶��."});

        // �豳���� ��Ʈ
        talkDataKim.Add(1, new string[] { "���⿡ ���� ������� �� �ö� �� ����.", "��� �����Ѵ�." });
        talkDataKim.Add(2, new string[] { "�ڳ״� ���Ի��ΰ�?", "�� ������ ������� ���� ����� ���ٵ�." });
        talkDataKim.Add(3, new string[] { "��ǻ�Ͱ��а��� ��ġ!" });
        talkDataKim.Add(4, new string[] { "�л��� ���п��� �����ϴٴ�.","�л��� ���� �Ӹ� �ƴ϶� ���絵 ����� ���� ����̾����.", "Ÿ�� ����� �� �� �ϳ�.", "������ �����غ��ô�."});
        talkDataKim.Add(5, new string[] { "���п��� �հ��ߴٴ°� ����ΰ���?", "�����մϴ�.", "�ڳ״� ����� �߾ �� ���� �ž�." });
        talkDataKim.Add(6, new string[] { "���п��� �հ��ߴٴ°� ����ΰ���?", "�̻��ϳ׿�.", "������ ���������� ���� ������ٵ�.", "�׷��� �����մϴ�." });
        talkDataKim.Add(7, new string[] { "���п��� �հ��ߴٴ°� ����ΰ���?", "�л��� ���� ��ǻ�Ͱ��а��� ��ġ��� �����߾��µ�", "�ٸ� ������ ������ ��������׿�.", "�����մϴ�." });


    }

    public string GetTalkStudent(int id, int talkIndex)
    {
        // ��� �� ��µż� index�� �� ���̶� ������ null ����
        if (talkIndex == talkDataStudent[id].Length) return null;
        else // index�� �ִ� ��� ���ٸ� ����
        {
            //Change_student(id);
            return talkDataStudent[id][talkIndex];
        }
           
    }

    public string GetTalkShim(int id, int talkIndex)
    {
        prof_shim.GetComponent<SpriteRenderer>().sortingOrder = 2;
        // ��� �� ��µż� index�� �� ���̶� ������ null ����
        if (talkIndex == talkDataShim[id].Length) return null;
        else // index�� �ִ� ��� ���ٸ� ����
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
        // ��� �� ��µż� index�� �� ���̶� ������ null ����
        if (talkIndex == talkDataLee[id].Length) return null;
        else // index�� �ִ� ��� ���ٸ� ����
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
        // ��� �� ��µż� index�� �� ���̶� ������ null ����
        if (talkIndex == talkDataKim[id].Length) return null;
        else // index�� �ִ� ��� ���ٸ� ����
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
