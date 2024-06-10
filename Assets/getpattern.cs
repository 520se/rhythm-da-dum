using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NotePatternData
{
    public List<NoteData> notes;
}

[System.Serializable]
public class NoteData
{
    public float time;
    public string position;
    public GameObject targetGameObject; // �� ��Ʈ�� Ÿ�� ���� ������Ʈ
}
