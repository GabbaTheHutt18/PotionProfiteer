using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedsScript : MonoBehaviour
{
    HerbLogicManager herbLogicManager;
    public int PlantType;
    public Image Image;
    public Sprite SeedsSprite;
    public Sprite PlantSprite;
    // Start is called before the first frame update
    void Start()
    {
        herbLogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<HerbLogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (herbLogicManager.explored)
        {
            Image.sprite = PlantSprite;
        }
        else
        {
            Image.sprite = SeedsSprite;
        }
    }

    public void OnClicked()
    { 
        if(herbLogicManager.explored)
        {
            switch (PlantType)
            {
                case 0:
                    herbLogicManager.mainManagerScript.firePlant += 3;
                    break;
                case 1:
                    herbLogicManager.mainManagerScript.herbPlant += 3;
                    break;
                case 2:
                    herbLogicManager.mainManagerScript.icePlant += 3;
                    break;
                case 3:
                    herbLogicManager.mainManagerScript.cavePlant += 3;
                    break;
                default:
                    break;
            }
        }
        Destroy(gameObject);
    }
}
