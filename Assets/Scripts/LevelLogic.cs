using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    [Header("Scenes")]
    public int currentScene;
    public int backScene;
    public int nextScene;

    private int managerScene=1;
    private int sceneCountBuildIndex;

    [Header("Load Parameters")]
    private AsyncOperation asyLoad = null;
    private AsyncOperation asyUnload = null;
    public bool loading;
    private int sceneToLoad;

    void Start ()
    {
        if(SceneManager.sceneCount >= 2)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        }
            UpdateSceneState();

        if(currentScene == managerScene)
        {
            Load(nextScene);

        }
    }
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.AltGr))
        {
            if(Input.GetKeyDown(KeyCode.N)) Load(nextScene);
            if(Input.GetKeyDown(KeyCode.B)) Load(backScene);
            if(Input.GetKeyDown(KeyCode.R))  Load(currentScene);
            if(Input.GetKeyDown(KeyCode.M)) Load(managerScene);

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

    void Load(int index)
    {
        if(loading) return;

        loading = true;
        sceneToLoad = index;

        if(currentScene!=managerScene)
        {
            asyUnload = SceneManager.UnloadSceneAsync(currentScene);
        }

        asyLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        while(loading)
        {
            if((asyUnload == null || asyUnload.isDone) && asyLoad.isDone)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
                UpdateSceneState();

                loading = false;
            }
            yield return null;
        }
    }
}
