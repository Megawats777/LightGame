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

    // The action tracks to play
    public AudioClip[] actionTracks;

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

        // Instantly transition to the ambient snapshot
        ambientSnapShot.TransitionTo(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the clips for the audio sources
    private void setAudioSourceClips()
    {
        ambientSource.clip = ambeintTrack;

        // Set the action track to play
        setActionTrackToPlay();
    }

    // Set the action track to play
    private void setActionTrackToPlay()
    {
        // Track selection index number
        int trackSelectionIndex = Random.Range(0, actionTracks.Length);

        // If the track in the desired slot exists set the clip for the audio source
        if (actionTracks[trackSelectionIndex])
        {
            actionSource.clip = actionTracks[trackSelectionIndex];
        }
        // If the track does not exist print a warning message
        else if (!actionTracks[trackSelectionIndex])
        {
            Debug.LogWarning("Track in slot " + trackSelectionIndex.ToString() + " does not exist");
        }
        
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
