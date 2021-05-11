using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // equation that allows the enemy to follow the player (player's position - enemy's position = direction & distance between both of them).
        // "normalized" is used to avoid the force from increasing as the distance between the enemy and the player increases.
        Vector3 followPlayer = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(followPlayer * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
