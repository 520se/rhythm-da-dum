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
    public GameObject targetGameObject; // 각 노트의 타겟 게임 오브젝트
}
