using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public Dictionary<int, int> PlantedSeeds = new Dictionary<int, int> {
        [0] = -1,
        [1] = -1,
        [2] = -1,
    };

    public bool explored = false;
    public bool BlewUp = false;

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
        Potions.Add(new Potion(new Vector2(2, 3)));
        Potions.Add(new Potion(new Vector2(4, 4)));
        Potions.Add(new Potion(new Vector2(-3, 4)));
        
        Quests.Add(new Quest());
        Quests.Add(new Quest());
        Quests.Add(new Quest());
        Quests[0].QuestID = 0;
        Quests[0].QuestTitle = "Help I want a snack!";

        Quests[0].ResourceRequirements.Add("firePlant", 2);
        Quests[0].QuestRequirement = $"{Quests[0].ResourceRequirements.ElementAt(0).Value} Heat Lily";
        Quests[0].RewardType = 0;
        Quests[0].CoinReward = 3;
        Quests[0].QuestReward = $"Coin: {Quests[0].CoinReward}";

        Quests[1].QuestID = 1;
        Quests[1].QuestTitle = "Help I want to be a snack!";

        Quests[1].PotionRequirements.Add(new Potion(new Vector2(2,3)));
        Quests[1].QuestRequirement = $"Potion: {Quests[1].PotionRequirements[0].PotionStats}";
        Quests[1].RewardType = 1;
        Quests[1].ResourceReward.Add("iceAnimal",1);
        Quests[1].QuestReward = $"{Quests[1].ResourceReward.ElementAt(0).Value} SnowLeaf";

        Quests[2].QuestID = 2;
        Quests[2].QuestTitle = "Quest O'clock xxx";
        Quests[2].PotionRequirements.Add(new Potion(new Vector2(-4, -2)));
        Quests[2].QuestRequirement = $"Potion: {Quests[2].PotionRequirements[0].PotionStats}";
        Quests[2].RewardType = 1;
        Quests[2].ResourceReward.Add("caveSeeds", 5);
        Quests[2].QuestReward = $"{Quests[2].ResourceReward.ElementAt(0).Value} Blush Mush Seed";

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            explored = true;
        }
        if (BlewUp && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("Oop silly, you gassed yourself xx");
            BlewUp = false;
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
    public int ID;
    public Potion(Vector2 potionStats)
    { 
        PotionStats = potionStats;

    }
}

public class Quest
{
    public int QuestID;
    public string QuestTitle;

    public Dictionary<string, int> ResourceRequirements = new Dictionary<string, int>();
    public List<Potion> PotionRequirements = new List<Potion>();
    public string QuestRequirement;

    public int RewardType;
    public Dictionary<string, int> ResourceReward = new Dictionary<string, int> ();
    public int CoinReward;
    public string QuestReward;

    public bool QuestCompleted = false; 
}