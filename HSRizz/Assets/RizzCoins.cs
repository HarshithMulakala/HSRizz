using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RizzCoins : MonoBehaviour
{
    public static int rizzCoins = 0;
    // Start is called before the first frame update
    public static void increaseRizz(int add){
        rizzCoins += add;
    }

    public static int returnRizz(){
        return rizzCoins;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
