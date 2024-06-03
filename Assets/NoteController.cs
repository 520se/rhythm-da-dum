using System.Collections;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform leftSpawnPoint; // ���ʿ��� ��Ʈ�� ������ ��ġ
    public Transform rightSpawnPoint; // �����ʿ��� ��Ʈ�� ������ ��ġ
    public float spawnInterval = 2.0f; // ��Ʈ ���� ����

    void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        while (true)
        {
            // ���ʰ� �����ʿ��� ������ ���� ��Ʈ ����
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
