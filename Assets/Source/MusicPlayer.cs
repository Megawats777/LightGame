using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    // The audio sources for the music
    [Header("Audio Sources")]
    public AudioSource ambientSource;
    public AudioSource actionSource;

    // The ambient track to play
    [Header("Tracks to Play")]
    public AudioClip ambeintTrack;

    // The action track to playe
    public AudioClip actionTrack;

    // Mixer snapshots
    [Header("Mixer Snapshots")]
    public AudioMixerSnapshot ambientSnapShot;
    public AudioMixerSnapshot actionSnapShot;
    public AudioMixerSnapshot gameInactiveSnapShot;

    // Called before start
    public void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        // Set the clips for the audio sources
        setAudioSourceClips();

        // Play the audio sources
        ambientSource.Play();
        actionSource.Play();

        // Transtion to the ambeint snapshot
        ambientSnapShot.TransitionTo(1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the clips for the audio sources
    private void setAudioSourceClips()
    {
        ambientSource.clip = ambeintTrack;
        actionSource.clip = actionTrack;
    }

    // Transition to action snapshot
    public void transitionToActionSnapshot()
    {
        actionSnapShot.TransitionTo(1.0f);
    }

    // Transition to game inactive snapshot
    public void transitionToGameInactiveSnapshot()
    {
        gameInactiveSnapShot.TransitionTo(1.0f);
    }
}
