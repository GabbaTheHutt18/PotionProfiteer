using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HerbLogicManager : MonoBehaviour
{
  
    public List<GameObject> Planters = new List<GameObject>();
    public GameObject PlanterBox;
    public Canvas canvas;
    public Button Seeds;
    public bool explored;
    public Sprite SeedSprite;
    public Sprite PlantSprite;
    public MainManagerScript mainManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        mainManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();

        explored = false;
        
        int xPosition = 700;
    
        for (int i = 0; i < 3; i++)
        {
            
            GameObject planter = Instantiate(PlanterBox, canvas.transform);
            planter.transform.position = new Vector3 (xPosition, 700, 0);
            Planters.Add(planter);
            xPosition += 400;
        }
    }

    // Update is called once per frame
    void Update()
    {
        explored = mainManagerScript.explored;
    }

    public void FireSeedsButtonPressed()
    { 
        int Planter = GetEmptyPlanter();
        if (Planter != -1 && mainManagerScript.ResourceInventory["fireSeeds"] > 0)
        {
            mainManagerScript.ResourceInventory["fireSeeds"] -= 1;
            Button _seed = Instantiate(Seeds, Planters[Planter].transform.position, Planters[Planter].transform.rotation, Planters[Planter].transform);
            _seed.transform.GetComponent<SeedsScript>().PlantType = 0;
            _seed.transform.GetComponent<SeedsScript>().SeedsSprite = SeedSprite;
            _seed.transform.GetComponent<SeedsScript>().PlantSprite = PlantSprite;


        }
    }

    public void HerbSeedsButtonPressed()
    {
        int Planter = GetEmptyPlanter();
        if (Planter != -1 && mainManagerScript.ResourceInventory["herbSeeds"] > 0)
        {
            mainManagerScript.ResourceInventory["herbSeeds"] -= 1;
            Button _seed = Instantiate(Seeds, Planters[Planter].transform.position, Planters[Planter].transform.rotation, Planters[Planter].transform);
            _seed.transform.GetComponent<SeedsScript>().PlantType = 1;
            _seed.transform.GetComponent<SeedsScript>().SeedsSprite = SeedSprite;
            _seed.transform.GetComponent<SeedsScript>().PlantSprite = PlantSprite;
           
        }
    }

    public void IceSeedsButtonPressed()
    {
        int Planter = GetEmptyPlanter();
        if (Planter != -1 && mainManagerScript.ResourceInventory["iceSeeds"] > 0)
        {
            mainManagerScript.ResourceInventory["iceSeeds"] -= 1;
            Button _seed = Instantiate(Seeds, Planters[Planter].transform.position, Planters[Planter].transform.rotation, Planters[Planter].transform);
            _seed.transform.GetComponent<SeedsScript>().PlantType = 2;
            _seed.transform.GetComponent<SeedsScript>().SeedsSprite = SeedSprite;
            _seed.transform.GetComponent<SeedsScript>().PlantSprite = PlantSprite;
        }

    }
    public void CaveSeedsButtonPressed() 
    {
        int Planter = GetEmptyPlanter();
        if (Planter != -1 && mainManagerScript.ResourceInventory["caveSeeds"] > 0)
        {
            mainManagerScript.ResourceInventory["caveSeeds"] -= 1;
            Button _seed = Instantiate(Seeds, Planters[Planter].transform.position, Planters[Planter].transform.rotation, Planters[Planter].transform);
            _seed.transform.GetComponent<SeedsScript>().PlantType = 3;
            _seed.transform.GetComponent<SeedsScript>().SeedsSprite = SeedSprite;
            _seed.transform.GetComponent<SeedsScript>().PlantSprite = PlantSprite;

        }
    }

    

    public int GetEmptyPlanter()
    {
        for (int i = 0; i < Planters.Count; i++)
        {
            if (Planters[i].transform.childCount < 1)
            {
                return i;
            }
        }
        return -1;
    }


}
