//using MixedReality.Toolkit;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public class NoteSpawner : MonoBehaviour
//{
//    public GameObject leftNotePrefab;
//    public GameObject rightNotePrefab;
//    public Transform leftSpawnPosition;
//    public Transform rightSpawnPosition;
//    public Transform leftTargetPosition;
//    public Transform rightTargetPosition;
//    public AudioSource audioSource;
//    public string notePatternFilePath;
//    public float songStartDelay = 2.0f;

//    private List<NoteData> noteTimes;
//    private int currentNoteIndex = 0;
//    private bool isSongStarted = false;

//    void Start()
//    {
//        //
//    }

//    void Update()
//    {
//        if (!isSongStarted)
//            return;

//        double dspTime = AudioSettings.dspTime;

//        // 현재 시간보다 이전에 생성해야 할 노트가 있는지 확인
//        while (currentNoteIndex < noteTimes.Count && dspTime >= noteTimes[currentNoteIndex].time)
//        {
//            NoteData noteData = noteTimes[currentNoteIndex];
//            Transform spawnPosition = noteData.position == "L" ? leftSpawnPosition : rightSpawnPosition;
//            GameObject notePrefab = noteData.position == "L" ? leftNotePrefab : rightNotePrefab;
//            Transform targetPosition = noteData.position == "L" ? leftTargetPosition : rightTargetPosition;

//            SpawnNoteAt(spawnPosition, notePrefab, targetPosition);

//            // 생성된 노트의 인덱스를 증가시킴
//            currentNoteIndex++;
//        }
//    }

//    public void StartSpawning()
//    {
//        Debug.Log($"Starting to spawn notes with pattern file: {notePatternFilePath}");
//        LoadNoteTimes(notePatternFilePath);
//        StartCoroutine(StartSongWithDelay(songStartDelay));
//    }

//    IEnumerator StartSongWithDelay(float delay)
//    {
//        yield return new WaitForSeconds(delay);
//        if (audioSource.clip == null)
//        {
//            Debug.LogError("Audio clip is null. Cannot play song.");
//            yield break;
//        }
//        Debug.Log("Starting song playback.");
//        audioSource.Play();
//        isSongStarted = true;
//    }

//    private void LoadNoteTimes(string filePath)
//    {
//        noteTimes = new List<NoteData>();
//        foreach (var line in File.ReadAllLines(filePath))
//        {
//            string[] parts = line.Split(',');
//            if (parts.Length == 2 && float.TryParse(parts[0], out float time))
//            {
//                noteTimes.Add(new NoteData { time = time, position = parts[1] });
//            }
//            else
//            {
//                Debug.LogError($"Invalid line in note pattern file: {line}");
//            }
//        }

//        noteTimes.Sort((a, b) => a.time.CompareTo(b.time));
//        Debug.Log($"Loaded {noteTimes.Count} notes from pattern file.");
//    }

//    private void SpawnNoteAt(Transform spawnPoint, GameObject notePrefab, Transform targetPosition)
//    {
//        GameObject note = Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
//        NoteMover noteMover = note.GetComponent<NoteMover>();
//        if (noteMover != null)
//        {
//            noteMover.targetPosition = targetPosition;
//        }
//        Debug.Log($"Spawned note at {spawnPoint.position} moving to {targetPosition.position}");
//    }
//}

using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public class NoteData
    {
        public float time;
        public string position;
    }

    public GameObject leftNotePrefab;
    public GameObject rightNotePrefab;
    public Transform leftSpawnPosition;
    public Transform rightSpawnPosition;
    public Transform leftTargetPosition;
    public Transform rightTargetPosition;
    public AudioSource audioSource;
    public string notePatternFilePath;
    public float songStartDelay = 2.0f;

    private List<NoteData> noteTimes;
    private int currentNoteIndex = 0;
    private bool isSongStarted = false;

    void Start()
    {
        // 초기화 코드
    }

    void Update()
    {
        if (!isSongStarted || noteTimes == null)
            return;

        double songTime = audioSource.time;

        // Check for all notes that need to be spawned at the current time
        while (currentNoteIndex < noteTimes.Count && songTime >= noteTimes[currentNoteIndex].time)
        {
            NoteData noteData = noteTimes[currentNoteIndex];
            Transform spawnPosition = noteData.position == "L" ? leftSpawnPosition : rightSpawnPosition;
            GameObject notePrefab = noteData.position == "L" ? leftNotePrefab : rightNotePrefab;
            Transform targetPosition = noteData.position == "L" ? leftTargetPosition : rightTargetPosition;

            SpawnNoteAt(spawnPosition, notePrefab, targetPosition);

            // Increment the note index
            currentNoteIndex++;
        }
    }

    public void StartSpawning()
    {
        Debug.Log($"Starting to spawn notes with pattern file: {notePatternFilePath}");
        LoadNoteTimes(notePatternFilePath);
        StartCoroutine(StartSongWithDelay(songStartDelay));
    }

    IEnumerator StartSongWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (audioSource.clip == null)
        {
            Debug.LogError("Audio clip is null. Cannot play song.");
            yield break;
        }
        Debug.Log("Starting song playback.");
        audioSource.Play();
        isSongStarted = true;
    }

    private void LoadNoteTimes(string filePath)
    {
        noteTimes = new List<NoteData>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2 && float.TryParse(parts[0], out float time))
            {
                noteTimes.Add(new NoteData { time = time, position = parts[1] });
            }
            else
            {
                Debug.LogError($"Invalid line in note pattern file: {line}");
            }
        }

        noteTimes.Sort((a, b) => a.time.CompareTo(b.time));
        Debug.Log($"Loaded {noteTimes.Count} notes from pattern file.");
    }

    private void SpawnNoteAt(Transform spawnPoint, GameObject notePrefab, Transform targetPosition)
    {
        GameObject note = Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
        NoteMover noteMover = note.GetComponent<NoteMover>();
        if (noteMover != null)
        {
            noteMover.targetPosition = targetPosition;
        }
        Debug.Log($"Spawned note at {spawnPoint.position} moving to {targetPosition.position}");
    }
}

