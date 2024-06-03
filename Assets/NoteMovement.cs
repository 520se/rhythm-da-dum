using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float shrinkSpeed = 0.5f; // 노트의 축소 속도
    public Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f); // 노트가 드럼 테두리에 맞게 되었을 때의 크기
    private bool isHit = false; // 사용자가 노트를 쳤는지 여부

    void Update()
    {
        // 노트를 점점 작아지게 합니다.
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * shrinkSpeed);

        // 노트가 일정 크기 이하로 줄어들면 판정을 처리합니다.
        if (transform.localScale.x <= targetScale.x * 1.1f && !isHit)
        {
            // 여기서 가장 좋은 판정을 처리합니다.
            Debug.Log("Excellent");
        }
        else if (transform.localScale.x <= targetScale.x * 1.5f && !isHit)
        {
            // 여기서 좋은 판정을 처리합니다.
            Debug.Log("Great");
        }
        else if (transform.localScale.x <= targetScale.x * 2f && !isHit)
        {
            // 여기서 나쁜 판정을 처리합니다.
            Debug.Log("Good");
        }
        else if (transform.localScale.x <= targetScale.x * 2.5f && !isHit)
        {
            // 여기서 가장 나쁜 판정을 처리합니다.
            Debug.Log("Bad");
            Destroy(gameObject); // 노트를 삭제합니다.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drum"))
        {
            // 사용자가 노트를 쳤을 때 판정을 처리합니다.
            isHit = true;
            float currentScale = transform.localScale.x;
            if (currentScale <= targetScale.x * 1.1f)
            {
                Debug.Log("Excellent");
            }
            else if (currentScale <= targetScale.x * 1.5f)
            {
                Debug.Log("Great");
            }
            else if (currentScale <= targetScale.x * 2f)
            {
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("Bad");
            }
            Destroy(gameObject); // 노트를 삭제합니다.
        }
    }
}
