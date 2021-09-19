using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundScript : MonoBehaviour
{
    public GameObject game;
    private GameBehavior gameBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gameBehavior = game.GetComponent<GameBehavior>();
    }

    void Update()
    {
        Vector3 new_pos = transform.position;
        new_pos.y -= Time.deltaTime * gameBehavior.speed;
        transform.position = new_pos;
        if (new_pos.y < -750 / 62.5)
        {
            gameBehavior.SpawnBackground(new_pos.y + 1350 - 225);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Destroy(this.gameObject);
    }
}
