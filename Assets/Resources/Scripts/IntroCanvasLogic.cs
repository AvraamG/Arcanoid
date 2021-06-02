using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroCanvasLogic : MonoBehaviour
{
    bool shouldFadeFullTransparency;
    bool shouldFadeNoTransparency;

    [SerializeField]
    float fadePercentage = 0.01f;
    [SerializeField]
    Image faderImage;

    List<GameObject> allChildren = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
    }


    private void InitializeComponents()
    {

        if (!faderImage)
        {
            try
            {
                faderImage = this.transform.Find("Fade").GetComponent<Image>();

            }
            catch (System.Exception)
            {
                //  TODO create one
                throw;
            }
        }

        float startingVolume = 0.05f;
        bool shouldMusicLoop = true;

        AudioManager.PlayBackGroundMusic(AudioAssets.LoopedMusicType.Chill1, startingVolume, shouldMusicLoop);
    }

    // Update is called once per frame
    void Update()
    {
        FadeInBehavior();
        FadeOutBehavior();
    }

    public void FadeToTutorial()
    {
        AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.ChangeScene, this.transform.position);
        faderImage.gameObject.SetActive(true);
        shouldFadeFullTransparency = true;
        LevelManager.Instance.SelectLevel(0);


        StartCoroutine(LoadTutorialSceneAsync());

    }



    private void StartGame()
    {
        this.gameObject.SetActive(false);
    }

    private void FadeInBehavior()
    {
        if (shouldFadeFullTransparency)
        {
            if (faderImage.color.a < 1)
            {
                Color temporaryColor = faderImage.color;
                temporaryColor.r -= fadePercentage;
                temporaryColor.g -= fadePercentage;
                temporaryColor.b -= fadePercentage;
                temporaryColor.a += fadePercentage;
                faderImage.color = temporaryColor;

            }
            else
            {

                for (int i = 0; i < this.transform.childCount - 1; i++)
                {
                    this.transform.GetChild(i).gameObject.SetActive(false);

                }

                shouldFadeFullTransparency = false;
                shouldFadeNoTransparency = true;
            }


        }

    }


    private void FadeOutBehavior()
    {
        if (shouldFadeNoTransparency)
        {
            if (faderImage.color.a > 0f)
            {

                Color temporaryColor = faderImage.color;

                temporaryColor.a -= fadePercentage;
                faderImage.color = temporaryColor;

            }
            else
            {
                StartGame();
            }
        }
    }

    IEnumerator LoadTutorialSceneAsync()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tutorial");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone && faderImage.color.a < 1f)
        {
            yield return null;
        }

    }

}
