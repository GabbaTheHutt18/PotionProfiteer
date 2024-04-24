using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManagerScript : MonoBehaviour
{
    public static MainManagerScript Instance;
    public Dictionary<string, int> ResourceInventory = new Dictionary<string, int> {
        ["firePlant"] = 2,
        ["herbPlant"] = 2,
        ["icePlant"] = 2,
        ["cavePlant"] = 2,
        ["fireSeeds"] = 2,
        ["herbSeeds"] = 2,
        ["iceSeeds"] = 2,
        ["caveSeeds"] = 2,
        ["fireLiquid"] = 2,
        ["herbLiquid"] = 2,
        ["iceLiquid"] = 2,
        ["caveLiquid"] = 2,
        ["fireMineral"] = 2,
        ["herbMineral"] = 2,
        ["iceMineral"] = 2,
        ["caveMineral"] = 2,
        ["fireAnimal"] = 2,
        ["herbAnimal"] = 2,
        ["iceAnimal"] = 2,
        ["caveAnimal"] = 2,
    };
    public Dictionary<int, int> PlantedSeeds = new Dictionary<int, int>();

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
        
        Potions.Add(new Potion(new Vector2(2, 2)));
        Potions.Add(new Potion(new Vector2(4, 4)));
        Potions.Add(new Potion(new Vector2(-3, 4)));
        
        Quests.Add(new Quest());
        Quests.Add(new Quest());
        Quests.Add(new Quest());
        for (int i = 0; i < 3; i++)
        {
            Quests[i].QuestID = i;
            Quests[i].QuestTitle = $"Quest Number {i}";
            Quests[i].QuestDescription = $"Quest Description {i}";
            Quests[i].QuestRequirement = $"Quest Needs {i}";
            Quests[i].QuestReward = $"Quest Requirements {i}";
            Quests[i].QuestRequirements.Add("firePlant", 2);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            explored = true;
        }
    }


    public void GoBackToShop()
    {
        SceneManager.LoadScene(1);
    }

   

}

public class Potion
{
    public Vector2 PotionStats;
    public Sprite PotionSprite;
    public Potion(Vector2 potionStats)
    { 
        PotionStats = potionStats;

    }
}

public class Quest
{
    public string QuestTitle;
    public string QuestDescription;
    public string QuestRequirement;
    public Dictionary<string, int> QuestRequirements = new Dictionary<string, int>();
    public List<Potion> xx = new List<Potion> ();
    public string QuestReward;
    public int QuestID;
    public bool QuestCompleted; 
}