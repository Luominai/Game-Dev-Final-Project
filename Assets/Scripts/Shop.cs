using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _catcost;
    public static bool catclicked;
   

    void Start()
    {
        _catcost = GameObject.Find("Canvas").transform.Find("cat shop").GetComponent<TextMeshProUGUI>();
        catclicked = false;  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void catCost()
    {
        if(catclicked == true)
        {
            _catcost.text = "SOLD";
            LevelData.coinCount -= 50;

        }
        else
        {
            catclicked = false;
            _catcost.text = "50";

        }
    }

}
