using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataTesting : MonoBehaviour
{
    // Start is called before the first frame update
    private static DataTesting data;
    public float masterVolume = 0;
    public float SFXVolume = 0;
    public float musicVolume = 0;
    public bool leftHandMode = false;
    public int coins = 0;
    void Awake()
    {
        if (data != null)
        {
            Destroy(gameObject);
            return;
        }

        data = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        print("Master: " + masterVolume + " | " + "Music: " + musicVolume + " | " + "SFX: " + SFXVolume);
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
