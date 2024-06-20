using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MixedReality.Toolkit;

public class SelectSong : MonoBehaviour
{
    public NoteSpawner noteSpawner;
    public AudioSource audioSource;

    public StatefulInteractable songButton1_volcano;
    public StatefulInteractable songButton2_redradish;
    public StatefulInteractable songButton3_funkycarioca;

    private Dictionary<string, string> songFilePaths = new Dictionary<string, string>
    {
        { "volcano", "Assets/NotePatterns/volcano.txt" },
        { "redradish", "Assets/NotePatterns/redradish.txt" },
        { "funkycarioca", "Assets/NotePatterns/funkycarioca.txt" },
    };

    private Dictionary<string, string> audioFilePaths = new Dictionary<string, string>
    {
        { "volcano", "Audio/volcano" },
        { "redradish", "Audio/redradish" },
        { "funkycarioca", "Audio/funkycarioca" },
        { "Song4", "Audio/Song4" }
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
