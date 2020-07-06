using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAndPinManager : MonoBehaviour
{
    /*
     * 
     *
    static private RingAndPinManager instance = null;
    static public RingAndPinManager Instance
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
        GameObject test = new GameObject("RingAndPinManager", typeof(RingAndPinManager));
        instance = test.GetComponent<RingAndPinManager>();

    }

    private List<Ring> allRingsInGame = new List<Ring>();
    private List<Pin> allPinsInGame = new List<Pin>();
    public List<Pin> AllPinsInGame { get => allPinsInGame; }
    public List<Ring> AllRingsInGame { get => allRingsInGame; }



    #region Declaration Events

    public static System.Action<Ring> OnRingSpawned;
    public static System.Action<Ring> OnRingPlaced;
    public static System.Action<Pin> OnPinSpawned;
    public static System.Action<Pin> OnPinPlaced;


    public Pin SpawnNewPin(Transform parent)
    {
        GameObject newPin = Instantiate(RingPinAssets.Instance.pinPrefab);
        Pin pinBehavior = newPin.GetComponent<Pin>();
        allPinsInGame.Add(pinBehavior);
        newPin.name = "Pin" + allPinsInGame.Count;
        newPin.transform.parent = parent;
        return pinBehavior;
    }


    public void DropPinAtPosition(int pinIndex, Vector2 dropPosition, float landingHeight)
    {

        allPinsInGame[pinIndex].DropAndStopAt(dropPosition, landingHeight);
    }

    public Ring InstantiateRing(int ringIndex, Transform parent)
    {
        GameObject newRing = Instantiate(RingPinAssets.Instance.ringPrefabs[ringIndex]);
        newRing.transform.parent = parent;
        Ring newRingBehavior = newRing.GetComponent<Ring>();
        newRingBehavior.SizeID = allRingsInGame.Count;
        allRingsInGame.Add(newRingBehavior);
        DeclareRingSpawned(newRingBehavior);
        return newRingBehavior;
    }





    private void DeclareRingSpawned(Ring ring)
    {
        if (OnRingSpawned != null)
        {
            OnRingSpawned(ring);
        }
    }



    public void DeclareRingPlaced(Ring ring)
    {
        if (OnRingPlaced != null)
        {
            OnRingPlaced(ring);

            float volume = 0.2f;
            AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.RingPlaced, this.transform.position, volume);

        }

    }

    public void DeclarePinSpawned(Pin pin)
    {

        if (OnPinSpawned != null)
        {
            OnPinSpawned(pin);

        }
    }


    public void DeclarePinPlaced(Pin pin)
    {
        if (OnPinPlaced != null)
        {
            OnPinPlaced(pin);
            float volume = 0.1f;
            AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.PinPlaced, pin.transform.position, volume);
        }

    }
    #endregion
     */
}
