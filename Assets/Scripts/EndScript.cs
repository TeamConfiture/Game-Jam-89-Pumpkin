using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        int distanceInt = Mathf.FloorToInt(GameBehavior.distance);
        text.text = string.Format("You pushed the pumpkin for\n{0}\nmeters.", distanceInt);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
