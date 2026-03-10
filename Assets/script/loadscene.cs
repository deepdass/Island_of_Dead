using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public int level;
    public void loadlevel()
    {
        SceneManager.LoadScene("level "+ level.ToString());
    }
}
