using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    // A list of songs to play
    [SerializeField]
    private AudioClip[] levelMusic;

    // Reference to the audio source component
    private AudioSource audioSource;

    // Called before start
    public void Awake()
    {
        // Get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the song to play
        setSongToPlay();

        // Play the song
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the song to play
    private void setSongToPlay()
    {
        // The selected song
        AudioClip selectedSong;

        // Set the selected song from the list of possible entries
        selectedSong = levelMusic[Random.Range(0, levelMusic.Length)];

        // Set the audio clip of the audio source component
        audioSource.clip = selectedSong;
    }
}
