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
    private Button _catbutton;
    private bool catbought = false;
    private bool bowbought = false;
    private Toggle _cattoggle;
    public Toggle _bowtoggle;
    private TextMeshProUGUI _bowcost;
    private Button _bowbutton;


    void Start()
    {
        _catcost = GameObject.Find("Canvas").transform.Find("cat shop").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        catequipped = false;
        _coincount = GameObject.Find("Canvas").transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        _coincount.text = "" + LevelData.coinCount;
        _catbutton = GameObject.Find("Canvas").transform.Find("cat shop").GetComponent<Button>();
        _cattoggle = GameObject.Find("Canvas").transform.Find("cat toggle").GetComponent<Toggle>();
  
        _bowtoggle = GameObject.Find("Canvas").transform.Find("bow toggle").GetComponent<Toggle>();
        _bowcost = GameObject.Find("Canvas").transform.Find("bow shop").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        _bowbutton = GameObject.Find("Canvas").transform.Find("bow shop").GetComponent<Button>();

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

        
        if (bowbought)
        {
            _bowtoggle.enabled = true;
        }
        else
        {
            _bowtoggle.enabled = false;
        }
        
    }
    public void buycat()
    {
        if(LevelData.coinCount >= 100)
        {
            _catcost.text = "SOLD";
            LevelData.coinCount -= 100;
            catbought = true;
            _catbutton.interactable = false;
            _coincount.text = "" + LevelData.coinCount;

        }
    }
    public void buybow()
    {
        if(LevelData.coinCount >=200)
        {
            _bowcost.text = "SOLD";
            LevelData.coinCount -= 200;
            bowbought = true;
            _bowbutton.interactable = false;
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
            Settings.name = "bow_0";
        }
    }
}
