using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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

    private Player player;

    [SerializeField] Vector3 upSpawn;
    [SerializeField] Vector3 leftSpawn;
    [SerializeField] Vector3 rightSpawn;

    [SerializeField] GameObject upBall;
    [SerializeField] GameObject leftBall;
    [SerializeField] GameObject rightBall;

    //indicator object to instantiate
    public GameObject indicator;

    private void Start()
    {
        song = songData.song;
        currentBpm = songData.bpm;
        secondsPerBeat = 60f / currentBpm;

        //tech jargen. thwe literal point which the audio is playing rn
        dspSongTime = (float)AudioSettings.dspTime;

        //source of song
        src = GetComponent<AudioSource>();

        player = FindFirstObjectByType<Player>();

        beatSet = new HashSet<int>(songData.dodgeBeats);

        src.clip = song;
        src.Play();
        Beat();

    }

    private void Update()
    {
        var old = Mathf.Floor(positionInBeats);

        //seconds since song started?
        positionInSong = (float)(AudioSettings.dspTime - dspSongTime);

        //how many beats since song started 
        positionInBeats = positionInSong / secondsPerBeat;

        if (old < Mathf.Floor(positionInBeats))
        {
            Beat();
        }
    }

    private void Beat()
    {
        //funny alien dance
        var foundAliens = FindObjectsByType<alienBeatTest>(FindObjectsSortMode.None);
        foreach (var alien in foundAliens)
        {
            var script = alien.GetComponent<alienBeatTest>();
            script.Dance();
        }

        var foundIndicators = FindObjectsByType<Indicator>(FindObjectsSortMode.None);
        foreach (var indicator in foundIndicators)
        {
            indicator.Throw();
        }

        //for beats that have a dodge mapped
        if (beatSet.Contains((int)Mathf.Floor(positionInBeats)))
        {
            Indicate();
        }
    }

    void Indicate()
    {
        var dir = Random.Range(0, 3);
        var directionTrans = new Vector3();
        var fab = gameObject;
        switch (dir)
        {
            case 0:
                //up
                directionTrans = upSpawn;
                fab = upBall;
                break;
            case 1:
                //left
                directionTrans = leftSpawn;
                fab = leftBall;
                break;
            case 2:
                //right
                directionTrans = rightSpawn;
                fab = rightBall;
                break;
            default:
                Debug.Log("how");
                break;
        }
        var indi = Instantiate(indicator);
        indi.transform.position = directionTrans;
        indi.GetComponent<Indicator>().ballPrefab = fab;
    }
}



/*
    pseudocode.
    private void ComboCalculate(){
        if positionInBeats = 
    }
*/