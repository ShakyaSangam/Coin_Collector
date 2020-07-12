using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void sceneChange() {
        SceneManager.LoadScene("playground");
    }

    public void sceneExit() {
        Application.Quit();
    }
}
