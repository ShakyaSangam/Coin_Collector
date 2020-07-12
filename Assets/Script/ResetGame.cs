using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private void OnTriggerEnter() 
    {
       SceneManager.LoadScene("Conclusion");
    }
}
