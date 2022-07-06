using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This object is friendly");
                break;
            case "Finish":
                AdvanceLevel();
                break;
            default:
                Debug.Log("Sorry you crashed into something");
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void AdvanceLevel()
    {
        // Get Index of the next level
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        // If the next Scene index is not greater than the number of scenes, load it
        // otherwise, load the first level
        if (nextSceneIndex < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
