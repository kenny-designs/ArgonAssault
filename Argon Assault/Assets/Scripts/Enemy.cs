using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField] GameObject deathFX;
  [SerializeField] Transform parent;
  [SerializeField] int scorePerHit = 12;
  [SerializeField] int hits = 10;

  ScoreBoard scoreBoard;

  private void Start() {
    AddNonTriggerBoxCollider();
    scoreBoard = FindObjectOfType<ScoreBoard>();
  }

  // creating our own collider at run-time for 3rd party assets helps to
  // make sure that our script doesn't break in case the components get updated
  private void AddNonTriggerBoxCollider() {
    Collider boxCollider = gameObject.AddComponent<BoxCollider>();
    boxCollider.isTrigger = false;
  }

  private void OnParticleCollision(GameObject other) {
    ProcessHit();
    if (hits <= 0) {
      KillEnemy();
    }
  }

  private void ProcessHit() {
    scoreBoard.ScoreHit(scorePerHit);
    hits--;
  }

  private void KillEnemy() {
    GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
    fx.transform.SetParent(parent);
    Destroy(gameObject);
  }
}
