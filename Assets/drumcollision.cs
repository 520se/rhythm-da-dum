//using Bhaptics.SDK2;
//using System.Collections;
//using UnityEngine;

//public class drumcollision : MonoBehaviour
//{
//    private bool isLIndexColliding = false;
//    private bool isLMiddleColliding = false; // 중지 충돌 여부를 나타내는 변수
//    private bool isLRingColliding = false;
//    private bool isLLittleColliding = false;
//    private bool isRIndexColliding = false;
//    private bool isRMiddleColliding = false;
//    private bool isRRingColliding = false;
//    private bool isRLittleColliding = false;
//    public GameObject drum;
//    public AudioClip taikosound;
//    private AudioSource audioSource;

//    public float multipleCollisionTime = 0.1f; // 여러 손가락이 동시에 충돌할 때의 시간 간격
//    private bool canPlaySound = true;

//    private float lastCollisionTime = -1f;

//    void Start()
//    {
//        audioSource = GetComponent<AudioSource>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        GameObject collidedObject = other.gameObject;

//        // Left Hand
//        if (collidedObject.CompareTag("L_index"))
//        {
//            if (!isLIndexColliding)
//            {
//                isLIndexColliding = true;
//                BhapticsLibrary.Play("left_index");
//                HandleCollision();
//            }
//        }
//        else if (collidedObject.CompareTag("L_middle"))
//        {
//            if (!isLMiddleColliding)
//            {
//                isLMiddleColliding = true;
//                BhapticsLibrary.Play("left_middle");
//                HandleCollision();
//            }
//        }
//        else if (collidedObject.CompareTag("L_ring"))
//        {
//            if (!isLRingColliding)
//            {
//                isLRingColliding = true;
//                BhapticsLibrary.Play("left_ring");
//                HandleCollision();
//            }
//        }
//        else if (collidedObject.CompareTag("L_little"))
//        {
//            if (!isLLittleColliding)
//            {
//                isLLittleColliding = true;
//                BhapticsLibrary.Play("left_little");
//                HandleCollision();
//            }
//        }


//        // Right Hand 
//        else if (collidedObject.CompareTag("R_index"))
//        {
//            if (!isRIndexColliding)
//            {
//                isRIndexColliding = true;
//                BhapticsLibrary.Play("right_index");
//                HandleCollision();
//            }
//        }
//        else if (collidedObject.CompareTag("R_middle"))
//        {
//            if (!isRMiddleColliding)
//            {
//                isRMiddleColliding = true;
//                BhapticsLibrary.Play("right_middle");
//                HandleCollision();
//            }
//        }
//        else if (collidedObject.CompareTag("R_ring"))
//        {
//            if (!isRRingColliding)
//            {
//                isRRingColliding = true;
//                BhapticsLibrary.Play("right_ring");
//                HandleCollision();
//            }
//        }
//        else if (collidedObject.CompareTag("R_little"))
//        {
//            if (!isRLittleColliding)
//            {
//                isRLittleColliding = true;
//                BhapticsLibrary.Play("right_little");
//                HandleCollision();
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("L_index"))
//        {
//            isLIndexColliding = false;
//        }
//        else if (other.CompareTag("L_middle"))
//        {
//            isLMiddleColliding = false;
//        }
//        else if (other.CompareTag("L_ring"))
//        {
//            isLRingColliding = false;
//        }
//        else if (other.CompareTag("L_little"))
//        {
//            isLLittleColliding = false;
//        }
//        else if (other.CompareTag("R_index"))
//        {
//            isRIndexColliding = false;
//        }
//        else if (other.CompareTag("R_middle"))
//        {
//            isRMiddleColliding = false;
//        }
//        else if (other.CompareTag("R_ring"))
//        {
//            isRRingColliding = false;
//        }
//        else if (other.CompareTag("R_little"))
//        {
//            isRLittleColliding = false;
//        }
//    }

//    private void HandleCollision()
//    {
//        float currentTime = Time.time;

//        if (lastCollisionTime < 0 || currentTime - lastCollisionTime > multipleCollisionTime)
//        {
//            audioSource.clip = taikosound;
//            audioSource.Play();
//        }

//        lastCollisionTime = currentTime;
//    }
//}

using Bhaptics.SDK2;
using System.Collections;
using UnityEngine;

