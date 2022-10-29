using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FlagScript : MonoBehaviour
{
    public string nextScene = "1";
    public GameObject Victory;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            //Player Won! Show score and victory screen
            //Calculate Score
            if(collision.gameObject.GetComponent<PlayerController>() == null) { return; }
            Time.timeScale = 0;
            collision.gameObject.GetComponent<PlayerController>().calculateScore();
            Victory.SetActive(true);
        }
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        if (SceneManager.GetSceneByName(nextScene) == null) { Debug.LogError("Scene " + nextScene + "did not exist!"); return; }
        SceneManager.LoadScene(nextScene);
    }
}
