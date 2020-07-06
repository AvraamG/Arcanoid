using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SingleAudioPlayer : MonoBehaviour
{
    [SerializeField]
    bool shouldDeactivate;
    AudioSource audioSource;
    [SerializeField]
    float timeLeftToDeactivate;
    private void OnEnable()
    {
        if (!audioSource)
        {
            audioSource = this.GetComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Provides the audioclip to be played.
    /// Comes with variance in signature so the deactivation of the player can occur through here.
    /// </summary>
    /// <param name="newClip"></param>
    public void SetAudioClip(AudioClip newClip)
    {
        audioSource.clip = newClip;
   
    }

    public void SetAudioClip(AudioClip newClip,bool autoDeactivate=true)
    {
        audioSource.clip = newClip;
        shouldDeactivate = autoDeactivate;
        if (autoDeactivate )
        {
            DeactivateAfter(newClip.length);
        }
    }
    /// <summary>
    /// Sets the deactivation timer for the behavior to countdown before deactivating this gameobject.
    /// </summary>
    /// <param name="time"></param>
    public void DeactivateAfter(float time)
    {
        timeLeftToDeactivate = time;
    }


    private void Update()
    {
        DeactivateBehavior();
    }

    /// <summary>
    /// Plays the current audio clip.
    /// Multiple signatures with optional values, offer a greater control to how the audioclip will be played.
    /// </summary>
    public void PlayCurrentAudioClip()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.Play();
    }

    public void PlayCurrentAudioClip(float volume=1f)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void PlayCurrentAudioClip(float volume = 1,bool shouldLoop=false)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.loop = shouldLoop;
        audioSource.volume = volume;
        audioSource.Play();
    }

    /// <summary>
    /// Deactivates the object so it can be reused through the Pooling System
    /// </summary>
    private void DeactivateBehavior()
    {
        if (!shouldDeactivate)
        {
            return;
        }
   

        if (timeLeftToDeactivate>0)
        {
            timeLeftToDeactivate -= Time.deltaTime;
        }
        this.gameObject.SetActive(timeLeftToDeactivate > 0);
    }


}
