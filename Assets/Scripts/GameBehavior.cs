using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{

    public GameObject[] obstacles; // The prefabs for the obstacles
    public GameObject timerObject;
    public GameObject backgroundPrefab;

    public GameObject backgroundContainer;

    public GameObject arrowSlow;
    public GameObject arrowNormal;
    public GameObject arrowFast;

    public GameObject collisionAnimation;

    private Timer timer;

    public static float distance;


    private const float OBSTACLE_HIT_PENALTY = 10f;

    // Values for the diferent possible speeds.
    private const float SLOW = 2f;
    private const float NORMAL = 4f;
    private const float FAST = 8f;

    // Moving speed of Sisyphus
    public float speed;

    float distSinceLastSpawn;

    const float distBetweenSpawns = 4f; // Does not account for the speed


    // Start is called before the first frame update
    void Start()
    {
        speed = NORMAL;
        timer = timerObject.GetComponent<Timer>();
        SpawnObstacle();
        distSinceLastSpawn = 0f;
        distance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
        HandleSpawn();
        if (timer.time == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Outro");
        }
    }

    public void Collision()
    {
        arrowNormal.SetActive(false);
        arrowFast.SetActive(false);
        arrowSlow.SetActive(true);
        timer.RemoveTime(OBSTACLE_HIT_PENALTY);
        GameObject animation = Instantiate(collisionAnimation);
        Animator animator = animation.GetComponent<Animator>();
        animator.Play("Minus10");
        Destroy(animation, animator.GetCurrentAnimatorStateInfo(0).length);
        speed = SLOW;
    }

    private void UpdateSpeed()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            switch (speed)
            {
                case NORMAL:
                    arrowNormal.SetActive(false);
                    arrowSlow.SetActive(true);
                    speed = SLOW;
                    break;
                case FAST:
                    arrowFast.SetActive(false);
                    arrowNormal.SetActive(true);
                    speed = NORMAL;
                    break;
            }
        if (Input.GetKeyDown(KeyCode.UpArrow))
            switch (speed)
            {
                case SLOW:
                    arrowSlow.SetActive(false);
                    arrowNormal.SetActive(true);
                    speed = NORMAL;
                    break;
                case NORMAL:
                    arrowNormal.SetActive(false);
                    arrowFast.SetActive(true);
                    speed = FAST;
                    break;
            }
    }

    // Checks if enough time has passed since last spawn.
    // If it is the case, calls the spawn method
    private void HandleSpawn()
    {
        // Debug.Log(distSinceLastSpawn);
        float dist = Time.deltaTime * speed / SLOW;
        distSinceLastSpawn += dist;
        distance += dist;
        if (distSinceLastSpawn > distBetweenSpawns)
        {
            SpawnObstacle();
            distSinceLastSpawn -= distBetweenSpawns;
        }
    }

    private void SpawnObstacle()
    {
        // The column on which the obstacle will spawn.
        int col = Random.Range(-1, 2); // -1, 0 or 1
        // The type of obstacle (to choose from the list of obstacle prefabs).
        int obstacleId = Random.Range(0, obstacles.Length);
        // Creates the element.
        GameObject obstacle = Instantiate(obstacles[obstacleId]);

        // Adds the link back to itself so that the obstacle can get the speed of the game.
        ObstacleScript behavior = obstacle.GetComponent<ObstacleScript>();
        behavior.gameBehavior = this;

        // Positions the obstacle at the right place.
        Vector3 obstaclePos = new Vector3(col * 3.75f, 5f, 10f);
        obstacle.transform.position = obstaclePos;
    }

    public void SpawnBackground(float y)
    {
        GameObject newBg = Instantiate(backgroundPrefab);
        newBg.transform.SetParent(backgroundContainer.transform, false);
        Vector3 pos = new Vector3(0, y / 62.5f, 4050 / 62.5f);
        newBg.transform.position = pos;
        Debug.Log(newBg.transform.position.z);
        // newBg.transform.scale = scale;
        MovingBackgroundScript behavior = newBg.GetComponent<MovingBackgroundScript>();
        behavior.game = gameObject;
    }
}
