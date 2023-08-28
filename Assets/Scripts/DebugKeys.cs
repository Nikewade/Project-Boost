using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugKeys : MonoBehaviour
{
    bool collisions = true;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScene();
            Debug.Log("(Debug Key) Next Scene Loaded");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
              gameObject.GetComponent<CollisionHandler>().enabled = !gameObject.GetComponent<CollisionHandler>().enabled;
              Debug.Log(collisions ? "(Debug Key) Collisions disabled." : "(Debug Key) Collisions enabled.");
              collisions = !collisions;
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
