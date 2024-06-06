using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
		//fungsi mengganti scene melalui suatu dengan memakai parameter suatu nama scene
    public void ChangeScene (string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
		//fungsi untuk keluar dari aplikasi
    public void QuitApp()
    {
        Application.Quit();
    }
}