public class DrumCollision : MonoBehaviour
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

    public Transform leftJudgementLine;
    public Transform rightJudgementLine;
    public float perfectThreshold = 0.1f;
    public float greatThreshold = 0.2f;
    public float goodThreshold = 0.3f;
    public float collisionThreshold = 0.4f; // 노트와 충돌이 유효한 거리

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        string hand = ""; // 충돌한 손가락이 왼손인지 오른손인지 판별하기 위한 변수

        // Left Hand
        if (collidedObject.CompareTag("L_index"))
        {
            hand = "L";
            if (!isLIndexColliding)
            {
                isLIndexColliding = true;
                BhapticsLibrary.Play("left_index");
                HandleCollision(hand);
            }
        }
        else if (collidedObject.CompareTag("L_middle"))
        {
            hand = "L";
            if (!isLMiddleColliding)
            {
                isLMiddleColliding = true;
                BhapticsLibrary.Play("left_middle");
                HandleCollision(hand);
            }
        }
        else if (collidedObject.CompareTag("L_ring"))
        {
            hand = "L";
            if (!isLRingColliding)
            {
                isLRingColliding = true;
                BhapticsLibrary.Play("left_ring");
                HandleCollision(hand);
            }
        }
        else if (collidedObject.CompareTag("L_little"))
        {
            hand = "L";
            if (!isLLittleColliding)
            {
                isLLittleColliding = true;
                BhapticsLibrary.Play("left_little");
                HandleCollision(hand);
            }
        }
        // Right Hand 
        else if (collidedObject.CompareTag("R_index"))
        {
            hand = "R";
            if (!isRIndexColliding)
            {
                isRIndexColliding = true;
                BhapticsLibrary.Play("right_index");
                HandleCollision(hand);
            }
        }
        else if (collidedObject.CompareTag("R_middle"))
        {
            hand = "R";
            if (!isRMiddleColliding)
            {
                isRMiddleColliding = true;
                BhapticsLibrary.Play("right_middle");
                HandleCollision(hand);
            }
        }
        else if (collidedObject.CompareTag("R_ring"))
        {
            hand = "R";
            if (!isRRingColliding)
            {
                isRRingColliding = true;
                BhapticsLibrary.Play("right_ring");
                HandleCollision(hand);
            }
        }
        else if (collidedObject.CompareTag("R_little"))
        {
            hand = "R";
            if (!isRLittleColliding)
            {
                isRLittleColliding = true;
                BhapticsLibrary.Play("right_little");
                HandleCollision(hand);
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

    private void HandleCollision(string hand)
    {
        float currentTime = Time.time;

        if (lastCollisionTime < 0 || currentTime - lastCollisionTime > multipleCollisionTime)
        {
            if (canPlaySound)
            {
                audioSource.clip = taikosound;
                audioSource.Play();
                canPlaySound = false; // Prevent further sounds until cooldown
                StartCoroutine(ResetSoundCooldown());
            }

            // Check note collision and scoring
            CheckNoteCollision(hand);
        }

        lastCollisionTime = currentTime;
    }

    private IEnumerator ResetSoundCooldown()
    {
        yield return new WaitForSeconds(multipleCollisionTime);
        canPlaySound = true;
    }

    private void CheckNoteCollision(string hand)
    {
        // Find all notes currently in the scene
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");

        foreach (GameObject note in notes)
        {
            // Check if the note is the correct type (L or R) for the current hand
            if ((hand == "L" && note.GetComponent<NoteType>().noteType == NoteType.Type.L_note) ||
                (hand == "R" && note.GetComponent<NoteType>().noteType == NoteType.Type.R_note))
            {
                float distanceToJudgementLine = 0.0f;

                if (hand == "L")
                {
                    distanceToJudgementLine = Vector3.Distance(note.transform.position, leftJudgementLine.position);
                }
                else if (hand == "R")
                {
                    distanceToJudgementLine = Vector3.Distance(note.transform.position, rightJudgementLine.position);
                }

                // Check if the note is within collision threshold
                if (distanceToJudgementLine <= collisionThreshold)
                {
                    // Determine score based on distance
                    if (distanceToJudgementLine <= perfectThreshold)
                    {
                        Debug.Log("Perfect!");
                        // Handle perfect score
                        Destroy(note);
                        break;
                    }
                    else if (distanceToJudgementLine <= greatThreshold)
                    {
                        Debug.Log("Great!");
                        // Handle great score
                        Destroy(note);
                        break;
                    }
                    else if (distanceToJudgementLine <= goodThreshold)
                    {
                        Debug.Log("Good!");
                        // Handle good score
                        Destroy(note);
                        break;
                    }
                    else
                    {
                        Debug.Log("Bad!");
                        // Handle bad score
                        Destroy(note);
                        break;
                    }
                }
            }
        }
    }
}
