using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem{
        public Sprite Image;
        public int Price;

        public int increaseAmt = 10;

        public string details;
    }

    [SerializeField] List<ShopItem> ShopItemsList;
    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;
    // Start is called before the first frame update
    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        int len = ShopItemsList.Count;
        for(int i = 0; i < len; i++){
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(2).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + ShopItemsList[i].Price;
            g.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].details;
            buyBtn = g.transform.GetChild(0).GetComponent<Button>();
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(ItemTemplate);
    }

    void OnShopItemBtnClicked(int itemIndex){
        int amt = ShopItemsList[itemIndex].Price;
        if(RizzCoins.returnRizz() >= amt){
            RizzCoins.increaseRizz(-amt);
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(0).GetComponent<Button>();
            if(itemIndex == 0){
                PlayerPrefs.SetInt("damage", PlayerPrefs.GetInt("damage") + ShopItemsList[itemIndex].increaseAmt);
            }
            if(itemIndex == 1){
                PlayerPrefs.SetFloat("maxHealth", PlayerPrefs.GetFloat("maxHealth") + ShopItemsList[itemIndex].increaseAmt);
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
