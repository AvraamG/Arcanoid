using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioAssets : MonoBehaviour
{
    public enum Soundeffects
    {
        Default,
        BrickHit,
        BrickBrocken,
        PowerUpCollected,
        UINavigate,
        ChangeScene,
    };

    public enum LoopedMusicType
    {
        Default,
        Chill1,
        Playfull1,
        Playfull2
    };

    private static AudioAssets _instance;

    public static AudioAssets Instance
    {
        get
        {
            if (!_instance)
            {
                try
                {
                    GameObject audioSourcesPrefab = Instantiate(Resources.Load("Audio/AudioAssets")) as GameObject;
                    if (audioSourcesPrefab)
                    {
                        _instance = audioSourcesPrefab.GetComponent<AudioAssets>();
                    }
                    else
                    {
                        Debug.LogError("The prefab does not have the Script");
                    }
                }
                catch (System.Exception)
                {
                    Debug.LogError("Missing Resources. Use some existing error system logic to handle the exception.");

                }


            }

            return _instance;
        }

    }


    [Tooltip("List of all the soundeffects of this game")]
    public List<SoundEffectAudioclip> soundEffectCollection;



    [Tooltip("List of all the looped music of this game")]
    public List<LoopedMusicAudioClip> backgroundMusicCollection;

    [Space(20)]
    public SoundEffectAudioclip soundEffectFallback;
    public LoopedMusicAudioClip loopFallback;


}
