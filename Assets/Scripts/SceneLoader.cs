using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public string nextlevel;
    public string shop;
    public string credits;
    public string settings;
    public string menu;
    private Canvas _pause;
    private Canvas _scene;
    private GameObject _game;
    // Start is called before the first frame update
    void Start()
    {
        _pause = GameObject.Find("Pause").GetComponent<Canvas>();
        _pause.enabled = false;
        _scene = GameObject.Find("Canvas").GetComponent<Canvas>();
        _scene.enabled = true;
        _game = GameObject.Find("Game");
        _game.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelOne()
    {
        SceneManager.LoadScene(nextlevel);
    }
    public void Shop()
    {
        SceneManager.LoadScene(shop);
    }
    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }
    public void ScenePause()
    {
        _pause.enabled = true;
        _scene.enabled = false;
        _game.SetActive(false);
    }

    public void Settings()
    {
        SceneManager.LoadScene(settings);
    }
    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }
    public void Back()
    {
        _scene.enabled = true;
        _pause.enabled = false;
        _game.SetActive(true);
    }

}
