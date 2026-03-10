using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool gameispause = false;
    public GameObject pausemenu1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gamepause();
        }
    }
    public void gamepause() {
        if (gameispause)
        {
            remuse();
        }
        else {
            pause1();
        }
    }
    public void remuse()
    {
        pausemenu1.SetActive(false);
        Time.timeScale = 1.0f;
        gameispause = false;
    }
    public void pause1()
    {
        pausemenu1.SetActive(true);
        Time.timeScale = 0f;
        gameispause = true;
    }
    public void quit1() {
        Application.Quit();
    }
    public void menu() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
    }
}
