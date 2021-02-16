using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    
    private Rigidbody2D enemyRB;
    private PlayerController player1Script;
    private PlayerController player2Script;
    private Vector2 spawnPosition;
    private float moveSpeed = 3f;
    private float player1Magnitude;
    private float player2Magnitude;

    public float nearest;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        //Get player script
        player1Script = player1.GetComponent<PlayerController>();
        player2Script = player2.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    { 
       if(!player1Script.inSafeZone || !player2Script.inSafeZone)
        {
            if (!player1Script.inSafeZone)
            {
                transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, moveSpeed * Time.deltaTime);
            }
            else if (!player2Script.inSafeZone)
            {
                transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, spawnPosition, moveSpeed * Time.deltaTime);
        }
       print((player1.transform.position - transform.position).magnitude);
    }
    public GameObject Nearest()
    {
        player1Magnitude = (player1.transform.position - transform.position).magnitude;
        player2Magnitude = (player2.transform.position - transform.position).magnitude;

        nearest = Mathf.Max(player1Magnitude, player2Magnitude);


        if (player1Magnitude == nearest)
        {
            return (player1);
        }
        if (player2Magnitude == nearest)
        {
            return (player2);
        }
        else
        {
            return player1;
        }
    }
}
