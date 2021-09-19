using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SisypheScript : MonoBehaviour
{

    public GameObject game;
    private GameBehavior gameBehavior;


    const float MOVE_X = 3.75F;
    // Start is called before the first frame update
    void Start()
    {
        gameBehavior = game.GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSide(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSide(1);
        }
    }

    //Just hit another collider 2D

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bonk");
        gameBehavior.Collision();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Bonkn't");
    }
    private void MoveSide(int direction)
    {
        Vector3 new_position = transform.position;
        if (direction == -1 && new_position.x > -MOVE_X)
        {
            new_position.x -= MOVE_X;
        }
        if (direction == 1 && transform.position.x < MOVE_X)
        {
            new_position.x += MOVE_X;
        }
        transform.position = new_position;
    }
}


