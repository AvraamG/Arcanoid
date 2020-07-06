using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagment
{
    public class MenuManager : MonoBehaviour
    {

        private static MenuManager _instance;
        public static MenuManager Instance { get => _instance; }


        [SerializeField]
        private List<GameObject> allMenuPrefabs = new List<GameObject>();
        private List<Menu> allMenus = new List<Menu>();




        private void Awake()
        {
            if (!_instance)
            {
                DontDestroyOnLoad(this);
                _instance = this;
            }
            Debug.Log("Menu Manager Inistialized");
            InitializeMenus();
        }
        private void InitializeMenus()
        {

            GameObject menuParentObject = new GameObject("---Menus---");

            for (int i = 0; i < allMenuPrefabs.Count; i++)
            {
                Menu menuInstance = Instantiate(allMenuPrefabs[i], menuParentObject.transform).GetComponent<Menu>();
                allMenus.Add(menuInstance);
            }



        }

        public void OpenMenu(Menu menuInstance)
        {

            for (int i = 0; i < allMenuPrefabs.Count; i++)
            {
                if (menuInstance == allMenuPrefabs[i].GetComponent<Menu>())
                {
                    menuInstance.gameObject.SetActive(true);

                }
            }
        }


        public void CloseMenu(Menu menuInstance)
        {
            Debug.Log("Close a menu");
            for (int i = 0; i < allMenus.Count; i++)
            {
                if (menuInstance == allMenus[i])
                {
                    Debug.Log("this instance");
                    menuInstance.gameObject.SetActive(false);

                }
            }
        }

        public void GoBack()
        {

            this.gameObject.SetActive(false);
        }
    }
}

