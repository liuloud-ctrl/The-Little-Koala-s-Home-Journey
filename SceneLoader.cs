using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    private const string HOMEPAGE_SCENE = "Homepage";
    private const string LORIKEET_CHASE_SCENE = "The Lorikeet Chase";
    private const string LOST_AND_FOUND_SCENE = "Lost and Found Help";
    private const string CREEK_CROSSING_SCENE = "The Creek Crossing";
    private const string HOME_AT_LAST_SCENE = "Home at Last!";
    private const string CREDITS_SCENE = "Credits";
    
    
    private Dictionary<string, int> sceneIndices = new Dictionary<string, int>()
    {
        { HOMEPAGE_SCENE, 0 },
        { LORIKEET_CHASE_SCENE, 1 },
        { LOST_AND_FOUND_SCENE, 2 },
        { CREEK_CROSSING_SCENE, 3 },
        { HOME_AT_LAST_SCENE, 4 },
        { CREDITS_SCENE, 5 }
    };

    
    public void StartJourney()
    {
        LoadSceneByBuildIndex(1); 
    }

    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        
        if (currentSceneIndex == sceneIndices[CREDITS_SCENE])
        {
            LoadHomepage();
        }
        else if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;
        
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

   
    public void LoadHomepage()
    {
        SceneManager.LoadScene(HOMEPAGE_SCENE);
    }

    public void LoadLorikeetChase()
    {
        SceneManager.LoadScene(LORIKEET_CHASE_SCENE);
    }

    public void LoadLostAndFound()
    {
        SceneManager.LoadScene(LOST_AND_FOUND_SCENE);
    }

    public void LoadCreekCrossing()
    {
        SceneManager.LoadScene(CREEK_CROSSING_SCENE);
    }

    public void LoadHomeAtLast()
    {
        SceneManager.LoadScene(HOME_AT_LAST_SCENE);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(CREDITS_SCENE);
    }

    
    public void LoadSceneByBuildIndex(int buildIndex)
    {
        if (buildIndex >= 0 && buildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(buildIndex);
        }
        else
        {
            Debug.LogError($"场景索引 {buildIndex} 无效");
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
    void Start() { }
    void Update() { }
}