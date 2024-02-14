using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnResources : MonoBehaviour
{
    [SerializeField] GameObject common;
    [SerializeField] GameObject rare;
    [SerializeField] GameObject epic;
    [SerializeField] GameObject legendary;

    [SerializeField] int x_min;
    [SerializeField] int x_max;
    [SerializeField] int y_min;
    [SerializeField] int y_max;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] rarities = { common, rare, epic, legendary };
        int loop = 16;
        int index = 0;

        for (int r = 0; r < 4; r++)
        {
            for (int i = 0; i < loop; i++)
            {
                int x = Random.Range(x_min, x_max);
                int y = Random.Range(y_min, y_max);

                GameObject element = Instantiate(rarities[index], this.gameObject.transform);
                element.transform.position = new Vector3(x, y, -1);
            }
            index++;
            loop = loop / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
