using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 1.0f;
    private DrumCollision drumCollision;

    void Start()
    {
        drumCollision = FindObjectOfType<DrumCollision>();
    }

    void Update()
    {
        if (targetPosition != null)
        {
            // ���� ��ġ���� ��ǥ ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� �����ϸ� ���� ������Ʈ�� �����ϰ� Bad ����
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
            {
                drumCollision.HandleMissedNote(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
