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
        rizzCoins += add;
    }

    public static int returnRizz(){
        return rizzCoins;
    }
    
    void Start()
    {
        mText = coinsObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = "" + rizzCoins;
    }
}
