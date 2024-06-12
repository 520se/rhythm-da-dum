using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MixedReality.Toolkit;

public class SelectSong : MonoBehaviour
{
    public NoteSpawner noteSpawner;
    public AudioSource audioSource;

    public StatefulInteractable volcanoButton;
    public StatefulInteractable songButton2;
    public StatefulInteractable songButton3;
    public StatefulInteractable songButton4;

    private Dictionary<string, string> songFilePaths = new Dictionary<string, string>
    {
        { "volcano", "Assets/NotePatterns/volcano.txt" },
        { "Song2", "Assets/NotePatterns/song2.txt" },
        { "Song3", "Assets/NotePatterns/song3.txt" },
        { "Song4", "Assets/NotePatterns/song4.txt" }
    };

    private Dictionary<string, string> audioFilePaths = new Dictionary<string, string>
    {
        { "volcano", "Audio/volcano" },
        { "Song2", "Audio/Song2" },
        { "Song3", "Audio/Song3" },
        { "Song4", "Audio/Song4" }
    };

    void Start()
    {
        volcanoButton.OnClicked.AddListener(() => OnSongSelected("volcano"));
        songButton2.OnClicked.AddListener(() => OnSongSelected("Song2"));
        songButton3.OnClicked.AddListener(() => OnSongSelected("Song3"));
        songButton4.OnClicked.AddListener(() => OnSongSelected("Song4"));
    }

    public void OnSongSelected(string songName)
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        Debug.Log($"Song selected: {songName}");

        if (songFilePaths.TryGetValue(songName, out string filePath))
        {
            noteSpawner.notePatternFilePath = filePath;
            Debug.Log($"Note pattern file path set to: {filePath}");
        }
        else
        {
            Debug.LogError($"No note pattern file path found for song: {songName}");
        }

        if (audioFilePaths.TryGetValue(songName, out string audioPath))
        {
            AudioClip selectedClip = Resources.Load<AudioClip>(audioPath);
            if (selectedClip != null)
            {
                audioSource.clip = selectedClip;
                noteSpawner.audioSource = audioSource; // NoteSpawner의 audioSource에 할당
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
