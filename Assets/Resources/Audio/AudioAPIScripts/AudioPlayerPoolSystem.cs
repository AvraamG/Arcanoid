using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pooling system specific to the context.
//TODO if there is an abstract Pool system already in the architecture such as a system that you pass a behavior and cretes a pooling instance, then:
//TODO either pass the behavior of the system to be poooled.
//TODO or if designed thatway inherit/implement from it. 30/04
public class AudioPlayerPoolSystem : MonoBehaviour
{

    static private AudioPlayerPoolSystem instance = null;
    static public AudioPlayerPoolSystem Instance
    {
        get
        {
            if (instance == null)
            {
            
                InstantiateSingleton();
            }
            return instance;
        }
    }

    static private void InstantiateSingleton()
    {
        GameObject test=    new GameObject("AudioPlayerPoolSystem", typeof(AudioPlayerPoolSystem));
        instance = test.GetComponent<AudioPlayerPoolSystem>();
       
    }

    private int initialPoolSize = 10;
    List<SingleAudioPlayer> poolOfAudioPlayers= new List<SingleAudioPlayer>();

    private void CreateAudioPlayer(int ammount = 1)
    {
        for (int i = 0; i < ammount; i++)
        {

            //TODO This can be a prefab
            GameObject newAudioPlayer = new GameObject("SingleAudioPlayer");
            newAudioPlayer.AddComponent<AudioSource>();
            newAudioPlayer.AddComponent<SingleAudioPlayer>();


            newAudioPlayer.SetActive(false);
            poolOfAudioPlayers.Add(newAudioPlayer.GetComponent<SingleAudioPlayer>());
        }
      
    }

    /// <summary>
    /// Expands the size of the pool so it can keep up with the request rate.
    /// It currently ramps statically, by 1, though it saves overuse of resources it can be further optimized to predict the requested number.
    /// </summary>
    private void ExpandPool()
    {
        //TODO optimize this with some prediction. 
        int rampAmmount = 1;
        CreateAudioPlayer(rampAmmount);
    }



    /// <summary>
    /// Provides the next available Audio player to a class that needs an audio player.
    /// If theres not one available, it will expand the pool and return the first available. 
    /// </summary>
    /// <returns></returns>
 public   SingleAudioPlayer AvailableAudioPlayer()
    {
        if (poolOfAudioPlayers.Count==0)
        {

            CreateAudioPlayer(initialPoolSize);
        }
     

        for (int i = 0; i < poolOfAudioPlayers.Count; i++)
        {
            if (!poolOfAudioPlayers[i].gameObject.activeInHierarchy   )
            {
                poolOfAudioPlayers[i].gameObject.SetActive(true);
                return poolOfAudioPlayers[i];
            }
        }

        //If theres no available audioplayer create one and since its the last in the list, return that one. 
        ExpandPool();
        poolOfAudioPlayers[poolOfAudioPlayers.Count - 1].gameObject.SetActive(true);
        return poolOfAudioPlayers[poolOfAudioPlayers.Count - 1];

    }

}
