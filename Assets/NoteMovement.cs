using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float shrinkSpeed = 0.5f; // ��Ʈ�� ��� �ӵ�
    public Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f); // ��Ʈ�� �巳 �׵θ��� �°� �Ǿ��� ���� ũ��
    private bool isHit = false; // ����ڰ� ��Ʈ�� �ƴ��� ����

    void Update()
    {
        // ��Ʈ�� ���� �۾����� �մϴ�.
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * shrinkSpeed);

        // ��Ʈ�� ���� ũ�� ���Ϸ� �پ��� ������ ó���մϴ�.
        if (transform.localScale.x <= targetScale.x * 1.1f && !isHit)
        {
            // ���⼭ ���� ���� ������ ó���մϴ�.
            Debug.Log("Excellent");
        }
        else if (transform.localScale.x <= targetScale.x * 1.5f && !isHit)
        {
            // ���⼭ ���� ������ ó���մϴ�.
            Debug.Log("Great");
        }
        else if (transform.localScale.x <= targetScale.x * 2f && !isHit)
        {
            // ���⼭ ���� ������ ó���մϴ�.
            Debug.Log("Good");
        }
        else if (transform.localScale.x <= targetScale.x * 2.5f && !isHit)
        {
            // ���⼭ ���� ���� ������ ó���մϴ�.
            Debug.Log("Bad");
            Destroy(gameObject); // ��Ʈ�� �����մϴ�.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drum"))
        {
            // ����ڰ� ��Ʈ�� ���� �� ������ ó���մϴ�.
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
            Destroy(gameObject); // ��Ʈ�� �����մϴ�.
        }
    }
}
