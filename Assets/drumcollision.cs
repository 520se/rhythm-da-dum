//using Bhaptics.SDK2;
//using JetBrains.Annotations;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class drumcollision : MonoBehaviour
//{
//    private bool isMiddleColliding = false; // 중지 충돌 여부를 나타내는 변수
//    private bool isIndexColliding = false;
//    public GameObject drum;
//    public AudioSource Indexsound;
//    public AudioSource middlesound;
//    public AudioClip taikosound;
//    private AudioSource audioSource;

//    public float soundDelay = 0.5f;
//    private bool canPlaySound = true;

//    // Start is called before the first frame update
//    void Start()
//    {
//        audioSource = GetComponent<AudioSource>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        GameObject collidedObject = other.gameObject;

//        if (collidedObject.CompareTag("L_index"))
//        {

//            if (!isIndexColliding)
//            {
//                isIndexColliding = true;
//                BhapticsLibrary.Play("left_index");
//                StartCoroutine(PlaySoundWithDelay(taikosound));
//            }
//        }

//        else if (collidedObject.CompareTag("L_middle"))
//        {
//            if (!isMiddleColliding)
//            {
//                isMiddleColliding = true;
//                BhapticsLibrary.Play("left_middle");
//                StartCoroutine(PlaySoundWithDelay(taikosound));
//            }

//        }

//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("L_index"))
//        {
//            isIndexColliding = false;
//        }
//        else if (other.CompareTag("L_middle"))
//        {
//            isMiddleColliding = false;
//        }
//    }

//    IEnumerator PlaySoundWithDelay(AudioClip clip)
//    {
//        yield return new WaitForSeconds(soundDelay);

//        audioSource.clip = clip;
//        audioSource.Play();
//    }

//}

using Bhaptics.SDK2;
using System.Collections;
using UnityEngine;

public class drumcollision : MonoBehaviour
{
    private bool isLIndexColliding = false;
    private bool isLMiddleColliding = false; // 중지 충돌 여부를 나타내는 변수
    private bool isLRingColliding = false;
    private bool isLLittleColliding = false;
    private bool isRIndexColliding = false;
    private bool isRMiddleColliding = false;
    private bool isRRingColliding = false;
    private bool isRLittleColliding = false;
    public GameObject drum;
    public AudioClip taikosound;
    private AudioSource audioSource;

    public float multipleCollisionTime = 0.1f; // 여러 손가락이 동시에 충돌할 때의 시간 간격
    private bool canPlaySound = true;

    private float lastCollisionTime = -1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        // Left Hand
        if (collidedObject.CompareTag("L_index"))
        {
            if (!isLIndexColliding)
            {
                isLIndexColliding = true;
                BhapticsLibrary.Play("left_index");
                HandleCollision();
            }
        }
        else if (collidedObject.CompareTag("L_middle"))
        {
            if (!isLMiddleColliding)
            {
                isLMiddleColliding = true;
                BhapticsLibrary.Play("left_middle");
                HandleCollision();
            }
        }
        else if (collidedObject.CompareTag("L_ring"))
        {
            if (!isLRingColliding)
            {
                isLRingColliding = true;
                BhapticsLibrary.Play("left_ring");
                HandleCollision();
            }
        }
        else if (collidedObject.CompareTag("L_little"))
        {
            if (!isLLittleColliding)
            {
                isLLittleColliding = true;
                BhapticsLibrary.Play("left_little");
                HandleCollision();
            }
        }


        // Right Hand 
        else if (collidedObject.CompareTag("R_index"))
        {
            if (!isRIndexColliding)
            {
                isRIndexColliding = true;
                BhapticsLibrary.Play("right_index");
                HandleCollision();
            }
        }
        else if (collidedObject.CompareTag("R_middle"))
        {
            if (!isRMiddleColliding)
            {
                isRMiddleColliding = true;
                BhapticsLibrary.Play("right_middle");
                HandleCollision();
            }
        }
        else if (collidedObject.CompareTag("R_ring"))
        {
            if (!isRRingColliding)
            {
                isRRingColliding = true;
                BhapticsLibrary.Play("right_ring");
                HandleCollision();
            }
        }
        else if (collidedObject.CompareTag("R_little"))
        {
            if (!isRLittleColliding)
            {
                isRLittleColliding = true;
                BhapticsLibrary.Play("right_little");
                HandleCollision();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("L_index"))
        {
            isLIndexColliding = false;
        }
        else if (other.CompareTag("L_middle"))
        {
            isLMiddleColliding = false;
        }
        else if (other.CompareTag("L_ring"))
        {
            isLRingColliding = false;
        }
        else if (other.CompareTag("L_little"))
        {
            isLLittleColliding = false;
        }
        else if (other.CompareTag("R_index"))
        {
            isRIndexColliding = false;
        }
        else if (other.CompareTag("R_middle"))
        {
            isRMiddleColliding = false;
        }
        else if (other.CompareTag("R_ring"))
        {
            isRRingColliding = false;
        }
        else if (other.CompareTag("R_little"))
        {
            isRLittleColliding = false;
        }
    }

    private void HandleCollision()
    {
        float currentTime = Time.time;

        if (lastCollisionTime < 0 || currentTime - lastCollisionTime > multipleCollisionTime)
        {
            audioSource.clip = taikosound;
            audioSource.Play();
        }

        lastCollisionTime = currentTime;
    }
}
