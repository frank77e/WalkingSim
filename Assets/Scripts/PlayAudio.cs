using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    public float fadeTimeInSeconds;

    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(FadeAudio(true));
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(FadeAudioOut());
        }
    }

    private IEnumerator FadeAudio(bool fadeIn)
    {
        float timer = 0;
        float start = fadeIn ? 0 : 1;
        float end = fadeIn ? 1 : 0;

        if(fadeIn) audio.Play();
        while(timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(0, 1, timer / fadeTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;
        }

        audio.volume = 1;
    }

    private IEnumerator FadeAudioOut()
    {
        float timer = 0;

        while (timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(1, 0, timer / fadeTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;
        }

        audio.volume = 0;
        audio.Pause();
    }
}

