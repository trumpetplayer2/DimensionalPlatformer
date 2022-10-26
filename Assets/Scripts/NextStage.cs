using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string nextScene = "1";

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (SceneManager.GetSceneByName(nextScene) == null) { Debug.LogError("Scene " + nextScene + "did not exist!"); return; }
            SceneManager.LoadScene(nextScene);
        }
    }
}
