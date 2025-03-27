using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // MUSIC
    
    [SerializeField] SOSongData songData;
    private AudioClip song;
    private float currentBpm;
    private float secondsPerBeat;

    private float positionInSong;
    private float positionInBeats;

    private HashSet<int> beatSet;
    
    public float dspSongTime;
    private AudioSource src;

    // COMBO

    public bool Hit;
    //public bool

    private void Start(){
        song = songData.song;
        currentBpm = songData.bpm;
        secondsPerBeat = 60f/currentBpm;

        //tech jargen. thwe literal point which the audio is playing rn
        dspSongTime = (float)AudioSettings.dspTime;

        //source of song
        src = GetComponent<AudioSource>();

        beatSet = new HashSet<int>(songData.dodgeBeats);

        src.clip = song;
        src.Play();
    }

    private void Update()
    {
        //seconds since song started?
        positionInSong = (float)(AudioSettings.dspTime - dspSongTime);
        
        //how many beats since song started 
        positionInBeats = positionInSong / secondsPerBeat;

        Debug.Log(positionInBeats);
        //check if the position in beats is whole number
        if (positionInBeats == Mathf.RoundToInt(positionInBeats)){
            Beat();
        }
    }

    private void Beat(){
        if (beatSet.Contains(Mathf.RoundToInt(positionInBeats))){
            // spawn random dodgeball
            Debug.Log("Beat");
        }
    }




/*
    pseudocode.
    private void ComboCalculate(){
        if positionInBeats = 
    }
*/

}
