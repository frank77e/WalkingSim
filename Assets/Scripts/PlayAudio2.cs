
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudio2 : MonoBehaviour
{
    public AudioMixerSnapshot unmutedSnapshot;
    public AudioMixerSnapshot mutedSnapshot;
    public float fadeTime;

    private AudioSource audio;
    private AudioMixer mixer;
    private float[] weights;
    private AudioMixerSnapshot[] snapshots;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        mixer = audio.outputAudioMixerGroup.audioMixer;

        snapshots = new AudioMixerSnapshot[]
        {
            unmutedSnapshot, //index 0
            mutedSnapshot       //index 1
        };

        // make an array with 2 values
        weights = new float[2];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            weights[0] = 1;
            weights[1] = 0;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}