using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    [Header("Scenes")]
    public int backScene;
    public int currentScene;
    public int nextScene;

    private int managerScene=0;
    private int sceneCountBuildIndex;

    [Header("Load Parameters")]
    private AsyncOperation asyLoad = null;
    private AsyncOperation asyUnload = null;
    public bool loading;
    private int sceneToLoad;

    [Header("UI")]
    public Image blackScreen;
    public float fadeTime = 1.0f;

    void Start ()
    {
        if(SceneManager.sceneCount >= 2)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        }
            UpdateSceneState();

        if(currentScene == managerScene)
        {
            StartLoad(nextScene);

        }

        blackScreen.color = Color.black;
    }
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.AltGr))
        {
            if(Input.GetKeyDown(KeyCode.N)) StartLoad(nextScene);
            if(Input.GetKeyDown(KeyCode.B)) StartLoad(backScene);
            if(Input.GetKeyDown(KeyCode.R)) StartLoad(currentScene);
            if(Input.GetKeyDown(KeyCode.M)) StartLoad(managerScene);

        }
	}

    void UpdateSceneState()
    {
        sceneCountBuildIndex = SceneManager.sceneCountInBuildSettings;
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene +1 > sceneCountBuildIndex)
        {
            nextScene = managerScene +1;
        }
        else
        {
            nextScene = currentScene +1;
        }

        if(currentScene -1 > managerScene)
        {
            backScene = sceneCountBuildIndex -1;
        }
        else
        {
            backScene = currentScene -1;
        }

    }

    void StartLoad(int index)
    {
        if(loading) return;

        loading = true;
        sceneToLoad = index;

        FadeOut();
        StartCoroutine(Loading());
    }

    void Load()
    {
        if(currentScene != managerScene)
        {
            asyUnload = SceneManager.UnloadSceneAsync(currentScene);
        }

        if(currentScene != managerScene) SceneManager.UnloadSceneAsync(currentScene);
        asyLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }

    public void FadeIn()
    {
        blackScreen.CrossFadeAlpha(0, fadeTime, true);
    }

    public void FadeOut()
    {
        blackScreen.CrossFadeAlpha(1, fadeTime, true);

    }

    IEnumerator Loading()
    {
        while(loading)
        {
            if((asyUnload == null || asyUnload.isDone) && asyLoad.isDone)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
                UpdateSceneState();

                FadeIn();

                loading = false;
            }
            yield return null;
        }
    }

    IEnumerator WaitForTransition()
    {
        yield return new WaitForSeconds(fadeTime);
        Load();
    }
}
