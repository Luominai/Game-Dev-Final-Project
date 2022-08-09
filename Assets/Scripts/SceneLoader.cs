using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public string nextlevel;
    public string shop;
    public string credits;
    public string menu;
    private Canvas _scene;
    private GameObject _game;
    private Canvas _menu;
    private GameObject _back;
    // Start is called before the first frame update
    void Start()
    {
        _scene = GameObject.Find("Canvas").GetComponent<Canvas>();
        _scene.enabled = true;
        _game = GameObject.Find("Game");
        _game.SetActive(true);
        _menu = GameObject.Find("Menu").GetComponent<Canvas>();
        
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
        _scene.enabled = false;
        _game.SetActive(false);
        _back.
    }
    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }
    public void Back()
    {
        _scene.enabled = true;
        _game.SetActive(true);
    }
    public void Settings()
    {
        _menu.enabled = false;
     
    }

}
