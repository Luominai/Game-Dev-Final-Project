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
    private Canvas _canvas;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.Find("Pause").GetComponent<Canvas>();
        _canvas.enabled = false;
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
        _canvas.enabled = true;
    }
    public void Settings()
    {
        SceneManager.LoadScene(settings);
    }
    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }

}
