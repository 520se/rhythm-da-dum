using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumCollision1 : MonoBehaviour
{
    private Dictionary<GameObject, bool> isCollidingDict = new Dictionary<GameObject, bool>(); // �� �հ����� �浹 ���θ� ��Ÿ���� ��ųʸ�

    public AudioClip taikosound; // ���� �浹 �� ����� �Ҹ�

    public float soundDelay = 0.5f; // �Ҹ� ��� ������ �ð�
    private float soundTimer = 0f; // �Ҹ� ��� Ÿ�̸�

    private AudioSource audioSource; // AudioSource ������Ʈ

    void Start()
    {
        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
    }

    // �հ��� �浹 ����
    void OnTriggerEnter(Collider other)
    {
        GameObject fingerObject = other.gameObject; // �浹�� ��ü ��������

        if (!isCollidingDict.ContainsKey(fingerObject) || !isCollidingDict[fingerObject])
        {
            isCollidingDict[fingerObject] = true;

            if (soundTimer <= 0)
            {
                soundTimer = soundDelay; // �Ҹ� ��� Ÿ�̸� ����
                PlaySound(fingerObject); // �ش� �հ����� ���� �Ҹ� ���
            }
        }
    }

    // �հ��� �浹 ����
    void OnTriggerExit(Collider other)
    {
        GameObject fingerObject = other.gameObject; // �浹�� ��ü ��������

        if (isCollidingDict.ContainsKey(fingerObject))
        {
            isCollidingDict[fingerObject] = false;
        }
    }

    void Update()
    {
        // �Ҹ� ��� Ÿ�̸� ����
        if (soundTimer > 0)
        {
            soundTimer -= Time.deltaTime;
        }
    }

    // �Ҹ� ��� �Լ�
    void PlaySound(GameObject fingerObject)
    {
        if (fingerObject.CompareTag("L_index"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }
        else if (fingerObject.CompareTag("L_middle"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        else if (fingerObject.CompareTag("L_ring"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        else if (fingerObject.CompareTag("L_little"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        else if (fingerObject.CompareTag("R_index"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        else if (fingerObject.CompareTag("R_middle"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        else if (fingerObject.CompareTag("R_ring"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        else if (fingerObject.CompareTag("R_little"))
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

       
        // �߰����� �հ��� �±װ� ������ ���⿡�� �߰����ּ���.

    }
}
