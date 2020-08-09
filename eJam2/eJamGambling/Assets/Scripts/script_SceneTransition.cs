using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_SceneTransition : MonoBehaviour
{
    public void SwitchScenes()
    {
        SceneManager.LoadScene(1);
    }
}
