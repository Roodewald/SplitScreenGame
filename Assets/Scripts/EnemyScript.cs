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
                enemyRB.MovePosition( player1.transform.position);
            }
            else if (!player2Script.inSafeZone)
            {
                enemyRB.MovePosition( player2.transform.position);
            }
        }
    }
}
