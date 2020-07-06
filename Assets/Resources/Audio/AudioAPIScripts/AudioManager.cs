using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class AudioManager 
{

    /// <summary>
    /// Method used to Play the Background Music that will loop in the game. 
    /// Additional signatures of the method allow the customization of the call according to the needs.
    /// </summary>
    public static void PlayBackGroundMusic(AudioAssets.LoopedMusicType loopedMusic)
    {
     
    
        SingleAudioPlayer pooledAudioPlayer = AudioPlayerPoolSystem.Instance.AvailableAudioPlayer();
        AudioClip clipToPlay = GetLoopClip(loopedMusic);

        pooledAudioPlayer.SetAudioClip(clipToPlay, false);
        pooledAudioPlayer.PlayCurrentAudioClip(0.2f, false);
    }

    /// <summary>
    /// Method used to Play the Background Music that will loop in the game. 
    /// Optional values in the signature of the method allow the customization of the call according to the needs.
    /// </summary>
    public static void PlayBackGroundMusic(AudioAssets.LoopedMusicType loopedMusic, float volume=1,bool shouldLoop = true)
    {

        SingleAudioPlayer pooledAudioPlayer = AudioPlayerPoolSystem.Instance.AvailableAudioPlayer();
        AudioClip clipToPlay = GetLoopClip(loopedMusic);

        pooledAudioPlayer.SetAudioClip(clipToPlay, !shouldLoop);
        pooledAudioPlayer.PlayCurrentAudioClip(volume, shouldLoop);
    }


    /// <summary>
    /// Method used to Play the Sound effects of the game.
    ///  Optional values in the signature of the method allow the customization of the call according to the needs.
    /// </summary>
    public static void PlaySoundEffect(AudioAssets.Soundeffects soundeffect, Vector2 position,float volume=1f)
    {
        SingleAudioPlayer pooledAudioPlayer = AudioPlayerPoolSystem.Instance.AvailableAudioPlayer();
        AudioClip clipToPlay = GetSoundEffectClip(soundeffect);
        pooledAudioPlayer.transform.position = position;

        bool shouldDeactivate = true;
        pooledAudioPlayer.SetAudioClip(clipToPlay, shouldDeactivate);
        pooledAudioPlayer.PlayCurrentAudioClip(volume);
    }



    /// <summary>
    /// Provides the audioclip for the given soundeffect requested.
    /// IF the soundeffect is not in the soundeffect list, there is a fallback on a default soundeffect.
    /// </summary>
    /// <param name="requestedSoundEffect">Requires a soundeffect name.</param>
    /// <returns></returns>
    private static AudioClip GetSoundEffectClip(AudioAssets.Soundeffects requestedSoundEffect)
    {
       
        for (int i = 0; i < AudioAssets.Instance.soundEffectCollection.Count; i++)
        {

            if (requestedSoundEffect == AudioAssets.Instance.soundEffectCollection[i].soundEffectName)
            {
                return AudioAssets.Instance.soundEffectCollection[i].audioClip;
            }
           
        }

        //Fallback to a default value
        return AudioAssets.Instance.soundEffectFallback.audioClip;

    }

    /// <summary>
    /// Provides the audioclip for the given music requested.
    /// IF the music is not in the assets list, there is a fallback on a default song.
    /// </summary>
    /// <param name="requestedLoopMusic">Requires a looped music.</param>
    /// <returns></returns>
    private static AudioClip GetLoopClip(AudioAssets.LoopedMusicType requestedLoopMusic)
    {

        for (int i = 0; i < AudioAssets.Instance.soundEffectCollection.Count; i++)
        {

            if (requestedLoopMusic == AudioAssets.Instance.backgroundMusicCollection [i].loopedMusicName)
            {
                return AudioAssets.Instance.backgroundMusicCollection[i].audioClip;
            }

        }

        //Fallback to a default value
        return AudioAssets.Instance.loopFallback.audioClip;

    }






}

