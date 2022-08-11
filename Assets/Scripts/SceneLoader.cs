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
    public string howtoplay;
    private Canvas _scene;
    private GameObject _game;
    private Canvas _menu;
    private GameObject _back;
    private GameObject _coins;
    private GameObject _background;
    public GameObject _settings;
    // Start is called before the first frame update
    void Start()
    {
        _scene = GameObject.Find("Canvas").GetComponent<Canvas>();
        _back = _scene.transform.Find("PauseMenu").gameObject;
        _scene.enabled = true;
        _back.SetActive(false);
        _coins = _scene.transform.Find("Coins").gameObject;
        _coins.SetActive(true);
        _game = GameObject.Find("Game");
        _game.SetActive(true);
        _menu = GameObject.Find("Menu").GetComponent<Canvas>();
        _background = GameObject.Find("Background").transform.GetChild(0).gameObject;
        _settings = GameObject.Find("Canvas").transform.Find("SettingsPage").gameObject;
        print(_settings);

        _settings.SetActive(false);
      
        
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
    public void Howtoplay()
    {
        SceneManager.LoadScene(howtoplay);
    }
    public void ScenePause()
    {
     
        _coins.SetActive(false);
        _back.SetActive(true);
        _game.SetActive(false);
        _background.SetActive(false);
        _settings.SetActive(false);
        
    }
    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }
    public void Back()
    {
        print("Back clicked");
        _coins.SetActive(true);
        _back.SetActive(false);
        _game.SetActive(true);
        _background.SetActive(true);
        _settings.SetActive(false);
    }
    public void Settings()
    {
        _menu.enabled = false;
        _coins.SetActive(false);
        _back.SetActive(false);
        _game.SetActive(false);
        _background.SetActive(false);
        _settings.SetActive(true);


    }

}
