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
        public bool IsPurchased = false;
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
            buyBtn = g.transform.GetChild(0).GetComponent<Button>();
            buyBtn.interactable = !ShopItemsList[i].IsPurchased;
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(ItemTemplate);
    }

    void OnShopItemBtnClicked(int itemIndex){
        int amt = ShopItemsList[itemIndex].Price;
        if(RizzCoins.returnRizz() >= amt){
            RizzCoins.increaseRizz(-amt);
            ShopItemsList[itemIndex].IsPurchased = true;
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(0).GetComponent<Button>();
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Purchased";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
