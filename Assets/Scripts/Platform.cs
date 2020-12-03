using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    #region Other Objects
    Player player;
    LineOfDeath lineOfDeath;
    #endregion
    #region Components

    Animator platformAnim;
    #endregion
    #region Variables
    
    #endregion 
    [SerializeField]
    float distToDest = default;
    [SerializeField]
    float distance = default;



    private void Awake()
    {
        player = FindObjectOfType<Player>();
        lineOfDeath = FindObjectOfType<LineOfDeath>();
        platformAnim = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (distance > distToDest && this.transform.position.y < player.transform.position.y )
        {
            lineOfDeath.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 30);
            float mysX = (Random.Range(-10, 10));
            Debug.Log("Recycle");
            this.transform.position = new Vector2(transform.position.x + mysX, transform.position.y + 20);
        } 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platformAnim.SetTrigger("bounced");
            Debug.Log("Platform Hit");
 
        }
    }
}
