using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBrewed : MonoBehaviour
{
    public string potionName = "TestPotion1";
    public bool IspotionBrewed;

    // Start is called before the first frame update
    void Start()
    {
        IspotionBrewed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered"); 

        if (other.gameObject.tag == "Follower")
        {
            Debug.Log(potionName);
            IspotionBrewed = true;
            other.gameObject.GetComponent<FollowPointer>().AddPotion();
        }
    }
}
