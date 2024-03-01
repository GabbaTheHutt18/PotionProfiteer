using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class NPC_Script : MonoBehaviour
{
    public Vector2 hatedPotion;
    public Vector2 favouritePotion;
    public SpriteRenderer SpriteRender;
    public float Red;
    public float Green;
    public float Blue;
    public List<List<string>> Dialogue = new List<List<string>> { new List<string> { "Sure", "Ew no I don't want to pay for it anymore", "No, I only want to pay this please :)", "Give me something I want to buy!", "No I don't want anything anymore :/", "Sure", "Wow, my Fav!", "Ew..."},
    new List<string> { "Yeah I'll pay that!", "Oh no thank you, I don't want to pay for this", "I'll only pay this please :)", "What did you want me to buy?", "I've changed my mind, I don't want to buy anything now :/", "Mmm its Ok", "Yay!", "Oh I hate this"},
    new List<string> { "Yes please!", "Ew not for that price", "Nah I'm not paying anymore than this :)", "Give me something to buy", "Nah I'm good, I'm not buying anything now... :/", "It ok", "You made my favourite!", "This is not great..."}};
    public List<string> SelectedDialogue = new List<string>(); 

    // Start is called before the first frame update
    void Start()
    {
        hatedPotion = new Vector2(Random.Range(-20, 21), Random.Range(-20, 21));
        favouritePotion = new Vector2(Random.Range(-20, 21), Random.Range(-20, 21));
        Red = (float) Random.Range(0, 11)/10;
        Green = (float)Random.Range(0, 11)/10;
        Blue = (float)Random.Range(0, 11) / 10;
        SpriteRender.color = new Color((Red), Green, Blue,1);
        int DialogueOption = Random.Range(0, Dialogue.Count);
        SelectedDialogue = new List<string>(Dialogue[DialogueOption]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
