using System.Collections;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject notePrefab; // ������ ��Ʈ ������
    public Transform[] spawnPoints;  // ��Ʈ�� ������ ��ġ �迭
    public float spawnInterval = 2f; // ��Ʈ ���� ���� (��)

    void Start()
    {
        // ���� �������� ��Ʈ�� �����ϴ� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        while (true)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                // ��Ʈ�� �����մϴ�.
                Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
