using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematique : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public string nextScene;


    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);

    }
}
