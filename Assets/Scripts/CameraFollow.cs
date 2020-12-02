using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Player player;
    LineOfDeath lineOfDeath;
    Vector3 offset = default;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        lineOfDeath = FindObjectOfType<LineOfDeath>();
    }

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.position = new Vector3(transform.position.x, (Mathf.Clamp(transform.position.y, lineOfDeath.transform.position.y+8, Mathf.Infinity)),transform.position.z);
    }
}
