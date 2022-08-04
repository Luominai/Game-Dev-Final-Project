using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public string nextlevel;
    public string shop;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
