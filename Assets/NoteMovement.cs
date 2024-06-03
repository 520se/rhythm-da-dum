using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f); // ��Ʈ�� �۾��� ��ǥ ������

    public Vector3 GetTargetScale()
    {
        return targetScale;
    }

    private Vector3 initialScale;
    private float duration = 5.0f; // ��Ʈ�� �۾����� �� �ɸ��� �ð�

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
            Destroy(gameObject); // ��ǥ �����Ͽ� �����ϸ� ��Ʈ�� �ı�
        }
    }
}
