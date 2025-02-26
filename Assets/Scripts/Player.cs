﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    [SerializeField]
    GameManager gameManager;
    Rigidbody2D playerBody;
    AudioManager audioManager;
    Animator charAnimator;

    #endregion
    #region Variables
    [SerializeField]
    float movementSpeed = 6.0f;
    float moveInput = default;


    bool hitPlatform;
    [SerializeField]
    float bounceForce = 3;
    #endregion


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
        charAnimator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        hitPlatform = false;
    }
/// <summary>
/// Gets Player Input from horizontal axis;
/// Sets player Speed;
/// </summary>
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(moveInput * movementSpeed, playerBody.velocity.y);
    }
   //Makes sound and bounces Player if hit platforms
    private void Update()
    {
        if (hitPlatform)
        {
            playerBody.velocity = Vector2.up * bounceForce;
            audioManager.SpringSound();
            hitPlatform = false;
        }
    }
    /// <summary>
    /// If hit platform triggers animation and bounces player
    /// If line of death triggers death code;
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            hitPlatform = true;
            charAnimator.SetTrigger("isBouncing");

        }
        if (collision.gameObject.tag=="Death")
        {
            Debug.Log("GameOver");
            gameManager.PlayerDeath();
        }
    }
}
