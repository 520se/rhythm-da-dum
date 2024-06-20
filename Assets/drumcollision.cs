using Bhaptics.SDK2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumCollision : MonoBehaviour
{

    private Dictionary<string, bool> fingerCollisionStates = new Dictionary<string, bool>();
    private Dictionary<string, float> lastCollisionTimes = new Dictionary<string, float>();

    public GameObject drum;
    public AudioClip taikosound;
    private AudioSource audioSource;

    public float multipleCollisionTime = 0.1f; // 여러 손가락이 동시에 충돌할 때의 시간 간격
    private bool canPlaySound = true;

    public Transform leftJudgementLine;
    public Transform rightJudgementLine;
    public float perfectThreshold = 0.1f;
    public float greatThreshold = 0.2f;
    public float goodThreshold = 0.3f;
    public float collisionThreshold = 0.4f; // 추가된 변수

    public GameObject perfectPrefab;
    public GameObject greatPrefab;
    public GameObject goodPrefab;
    public GameObject badPrefab;

    public int perfectscore = 50;
    public int greatscore = 30;
    public int goodscore = 10;
    public int badscore = 0;

    private HashSet<GameObject> judgedNotes = new HashSet<GameObject>(); // 이미 판정된 노트들을 추적


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Initialize finger collision states and last collision times
        string[] fingers = { "L_index", "L_middle", "L_ring", "L_little", "R_index", "R_middle", "R_ring", "R_little" };
        foreach (string finger in fingers)
        {
            fingerCollisionStates[finger] = false;
            lastCollisionTimes[finger] = -1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        string tag = collidedObject.tag;
        string hand = ""; // 충돌한 손가락이 왼손인지 오른손인지 판별하기 위한 변수

        if (fingerCollisionStates.ContainsKey(tag))
        {
            if (!fingerCollisionStates[tag])
            {
                fingerCollisionStates[tag] = true;
                if (tag.StartsWith("L"))
                {
                    hand = "L";
                }
                else if (tag.StartsWith("R"))
                {
                    hand = "R";
                }
                BhapticsLibrary.Play(tag); // haptic feedback
                HandleCollision(hand, tag);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.gameObject.tag;
        if (fingerCollisionStates.ContainsKey(tag))
        {
            fingerCollisionStates[tag] = false;
        }
    }

    private void HandleCollision(string hand, string finger)
    {
        float currentTime = Time.time;

        if (lastCollisionTimes[finger] < 0 || currentTime - lastCollisionTimes[finger] > multipleCollisionTime)
        {
            if (canPlaySound)
            {
                audioSource.clip = taikosound;
                audioSource.Play();
                canPlaySound = false; // Prevent further sounds until cooldown
                StartCoroutine(ResetSoundCooldown());
            }

            // Check note collision and scoring
            if (CheckNoteCollision(hand))
            {
                lastCollisionTimes[finger] = currentTime;
            }
        }
    }

    private IEnumerator ResetSoundCooldown()
    {
        yield return new WaitForSeconds(multipleCollisionTime);
        canPlaySound = true;
    }

    private bool CheckNoteCollision(string hand)
    {
        bool noteHit = false;

        // Find all notes currently in the scene
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");

        foreach (GameObject note in notes)
        {
            // 이미 판정된 노트는 건너뜀
            if (judgedNotes.Contains(note)) continue;

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

                // Check if the note is within the collision threshold
                if (distanceToJudgementLine <= collisionThreshold)
                {
                    // Determine score based on distance
                    if (distanceToJudgementLine <= perfectThreshold)
                    {
                        Debug.Log("Perfect!");
                        SpawnJudgementPrefab(perfectPrefab);
                        judgedNotes.Add(note);
                        Destroy(note);
                        GameManager.instance.addScore(perfectscore);
                        GameManager.instance.noteResult(0);
                        noteHit = true;
                        break;
                    }
                    else if (distanceToJudgementLine <= greatThreshold)
                    {
                        Debug.Log("Great!");
                        SpawnJudgementPrefab(greatPrefab);
                        judgedNotes.Add(note);
                        Destroy(note);
                        GameManager.instance.addScore(greatscore);
                        GameManager.instance.noteResult(1);
                        noteHit = true;
                        break;
                    }
                    else if (distanceToJudgementLine <= goodThreshold)
                    {
                        Debug.Log("Good!");
                        SpawnJudgementPrefab(goodPrefab);
                        judgedNotes.Add(note);
                        Destroy(note);
                        GameManager.instance.addScore(goodscore);
                        GameManager.instance.noteResult(2);
                        noteHit = true;
                        break;
                    }
                    else
                    {
                        Debug.Log("Bad!");
                        SpawnJudgementPrefab(badPrefab);
                        judgedNotes.Add(note);
                        Destroy(note);
                        GameManager.instance.addScore(badscore);
                        GameManager.instance.noteResult(3);
                        noteHit = true;
                        break;
                    }
                }
            }
        }

        return noteHit;
    }

    public void HandleMissedNote(GameObject note)
    {
        Debug.Log("Bad! (Missed Note)");
        SpawnJudgementPrefab(badPrefab);
        // Handle missed note logic here if needed
    }
    

    private void SpawnJudgementPrefab(GameObject prefab)
    {
        GameObject effect = Instantiate(prefab);
        Destroy(effect, 0.25f);
    }

}
