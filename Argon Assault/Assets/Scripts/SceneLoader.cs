using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
  [SerializeField] float waitTime = 3f;

  void Start() {
    Invoke("LoadFirstScene", waitTime);
  }

  private void LoadFirstScene() {
    SceneManager.LoadScene(1);
  }
}
