using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float jumpForce = 0;
    private float maxForce = 1000;
    private bool isCharging = false;
    private bool isInJumpArea = false;
    private Rigidbody playerRigidbody;
    public GameObject jumpUI;
    public TextMeshProUGUI forceText;
    private float displayedForce = 0;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateForceText();
        if (isInJumpArea && Input.GetKey(KeyCode.E))
        {
            isCharging = true;
            jumpForce = MathF.Min(jumpForce + Time.deltaTime * 300f, maxForce);
        }

        if (isInJumpArea && Input.GetKeyUp(KeyCode.E) && isCharging)
        {
            Jump();
            jumpForce = 0;
            isCharging = false;
        }
    }

    private void Jump()
    {
        Vector3 jumpDirection = transform.forward + Vector3.up;
        playerRigidbody.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
        Debug.Log(jumpForce);
    }

    private void UpdateForceText()
    {
        if (forceText != null)
        {
            float displayedForce = jumpForce / 100f;
            forceText.text = displayedForce.ToString("F1"); 
        }
        else
        {
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            isInJumpArea = true;
            jumpUI.SetActive(true);
            Debug.Log("점프가능");
        }
    }

    // Detect when player exits the designated jump area
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isInJumpArea = false;
            jumpUI.SetActive(false);
        }
    }
}