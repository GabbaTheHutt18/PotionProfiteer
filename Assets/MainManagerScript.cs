using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManagerScript Instance;

    public int firePlant = 0;
    public int herbPlant = 0;
    public int icePlant = 0;
    public int cavePlant = 0;

    public int fireSeeds;
    public int herbSeeds;
    public int iceSeeds;
    public int caveSeeds;

    public int fireLiquid = 0;
    public int herbLiquid = 0;
    public int iceLiquid = 0;
    public int caveLiquid = 0;

    public int fireMineral= 0;
    public int herbMineral = 0;
    public int iceMineral = 0;
    public int caveMineral = 0;

    public int fireAnimal = 0;
    public int herbAnimal = 0;
    public int iceAnimal = 0;
    public int caveAnimal = 0;

    public bool explored = false; 

    public List<Vector2> Potions;


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
        fireSeeds = 20;
        iceSeeds = 20;
        herbSeeds = 20;
        caveSeeds = 20;
        firePlant = 5;
        icePlant = 5;
        cavePlant = 5;
        herbPlant = 5;
        Potions.Add(new Vector2(2, 2));
        Potions.Add(new Vector2(4, 4));
        Potions.Add(new Vector2(-3, 4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
