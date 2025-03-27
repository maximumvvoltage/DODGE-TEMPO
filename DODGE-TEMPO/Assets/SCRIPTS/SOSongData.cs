using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "DODGETEMPO/Song Data")]

public class SOSongData : ScriptableObject
{
    public string songName;
    public AudioClip song;
    public float bpm;
    public int[] dodgeBeats;
}
