using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI _catcost;
    public static bool catclicked;
    private TextMeshProUGUI _coincount;
    private Button _button;
    private bool catsold;
   

    void Start()
    {
        _catcost = GameObject.Find("Canvas").transform.Find("cat shop").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        catclicked = false;
        _coincount = GameObject.Find("Canvas").transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        _coincount.text = "" + LevelData.coinCount;
        _button = GameObject.Find("Canvas").transform.Find("cat shop").GetComponent<Button>();
        catsold = false;

    }

    // Update is called once per frame
    void Update()
    {
        catCost();
    
    }
    public void catCost()
    {
        if(catclicked == true &&  LevelData.coinCount >= 100)
        {
            _catcost.text = "SOLD";
            LevelData.coinCount -= 100;
            catsold = true;
            _button.interactable = false;
            _coincount.text = "" + LevelData.coinCount;
            

        }
    }
    public void catclick()
    {
        print("clicked!");
        catclicked = true;
    }


}
