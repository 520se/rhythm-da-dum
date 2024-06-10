using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 1.0f;

    void Update()
    {
        if (targetPosition != null)
        {
            // 현재 위치에서 목표 위치로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

            // 목표 위치에 도달하면 게임 오브젝트를 제거
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }
}

//using GLTFast.Schema;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NoteMover : MonoBehaviour
//{
//    private GameObject targetGameObject;
//    public float speed = 5f;

//    public void SetTargetGameObject(GameObject target)
//    {
//        targetGameObject = target;
//    }

//    void Update()
//    {
//        if (targetGameObject != null)
//        {
//            // Move towards the target game object
//            transform.position = Vector3.MoveTowards(transform.position, targetGameObject.transform.position, Time.deltaTime * speed);

//            // Check if reached the target position
//            if (transform.position == targetGameObject.transform.position)
//            {
//                Debug.Log("Note reached target position.");
//                Destroy(gameObject);
//            }
//        }
//    }
//}


