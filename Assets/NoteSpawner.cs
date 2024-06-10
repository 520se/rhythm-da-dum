using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject leftNotePrefab;
    public GameObject rightNotePrefab;
    public Transform leftSpawnPosition;
    public Transform rightSpawnPosition;
    public Transform leftTargetPosition;
    public Transform rightTargetPosition;
    public AudioSource audioSource;
    public NotePatternData patternData;
    public float spawnInterval = 2.0f;

    private int currentPatternIndex = 0;

    void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        while (true)
        {
            // 왼쪽 위치에서 leftNotePrefab 생성 및 이동 설정
            SpawnNoteAt(leftSpawnPosition, leftNotePrefab, leftTargetPosition);
            yield return new WaitForSeconds(spawnInterval / 2);

            // 오른쪽 위치에서 rightNotePrefab 생성 및 이동 설정
            SpawnNoteAt(rightSpawnPosition, rightNotePrefab, rightTargetPosition);
            yield return new WaitForSeconds(spawnInterval / 2);
        }

        // while (currentPatternIndex < patternData.notes.Count)
        // {
        //     NoteData noteData = patternData.notes[currentPatternIndex];
        //     yield return new WaitForSeconds(noteData.time);

        //     GameObject notePrefab = (noteData.position == "L") ? leftNotePrefab : rightNotePrefab;
        //     Vector3 spawnPosition = (noteData.position == "L") ? leftSpawnPosition.position : rightSpawnPosition.position;

        //     GameObject note = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
        //     note.GetComponent<NoteMover>().SetTargetGameObject(noteData.targetGameObject);

        //     currentPatternIndex++;
        // }
    }

    private void SpawnNoteAt(Transform spawnPoint, GameObject notePrefab, Transform targetPosition)
    {
        GameObject note = Instantiate(notePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        NoteMover noteMover = note.GetComponent<NoteMover>();
        if (noteMover != null)
        {
            noteMover.targetPosition = targetPosition;
        }
    }
}
