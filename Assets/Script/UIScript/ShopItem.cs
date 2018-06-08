using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItem : MonoBehaviour {
    [SerializeField]
    private string ItemName;
    private Text Price;
	// Use this for initialization
	void Start () {
        Price = transform.Find("price").GetComponent<Text>();
        transform.Find("Button").GetComponent<Button>().onClick.AddListener(OnBuyButtonClick);
	}
	
	private void OnBuyButtonClick()
    {
        int money = DataManager.LoadData<int>("candy");
        int price = int.Parse(Price.text);
        if(money - price < 0)
        {
            Debug.Log("钱不够，弹窗提示");
            UIManager.GetInstance().ShowMessageBox(new MessageBoxData("你的糖果数量不足"));
        }
        else
        {
            money -= price;
            int itemnum = DataManager.LoadData<int>(ItemName);
            itemnum += 1;
            DataManager.SaveData("candy", money);
            DataManager.SaveData(ItemName, itemnum);
            UIManager.GetInstance().RefreshUI("SkillPanel");
        }
    }
}
