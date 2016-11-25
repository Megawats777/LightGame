using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MenuMusicPlayer : MonoBehaviour
{
    // The tracks to play
    [Header("Tracks to Play")]
    public AudioClip[] menuTracks;

    // Reference to the audio source
    private AudioSource menuTrackSource;

    // Called before start
    public void Awake()
    {
        // Get the menu audio source
        menuTrackSource = GetComponentInChildren<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the audio track to play
        setPlayingAudioTrack();

        // Play the menu audio source
        menuTrackSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the audio track to play
    private void setPlayingAudioTrack()
    {
        // Track index selection number
        int trackSelectionIndex = Random.Range(0, menuTracks.Length);

        // If the selected slot has a music track set it as the played track
        if (menuTracks[trackSelectionIndex])
        {
            menuTrackSource.clip = menuTracks[trackSelectionIndex];
        }
        // If not then print a warning message
        else if (menuTracks[trackSelectionIndex])
        {
            Debug.LogWarning("Track in slot " + trackSelectionIndex.ToString() + " does not exist");
        }
    }
}
