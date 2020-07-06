using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAssets : MonoBehaviour
{
    private static AvatarAssets _instance;

    public static AvatarAssets Instance
    {
        get
        {
            if (!_instance)
            {
                try
                {
                    GameObject avatarAssets = Instantiate(Resources.Load("Avatars/AvatarAssets")) as GameObject;

                    if (avatarAssets)
                    {
                        _instance = avatarAssets.GetComponent<AvatarAssets>();

                    }
                    else
                    {
                        Debug.LogError("The prefab does not have the Script");
                        GameManager.Instance.DeclareError(Session.ErrorType.CantLoadAssets);
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
    [Tooltip("")]
    public List<GameObject> ringPrefabs;


    #endregion




}
