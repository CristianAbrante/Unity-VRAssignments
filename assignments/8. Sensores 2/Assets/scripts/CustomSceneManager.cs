using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour {
    public string sceneName;
    public void onChangeSceneClick() {
        SceneManager.LoadScene(sceneName);
    }
}
