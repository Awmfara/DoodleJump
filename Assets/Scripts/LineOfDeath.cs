using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfDeath : MonoBehaviour
{
    Player player;
    [SerializeField]
    float distToDest = 10;
    [SerializeField]
    float distance = default;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
  
    }
}
