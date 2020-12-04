using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Player player;
    [SerializeField]
    GameObject backgroundBox = default;
    Vector2 resetPoint = default;
    float playerProgession = default;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        resetPoint = player.transform.position;
    }
    /// <summary>
    /// Moves background  grid to palyer if player moves beyond bounds of background
    /// </summary>
    void Update()
    {
        playerProgession = Vector2.Distance(resetPoint, player.transform.position);

        if (playerProgession>5)
        {
            backgroundBox.transform.position=player.transform.position;
            resetPoint = player.transform.position;
        }
    
    }
}
