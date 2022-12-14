using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update
    private CircleCollider2D _circle;
    private TextMeshProUGUI _coins;
    private bool coincollected;
    
    private Collect instance;

    public AudioSource audiosource;
    
    void Start()
    {
        _circle = GetComponent<CircleCollider2D>(); // gets collider
        _coins = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>(); // gets the text from the Coin Number child of the canvas
        coincollected = false; // coin isnt collected when game starts
        if (instance == null )
        {
            instance = this;
        }

        _coins.text = "" + LevelData.coinCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        Cointext();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) // if you compare the tag coins
        {
            Destroy(other.gameObject); // destroys it
            coincollected = true; // coin collected
            LevelData.coinCount++; // coin count increases

            audiosource.Play();
            instance.Cointext();

        }
    }
    private void Cointext()
    {
        if(coincollected == true)
        {
            _coins.text = "" + LevelData.coinCount;
            
        }
    }

}
