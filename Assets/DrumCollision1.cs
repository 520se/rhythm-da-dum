using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumCollision1 : MonoBehaviour
{
    private Dictionary<GameObject, bool> isCollidingDict = new Dictionary<GameObject, bool>(); // 각 손가락의 충돌 여부를 나타내는 딕셔너리

    public AudioClip taikosound; // 검지 충돌 시 재생될 소리

    public float soundDelay = 0.5f; // 소리 재생 딜레이 시간
    private float soundTimer = 0f; // 소리 재생 타이머

    private AudioSource audioSource; // AudioSource 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    // 손가락 충돌 감지
    void OnTriggerEnter(Collider other)
    {
        GameObject fingerObject = other.gameObject; // 충돌한 객체 가져오기

        if (!isCollidingDict.ContainsKey(fingerObject) || !isCollidingDict[fingerObject])
        {
            isCollidingDict[fingerObject] = true;

            if (soundTimer <= 0)
            {
                soundTimer = soundDelay; // 소리 재생 타이머 설정
                PlaySound(fingerObject); // 해당 손가락에 따른 소리 재생
            }
        }
    }

    // 손가락 충돌 종료
    void OnTriggerExit(Collider other)
    {
        GameObject fingerObject = other.gameObject; // 충돌한 객체 가져오기

        if (isCollidingDict.ContainsKey(fingerObject))
        {
            isCollidingDict[fingerObject] = false;
        }
    }

    void Update()
    {
        // 소리 재생 타이머 감소
        if (soundTimer > 0)
        {
            soundTimer -= Time.deltaTime;
        }
    }

    // 소리 재생 함수
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

       
        // 추가적인 손가락 태그가 있으면 여기에도 추가해주세요.

    }
}
