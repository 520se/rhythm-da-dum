using System.Collections;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform leftSpawnPoint; // 왼쪽에서 노트가 생성될 위치
    public Transform rightSpawnPoint; // 오른쪽에서 노트가 생성될 위치
    public float spawnInterval = 2.0f; // 노트 생성 간격

    void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        while (true)
        {
            // 왼쪽과 오른쪽에서 번갈아 가며 노트 생성
            SpawnNoteAt(leftSpawnPoint);
            yield return new WaitForSeconds(spawnInterval / 2);
            SpawnNoteAt(rightSpawnPoint);
            yield return new WaitForSeconds(spawnInterval / 2);
        }
    }

    private void SpawnNoteAt(Transform spawnPoint)
    {
        Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
