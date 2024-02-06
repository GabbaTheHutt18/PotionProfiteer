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

    // Start is called before the first frame update
    void Start()
    {
        hatedPotion = new Vector2(Random.Range(-20, 21), Random.Range(-20, 21));
        favouritePotion = new Vector2(Random.Range(-20, 21), Random.Range(-20, 21));
        Red = (float) Random.Range(0, 11)/10;
        Green = (float)Random.Range(0, 11)/10;
        Blue = (float)Random.Range(0, 11) / 10;
        SpriteRender.color = new Color((Red), Green, Blue,1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
