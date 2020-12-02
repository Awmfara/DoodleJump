using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Player player;
    LineOfDeath lineOfDeath;
    [SerializeField]
    float distToDest = default;
    [SerializeField]
    float distance = default;

    bool bounced = default;
   
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        lineOfDeath = FindObjectOfType<LineOfDeath>();
    }

    void Update()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        
        if (distance > distToDest&&this.transform.position.y<player.transform.position.y)
        {
            lineOfDeath.transform.position = new Vector2(this.transform.position.x,this.transform.position.y-30);
            float mysX = (Random.Range(-10, 10));
            Debug.Log("Recycle");
            this.transform.position=new Vector2(transform.position.x+mysX,transform.position.y+20);
        }
    }
}
