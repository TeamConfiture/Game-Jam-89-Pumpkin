using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameBehavior gameBehavior;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_pos = transform.position;
        new_pos.y -= Time.deltaTime * gameBehavior.speed;
        transform.position = new_pos;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
