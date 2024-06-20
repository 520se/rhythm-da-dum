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
            // 현재 위치에서 목표 위치로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

            // 목표 위치에 도달하면 게임 오브젝트를 제거하고 Bad 판정
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
            {
                drumCollision.HandleMissedNote(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
