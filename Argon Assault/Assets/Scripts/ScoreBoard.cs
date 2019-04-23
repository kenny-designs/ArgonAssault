using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
  [SerializeField] int scorePerHit = 12;

  int score;
  Text scoreText;

  private void Start() {
    scoreText = GetComponent<Text>();
    scoreText.text = score.ToString();
  }

  public void ScoreHit() {
    score += scorePerHit;
    scoreText.text = score.ToString();
  }
}
