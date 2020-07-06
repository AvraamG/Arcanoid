using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Frequently Reoccuring template pattern
namespace LevelManagment
{
    public abstract class Menu<T> : Menu where T : Menu<T>
    {
        private static T _instance;

        public static T Instance { get => _instance; }

        protected virtual void Awake()
        {
            if (!_instance)
            {
                DontDestroyOnLoad(this);
                _instance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            _instance = null;

        }
    }


    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {


    }
}

