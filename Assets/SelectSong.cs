using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectSong : MonoBehaviour
{
    public NoteSpawner noteSpawner;
    public AudioSource audioSource;
    public Button volcanoButton; // Unity UI Button component
    public Button songButton2; // Unity UI Button component
    public Button songButton3; // Unity UI Button component
    public Button songButton4; // Unity UI Button component

    private Dictionary<string, string> songFilePaths = new Dictionary<string, string>
    {
        { "volcano", "Assets/NoteTimings/volcano.txt" },
        { "Song2", "Assets/NoteTimings/song2.txt" },
        { "Song3", "Assets/NoteTimings/song3.txt" },
        { "Song4", "Assets/NoteTimings/song4.txt" }
    };

    private Dictionary<string, string> audioFilePaths = new Dictionary<string, string>
    {
        { "volcano", "Audio/volcano" },
        { "Song2", "Audio/Song2" },
        { "Song3", "Audio/Song3" },
        { "Song4", "Audio/Song4" }
    };

    //void Start()
    //{
    //    volcanoButton.onClick.AddListener(() => OnSongSelected("volcano"));
    //    songButton2.onClick.AddListener(() => OnSongSelected("Song2"));
    //    songButton3.onClick.AddListener(() => OnSongSelected("Song3"));
    //    songButton4.onClick.AddListener(() => OnSongSelected("Song4"));
    //}

    //void OnSongSelected(string songName)
    //{
    //    if (songFilePaths.TryGetValue(songName, out string filePath))
    //    {
    //        noteSpawner.noteTimingFilePath = filePath;
    //    }

    //    if (audioFilePaths.TryGetValue(songName, out string audioPath))
    //    {
    //        AudioClip selectedClip = Resources.Load<AudioClip>(audioPath); // assuming audio files are in Resources/Audio
    //        audioSource.clip = selectedClip;
    //    }

    //    noteSpawner.StartSpawning();
    //}
}
