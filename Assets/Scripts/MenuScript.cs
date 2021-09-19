using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayButton(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void CreditButton()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void BackButton(GameObject from)
    {
        from.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
