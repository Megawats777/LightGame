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

    // Mixer properties
    [Header("Mixer Properties")]
    public float ambientTransitionSpeed = 1.0f;
    public float actionStateTransitionSpeed = 1.0f;
    public float mutedStateTransitionSpeed = 1.0f;

    // Mixer snapshots
    [Header("Mixer Snapshots")]
    public AudioMixerSnapshot ambientSnapShot;
    public AudioMixerSnapshot actionSnapShot;
    public AudioMixerSnapshot gameInactiveSnapShot;
    public AudioMixerSnapshot mutedSnapShot;

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

        // Transition to the ambient snapshot
        transitionToAmbientSnapshot();
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

    // Transition to the ambient snapshot
    public void transitionToAmbientSnapshot()
    {
        ambientSnapShot.TransitionTo(ambientTransitionSpeed);
    }

    // Transition to action snapshot
    public void transitionToActionSnapshot()
    {
        actionSnapShot.TransitionTo(actionStateTransitionSpeed);
    }

    // Transition to game inactive snapshot
    public void transitionToGameInactiveSnapshot()
    {
        gameInactiveSnapShot.TransitionTo(actionStateTransitionSpeed * Time.timeScale);
    }

    // Transition to the muted snapshot
    public void transitionToMutedSnapShot()
    {
        mutedSnapShot.TransitionTo(mutedStateTransitionSpeed * Time.timeScale);
    }
}
