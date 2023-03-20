using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    Scene sceneIndex;
    [SerializeField] RawImage image;
    [SerializeField] Camera camera;
    bool istrue = false;
    private void Start()
    {
        image.enabled = false;
        Time.timeScale = 1;
        //sceneIndex = SceneManager.GetActiveScene();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void ViewFullMap()
    {
        if(istrue==false)
        {
            image.enabled = true;
            camera.fieldOfView = 130;
            istrue = true;
        }
        else
        {
            image.enabled = false;
            camera.fieldOfView = 74;
            istrue = false;
        }

        

    }

}
