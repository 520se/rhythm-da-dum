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
        // ����� Ŭ���� ���
        audioSource.Play();

        // �ؽ�Ʈ ���Ͽ��� ��Ʈ ���� Ÿ�̹��� �о����
        LoadNoteTimes("Assets/test.txt");
    }

    void Update()
    {
        double dspTime = AudioSettings.dspTime;

        // ���� ��Ʈ ���� �ð��� �Ǿ����� Ȯ��
        if (nextNoteIndex < noteTimes.Count && dspTime >= noteTimes[nextNoteIndex])
        {
            // ��Ʈ ����
            Instantiate(notePrefab, noteSpawnPoint.position, Quaternion.identity);

            // ���� ��Ʈ �ε��� ����
            nextNoteIndex++;
        }

        // ���� dspTime ��� (����׿�)
        Debug.Log("Current DSP Time: " + dspTime);
    }

    void LoadNoteTimes(string filePath)
    {
        noteTimes = new List<double>();

        // ���Ͽ��� �� ���� �о� ��Ʈ ���� �ð��� ����Ʈ�� �߰�
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (double.TryParse(line, out double time))
            {
                noteTimes.Add(time);
            }
        }

        // ��Ʈ ���� �ð��� ���� (�ʿ��� ���)
        noteTimes.Sort();
    }
}
