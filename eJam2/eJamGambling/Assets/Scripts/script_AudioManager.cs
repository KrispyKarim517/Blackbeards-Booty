using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class script_AudioManager : MonoBehaviour
{
    public static script_AudioManager instance;
    public List<AudioClip> clips;

    private AudioSource[] sources;

    public float fadeDuration = .75f;

    private void Start() 
    {
        instance = this;
        clips = new List<AudioClip>();
        // Get all clips in Audio/Resources
        int index = 0;
    }

    // gets an audio clip index by name
    private int GetAudioClipIndex(string name) 
    {
        for (int i = 0; i < clips.Count; i++) 
        {
            if (clips[i].name.Equals(name)) 
            {
                return i;
            }
        }
        return -1;
    }

    // plays on audio clip by name
    // specify playFrom if want to create audio source on separate object
    public void PlaySound(string name, GameObject playFrom = null, bool fadeIn = false, float volume = 1f, bool looping = false) 
    {
        // gameObject.name = "Manager";
        if(name.Equals("")) 
        {
            Debug.Log("NO SOUND EQUIPPED!");
            return;
        }
        int i = GetAudioClipIndex(name);
        Debug.Assert(i != -1, "AudioManager:PlaySound::AudioMaanger has no sound" + name);
        AudioSource audioSource = null;
        // determine where to play sound from
        // play sound from the manager
        if(playFrom == null)
        {
            audioSource = sources[i];
        }
        // play sound on another object
        else 
        {
            // create audio source
            audioSource = playFrom.AddComponent<AudioSource>();
            // attach clip to audioSource
            audioSource.clip = clips[i];
            // destory audioSource after clip ends
            Destroy(audioSource, clips[i].length);
        }

        // plays the sound
        audioSource.loop = looping;
        audioSource.volume = volume;
        if(!audioSource.isPlaying)
            audioSource.Play();

        // // if want to fade in
        if (fadeIn)
            StartCoroutine(FadeIn(audioSource, fadeDuration));
    }

    public void StopSound(string name, GameObject stopFrom = null, bool fadeOut = false) 
    {
        AudioSource audioSource = null;
        // if stopping sound from manager
        if (stopFrom == null) 
        {
            int i = GetAudioClipIndex(name);
            Debug.Assert(i == -1, "AudioMaanger:StopSound::AudioSource Manager has no sound: " + name + "!");
            audioSource = sources[i];
        }
        else 
        {
            AudioSource[] audioSources = stopFrom.GetComponents<AudioSource>();
            Debug.Assert(audioSources.Length >= 1, "AudioManager:StopSound::" + stopFrom.name + " has no Audio Sources!");
            bool sourceFound = false;
            // find the correct audio source associated with the clip
            for(int i = 0; i < audioSources.Length; i++) 
            {
                if (audioSources[i].clip.name.Equals(name)) 
                {
                    // if duplicate source
                    if (sourceFound)
                        Destroy(audioSources[i]);
                    // set source
                    else 
                    {
                        audioSource = audioSources[i];
                        sourceFound = true;
                    }
                }
            }
            Debug.Assert(audioSource != null, "AudioManager:StopSound::No Audio Source with " + name + "found!");
            Destroy(audioSource, fadeDuration * 2);

            if(fadeOut)
                StartCoroutine(FadeOut(audioSource, fadeDuration));
            else
                audioSource.Stop();
        }
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        audioSource.volume = 0;
        while(audioSource.volume < 1) 
        {
            audioSource.volume += 1 * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.volume = 1;
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime) 
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0) 
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = 1;
    }
}
