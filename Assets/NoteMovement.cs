using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f); // 노트가 작아질 목표 스케일

    public Vector3 GetTargetScale()
    {
        return targetScale;
    }

    private Vector3 initialScale;
    private float duration = 5.0f; // 노트가 작아지는 데 걸리는 시간

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float t = Mathf.Clamp01(Time.time / duration);
        transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

        if (transform.localScale == targetScale)
        {
            Destroy(gameObject); // 목표 스케일에 도달하면 노트를 파괴
        }
    }
}
