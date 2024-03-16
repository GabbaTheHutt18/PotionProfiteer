using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManagerScript : MonoBehaviour
{
    public static MainManagerScript Instance;
    public Dictionary<string, int> ResourceInventory = new Dictionary<string, int> {
        ["firePlant"] = 0,
        ["herbPlant"] = 0,
        ["icePlant"] = 0,
        ["cavePlant"] = 0,
        ["fireSeeds"] = 0,
        ["herbSeeds"] = 0,
        ["iceSeeds"] = 0,
        ["caveSeeds"] = 0,
        ["fireLiquid"] = 0,
        ["herbLiquid"] = 0,
        ["iceLiquid"] = 0,
        ["caveLiquid"] = 0,
        ["fireMineral"] = 0,
        ["herbMineral"] = 0,
        ["iceMineral"] = 0,
        ["caveMineral"] = 0,
        ["fireAnimal"] = 0,
        ["herbAnimal"] = 0,
        ["iceAnimal"] = 0,
        ["caveAnimal"] = 0,
    };

    public bool explored = false; 

    public List<Potion> Potions = new List<Potion>();
    public List<Quest> Quests = new List<Quest>();
    public int Coin = 0; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);



        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


    }

    void Start()
    {
        ResourceInventory["fireSeeds"] = 20;
        ResourceInventory["herbSeeds"] = 20;
        ResourceInventory["iceSeeds"] = 20;
        ResourceInventory["caveSeeds"] = 20;
        ResourceInventory["firePlant"] = 5;
        ResourceInventory["herbPlant"] = 5;
        ResourceInventory["icePlant"] = 5;
        ResourceInventory["cavePlant"] = 5;
        Potions.Add(new Potion());
        Potions.Add(new Potion());
        Potions.Add(new Potion());
        Potions[0].PotionStats = new Vector2(2, 2);
        Potions[1].PotionStats = new Vector2(4, 4);
        Potions[2].PotionStats= new Vector2(-3, 4);
        
        Quests.Add(new Quest());
        Quests.Add(new Quest());
        Quests.Add(new Quest());
        for (int i = 0; i < 4; i++)
        {
            Quests.Add(new Quest());
            Quests[i].QuestID = i;
            Quests[i].QuestTitle = $"Quest Number {i}";
            Quests[i].QuestDescription = $"Quest Description {i}";
            Quests[i].QuestRequirement = $"Quest Needs {i}";
            Quests[i].QuestReward = $"Quest Needs {i}";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoBackToShop()
    {
        SceneManager.LoadScene(0);
    }
}

public class Potion
{
    public Vector2 PotionStats;
    public Sprite PotionSprite;
}

public class Quest
{
    public string QuestTitle;
    public string QuestDescription;
    public string QuestRequirement;
    public Dictionary<string, int> QuestRequirements;
    public string QuestReward;
    public int QuestID;
    public bool QuestCompleted; 
}