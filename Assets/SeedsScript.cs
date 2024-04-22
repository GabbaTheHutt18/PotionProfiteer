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
    public int Planter;
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
                    herbLogicManager.mainManagerScript.ResourceInventory["firePlant"] += 3;
                    herbLogicManager.mainManagerScript.PlantedSeeds.Remove(Planter);
                    break;
                case 1:
                    herbLogicManager.mainManagerScript.ResourceInventory["herbPlant"] += 3;
                    herbLogicManager.mainManagerScript.PlantedSeeds.Remove(Planter);
                    break;
                case 2:
                    herbLogicManager.mainManagerScript.ResourceInventory["icePlant"] += 3;
                    herbLogicManager.mainManagerScript.PlantedSeeds.Remove(Planter);
                    break;
                case 3:
                    herbLogicManager.mainManagerScript.ResourceInventory["cavePlant"] += 3;
                    herbLogicManager.mainManagerScript.PlantedSeeds.Remove(Planter);
                    break;
                default:
                    break;
            }
        }
        Destroy(gameObject);
    }
}
