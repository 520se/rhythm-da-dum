using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject notePrefab;
    public Transform noteSpawnPoint;
    private List<double> noteTimes;
    private int nextNoteIndex = 0;

    void Start()
    {
        // 오디오 클립을 재생
        audioSource.Play();

        // 텍스트 파일에서 노트 생성 타이밍을 읽어오기
        LoadNoteTimes("Assets/test.txt");
    }

    void Update()
    {
        double dspTime = AudioSettings.dspTime;

        // 다음 노트 생성 시간이 되었는지 확인
        if (nextNoteIndex < noteTimes.Count && dspTime >= noteTimes[nextNoteIndex])
        {
            // 노트 생성
            Instantiate(notePrefab, noteSpawnPoint.position, Quaternion.identity);

            // 다음 노트 인덱스 증가
            nextNoteIndex++;
        }

        // 현재 dspTime 출력 (디버그용)
        Debug.Log("Current DSP Time: " + dspTime);
    }

    void LoadNoteTimes(string filePath)
    {
        noteTimes = new List<double>();

        // 파일에서 각 줄을 읽어 노트 생성 시간을 리스트에 추가
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (double.TryParse(line, out double time))
            {
                noteTimes.Add(time);
            }
        }

        // 노트 생성 시간을 정렬 (필요한 경우)
        noteTimes.Sort();
    }
}
