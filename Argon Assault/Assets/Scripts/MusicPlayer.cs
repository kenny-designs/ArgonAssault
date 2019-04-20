using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
  [SerializeField] float waitTime = 3f;

  private void Awake() {
    int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
    if (numMusicPlayers > 1) {
      Destroy(gameObject);
    }
    else {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start() {
    Invoke("LoadFirstScene", waitTime);
  }

  private void LoadFirstScene() {
    SceneManager.LoadScene(1);
  }
}
