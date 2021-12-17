using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BtnScript : MonoBehaviour
{
    public void btnStartpressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("1020_04");
    }
    public void btnQuitpressed()
    {
        Application.Quit();
    }
}
