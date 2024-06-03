using System.Collections;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject notePrefab; // 생성할 노트 프리팹
    public Transform[] spawnPoints;  // 노트가 생성될 위치 배열
    public float spawnInterval = 2f; // 노트 생성 간격 (초)

    void Start()
    {
        // 일정 간격으로 노트를 생성하는 코루틴을 시작합니다.
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        while (true)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                // 노트를 생성합니다.
                Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
