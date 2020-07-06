using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPinAssets : MonoBehaviour
{
    private static RingPinAssets _instance;

    public static RingPinAssets Instance
    {
        get
        {
            if (!_instance)
            {
                try
                {
                    GameObject ringsPinsAssets = Instantiate(Resources.Load("RingsAndPins/RingPinAssets")) as GameObject;
                    if (ringsPinsAssets)
                    {
                        _instance = ringsPinsAssets.GetComponent<RingPinAssets>();
                    }
                    else
                    {
                        Debug.LogError("The prefab does not have the Script");
                    }
                }
                catch (System.Exception)
                {
                    Debug.LogError("Missing Resources. Use some existing error system logic to handle the exception.");
                    GameManager.Instance.DeclareError(Session.ErrorType.CantLoadAssets);
                }


            }

            return _instance;
        }

    }

    #region Resources
    [Tooltip("The prefabs of the colorful rings in this game.")]
    public List<GameObject> ringPrefabs;

    [Space(10)]
    [Tooltip("The pin Prefab of this game.")]
    public GameObject pinPrefab;
    #endregion




}
