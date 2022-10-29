using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    bool menuOpen = false;
    public GameObject Menu;
    public GameObject UI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            toggleOpenMenu();
        }
    }
    public void toggleOpenMenu()
    {
        menuOpen = !menuOpen;
        Menu.SetActive(menuOpen);
        UI.SetActive(!menuOpen);
        if (menuOpen)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void switchScene(string scene)
    {
        Time.timeScale = 1;
        menuOpen = false;
        if (SceneManager.GetSceneByName(scene) == null) { Debug.LogError("Scene " + scene + "did not exist!"); return; }
        SceneManager.LoadScene(scene);
    }
}
