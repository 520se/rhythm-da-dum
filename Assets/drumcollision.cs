using Bhaptics.SDK2;
using System.Collections;
using UnityEngine;

public class drumcollision : MonoBehaviour
{
    private bool isLIndexColliding = false;
    private bool isLMiddleColliding = false; // ���� �浹 ���θ� ��Ÿ���� ����
    private bool isLRingColliding = false;
    private bool isLLittleColliding = false;
    private bool isRIndexColliding = false;
    private bool isRMiddleColliding = false;
    private bool isRRingColliding = false;
    private bool isRLittleColliding = false;
    public GameObject drum;
    public AudioClip taikosound;
    private AudioSource audioSource;

    public float multipleCollisionTime = 0.1f; // ���� �հ����� ���ÿ� �浹�� ���� �ð� ����
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
