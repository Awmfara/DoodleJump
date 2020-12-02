using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    CharacterController controller;
    [SerializeField]
    AudioManager audioManager;
    #endregion
    #region Variables
    [SerializeField]
    float movementSpeed = 6.0f;
    float moveInput = default;

    private Rigidbody2D rigidbody2D;

    Vector2 moveDirection = Vector3.zero;

    bool hitPlatform;
    [SerializeField]
    float bounceForce = 3;
    #endregion


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
        hitPlatform = false;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveInput * movementSpeed, rigidbody2D.velocity.y);
    }
    private void Update()
    {
        if (hitPlatform)
        {
            rigidbody2D.velocity = Vector2.up * bounceForce;
            audioManager.SpringSound();
            hitPlatform = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            hitPlatform = true;

        }
        if (collision.gameObject.tag=="Death")
        {
            Debug.Log("GameOver");
        }
    }
}
