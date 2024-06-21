//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using MixedReality.Toolkit;

//public class SelectSong : MonoBehaviour
//{
//    public NoteSpawner noteSpawner;
//    public AudioSource audioSource;

//    private const string audiofilepath = "Audio";
//    private const string notefilepath = "NotePatterns";


//    public StatefulInteractable songButton1_volcano;
//    public StatefulInteractable songButton2_redradish;
//    public StatefulInteractable songButton3_funkycarioca;

//    private Dictionary<string, string> songFilePaths = new Dictionary<string, string>
//    {
//        { "volcano", "Rhythmdadum_Data/Resources/NotePatterns/volcano.txt" },
//        { "redradish", "Rhythmdadum_Data/Resources/NotePatterns/redradish.txt" },
//        { "funkycarioca", "Rhythmdadum_Data/Resources/NotePatterns/funkycarioca.txt" },
//    };

//    private Dictionary<string, string> audioFilePaths = new Dictionary<string, string>
//    {
//        { "volcano", "Rhythmdadum_Data/Resources/Audio/volcano.mp3" },
//        { "redradish", "Rhythmdadum_Data/Resources/Audio/redradish.mp3" },
//        { "funkycarioca", "Rhythmdadum_Data/Resources/Audio/funkycarioca.mp3" },
//    };

//    void Start()
//    {
//        songButton1_volcano.OnClicked.AddListener(() => OnSongSelected("volcano"));
//        songButton2_redradish.OnClicked.AddListener(() => OnSongSelected("redradish"));
//        songButton3_funkycarioca.OnClicked.AddListener(() => OnSongSelected("funkycarioca"));
//    }

//    public void OnSongSelected(string songName)
//    {
//        if (audioSource == null)
//        {
//            Debug.LogError("AudioSource is not assigned.");
//            return;
//        }

//        Debug.Log($"Song selected: {songName}");

//        if (songFilePaths.TryGetValue(songName, out string filePath))
//        {
//            noteSpawner.notePatternFilePath = filePath;
//            Debug.Log($"Note pattern file path set to: {filePath}");
//        }
//        else
//        {
//            Debug.LogError($"No note pattern file path found for song: {songName}");
//        }

//        if (audioFilePaths.TryGetValue(songName, out string audioPath))
//        {
//            AudioClip selectedClip = Resources.Load<AudioClip>(audioPath);
//            if (selectedClip != null)
//            {
//                audioSource.clip = selectedClip;
//                noteSpawner.audioSource = audioSource; // NoteSpawner의 audioSource에 할당
//                Debug.Log($"Audio clip loaded: {audioPath}");
//            }
//            else
//            {
//                Debug.LogError($"Failed to load audio clip: {audioPath}");
//            }
//        }
//        else
//        {
//            Debug.LogError($"No audio file path found for song: {songName}");
//        }

//        noteSpawner.StartSpawning();
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MixedReality.Toolkit;

public class SelectSong : MonoBehaviour
{
    public NoteSpawner noteSpawner;
    public AudioSource audioSource;

    private const string audioFolderPath = "Audio/";
    private const string noteFolderPath = "NotePatterns/";

    public StatefulInteractable songButton1_volcano;
    public StatefulInteractable songButton2_redradish;
    public StatefulInteractable songButton3_funkycarioca;

    private Dictionary<string, string> songFilePaths = new Dictionary<string, string>
    {
        { "volcano", "volcano.txt" },
        { "redradish", "redradish.txt" },
        { "funkycarioca", "funkycarioca.txt" },
    };

    private Dictionary<string, string> audioFilePaths = new Dictionary<string, string>
    {
        { "volcano", "volcano" },
        { "redradish", "redradish" },
        { "funkycarioca", "funkycarioca" },
    };

    void Start()
    {
        songButton1_volcano.OnClicked.AddListener(() => OnSongSelected("volcano"));
        songButton2_redradish.OnClicked.AddListener(() => OnSongSelected("redradish"));
        songButton3_funkycarioca.OnClicked.AddListener(() => OnSongSelected("funkycarioca"));
    }

    public void OnSongSelected(string songName)
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        Debug.Log($"Song selected: {songName}");

        if (songFilePaths.TryGetValue(songName, out string fileName))
        {
            string filePath = noteFolderPath + fileName;
            TextAsset textAsset = Resources.Load<TextAsset>(filePath);
            if (textAsset != null)
            {
                noteSpawner.notePatternFilePath = filePath;
                Debug.Log($"Note pattern file path set to: {filePath}");
            }
            else
            {
                Debug.LogError($"Failed to load note pattern file: {filePath}");
            }
        }
        else
        {
            Debug.LogError($"No note pattern file path found for song: {songName}");
        }

        if (audioFilePaths.TryGetValue(songName, out string audioFileName))
        {
            string audioPath = audioFolderPath + audioFileName;
            AudioClip selectedClip = Resources.Load<AudioClip>(audioPath);
            if (selectedClip != null)
            {
                audioSource.clip = selectedClip;
                noteSpawner.audioSource = audioSource;
                Debug.Log($"Audio clip loaded: {audioPath}");
            }
            else
            {
                Debug.LogError($"Failed to load audio clip: {audioPath}");
            }
        }
        else
        {
            Debug.LogError($"No audio file path found for song: {songName}");
        }

        noteSpawner.StartSpawning();
    }
}
