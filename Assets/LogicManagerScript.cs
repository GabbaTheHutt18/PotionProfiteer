using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LogicManagerScript : MonoBehaviour
{
    public List<Vector2> Potions = new List<Vector2>();
    public GameObject NPC;
    NPC_Script NPC_Script;
    bool WantToBarter = true;
    public int Price = 0;
    public int Coin = 0;
    public Vector2 SelectedPotion;
    public TMP_Text Offer;
    public TMP_Text Dialog;
    public TMP_Text CoinText;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject _npc = Instantiate(NPC);
        NPC_Script = _npc.GetComponent<NPC_Script>();
        Potions.Add(new Vector2(2, 2));
        Potions.Add(new Vector2(4, 4));
        Potions.Add(new Vector2(-3, 4));
        CoinText.text = "Coin: " + Coin;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPrice()
    {
        Price = (int)(Mathf.Abs(SelectedPotion.x)+ Mathf.Abs(SelectedPotion.y));
        if (NPC_Script.hatedPotion == SelectedPotion)
        {
            Price = (int)(Price * 0.5);
            
            Dialog.text = "Ew";
            
        }
        else if (NPC_Script.favouritePotion == SelectedPotion)
        {
            Price *= 2;
            Dialog.text = "yum";
        }
        else
        {
            Dialog.text = "sure";
        }
        Offer.text = "Price: " + Price;

    }

    public void Sold() {
        Coin += Price;
        Potions.Remove(SelectedPotion);
        CoinText.text = "Coin: " + Coin;
        Price = 0; 
    }

    public void Reject()
    {
        Debug.Log("Go Back to Shop");
    }

    public void Barter()
    {
        if (WantToBarter)
        {
            int RandomInt = Random.Range(1, 10);
            if (RandomInt % 3 == 0)
            {
                Dialog.text = "Sure!";
                Price += Price * (Random.Range(1, 6));
            }
            else if (RandomInt == 7)
            {
                Dialog.text = "Ew no I don't want to pay for it anymore";
                Price = 0;
                WantToBarter = false; 
            }
            else
            {
                Dialog.text = "No, I only want to pay this please :)";
            }
        }
        else
        {
            Dialog.text = "No I don't want anything anymore :/";
        }

        Offer.text = "Price: " + Price;

    }
}
