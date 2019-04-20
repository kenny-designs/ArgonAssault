using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
  [Tooltip("In ms^-1")][SerializeField] float speed = 20f;
  [Tooltip("In m")][SerializeField] float xRange = 5f;
  [Tooltip("In m")][SerializeField] float yRange = 3f;

  [SerializeField] float positionPitchFactor = -5f;
  [SerializeField] float positionYawFactor = 5f;

  [SerializeField] float controlPitchFactor = -20f;
  [SerializeField] float controlRollFactor = -20f;

  float xThrow, yThrow;

  void Update() {
    ProcessTranslation();
    ProcessRotation();
  }

  private void ProcessTranslation() {
    xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    yThrow = CrossPlatformInputManager.GetAxis("Vertical");

    float xOffset = xThrow * speed * Time.deltaTime;
    float yOffset = yThrow * speed * Time.deltaTime;

    float rawXPos = Mathf.Clamp(xOffset + transform.localPosition.x, -xRange, xRange);
    float rawYPos = Mathf.Clamp(yOffset + transform.localPosition.y, -yRange, yRange); 

    float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
    float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

    transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
  }

  private void ProcessRotation() {
    float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
    float pitchDueToControlThrow = yThrow * controlPitchFactor;
    float pitch = pitchDueToPosition + pitchDueToControlThrow;

    float yaw = transform.localPosition.x * positionYawFactor; ;

    float roll = xThrow * controlRollFactor;
    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }
}
