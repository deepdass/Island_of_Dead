using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    public GameObject levelmenu;
    public GameObject optionpanel;

    public void openlevel() {
        gameObject.SetActive(false);
        levelmenu.SetActive(true);
    }
    public void closelevel()
    {
        gameObject.SetActive(true);
        levelmenu.SetActive(false);
    }

    public void openoption() {
        gameObject.SetActive(false);
        optionpanel.SetActive(true);
    }
    public void closeoption()
    {
        gameObject.SetActive(true);
        optionpanel.SetActive(false);
    }
    public void gamequit() {
        Application.Quit();
    }
}
