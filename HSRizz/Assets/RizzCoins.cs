using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RizzCoins : MonoBehaviour
{
    public static int rizzCoins = 0;
    public GameObject coinsObject;
    private TextMeshProUGUI mText;
    // Start is called before the first frame update
    public static void increaseRizz(int add){
        PlayerPrefs.SetInt("RizzCoins", rizzCoins + add);
        rizzCoins += add;
    }

    public static int returnRizz(){
        return rizzCoins;
    }
    
    void Start()
    {
        if(PlayerPrefs.HasKey("RizzCoins")){
            rizzCoins = PlayerPrefs.GetInt("RizzCoins");
        }
        else{
            PlayerPrefs.SetInt("RizzCoins", 0);
            rizzCoins = 0;
        }
        mText = coinsObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = "" + rizzCoins;
    }
}
