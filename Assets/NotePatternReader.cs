using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotePatternReader : MonoBehaviour
{
    public string songName;
    public NotePatternData patternData;

    void Start()
    {
        LoadPatternForSong(songName);
    }

    void LoadPatternForSong(string songName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, songName + "patterns.json");
        Debug.Log("Loading pattern from path: " + path);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            patternData = JsonUtility.FromJson<NotePatternData>(json);
            if (patternData != null)
            {
                Debug.Log("Pattern loaded successfully for song: " + songName);
            }
            else
            {
                Debug.LogError("Failed to parse pattern data for song: " + songName);
            }
        }
        else
        {
            Debug.LogError("Pattern file not found for song: " + songName);
        }
    }
}
