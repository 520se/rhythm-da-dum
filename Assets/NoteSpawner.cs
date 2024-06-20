using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public class NoteData : MonoBehaviour
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
    public float offset = 1.0f;

    private List<NoteData> noteTimes;
    private int currentNoteIndex = 0;
    private bool isSongStarted = false;

    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {
        if (!isSongStarted || noteTimes == null)
            return;

        double songTime = audioSource.time;

        List<NoteData> notesToSpawn = new List<NoteData>();

        // Check for all notes that need to be spawned at the current time
        while (currentNoteIndex < noteTimes.Count && songTime >= noteTimes[currentNoteIndex].time - offset)
        {
            notesToSpawn.Add(noteTimes[currentNoteIndex]);
            currentNoteIndex++;
        }

        // Spawn all notes collected in this frame
        foreach (var noteData in notesToSpawn)
        {
            if (noteData.position.Contains("L"))
            {
                SpawnNoteAt(leftSpawnPosition, leftNotePrefab, leftTargetPosition, noteData);
            }
            if (noteData.position.Contains("R"))
            {
                SpawnNoteAt(rightSpawnPosition, rightNotePrefab, rightTargetPosition, noteData);
            }
        }

        if (isSongStarted && !audioSource.isPlaying)
        {
            isSongStarted = false;
            if (gameManager != null)
            {
                gameManager.isSongFinished = true;
                Debug.Log("Song finished. GameManager's isSongFinished set to true.");
            }
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

    private void SpawnNoteAt(Transform spawnPoint, GameObject notePrefab, Transform targetPosition, NoteData noteData)
    {
        GameObject note = Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
        NoteMover noteMover = note.GetComponent<NoteMover>();
        if (noteMover != null)
        {
            noteMover.targetPosition = targetPosition;
        }
        note.AddComponent<NoteData>().time = noteData.time;
        Debug.Log($"Spawned note at {spawnPoint.position} moving to {targetPosition.position}");
    }
}
