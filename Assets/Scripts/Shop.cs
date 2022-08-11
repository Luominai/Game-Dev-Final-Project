using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI _catcost;
    public static bool catequipped;
    public static bool bowequipped;
    private TextMeshProUGUI _coincount;
    private Button _button;
    private bool catbought;
    private bool bowbought;
    public Toggle _cattoggle;
    public Toggle _bowtoggle;
   

    void Start()
    {
        _catcost = GameObject.Find("Canvas").transform.Find("cat shop").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        catequipped = false;
        _coincount = GameObject.Find("Canvas").transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        _coincount.text = "" + LevelData.coinCount;
        _button = GameObject.Find("Canvas").transform.Find("cat shop").GetComponent<Button>();
        catbought = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (catbought)
        {
            _cattoggle.enabled = true;
        } 
        else
        {
            _cattoggle.enabled = false;
        }
        iscatcostume();

        /*
        if (bowbought)
        {
            _bowtoggle.enabled = true;
        }
        else
        {
            _bowtoggle.enabled = false;
        }
        */
    }
    public void buycat()
    {
        if(true)//(LevelData.coinCount >= 100)
        {
            _catcost.text = "SOLD";
            LevelData.coinCount -= 100;
            catbought = true;
            _button.interactable = false;
            _coincount.text = "" + LevelData.coinCount;

        }
    }
    public void iscatcostume()
    {
        if (_cattoggle.isOn)
        {
            bowequipped = false;
            catequipped = true;
            Settings.name = "cat_10";
        }
    }

    public void isdefault()
    {
        if (_cattoggle.isOn)
        {
            bowequipped = false;
            catequipped = false;
            Settings.name = "slime_8";
        }
    }

    public void isbowcostume()
    {
        if (_bowtoggle.isOn)
        {
            catequipped = false;
            bowequipped = true;
            Settings.name = "";
        }
    }
}
