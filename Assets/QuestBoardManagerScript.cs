using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoardManagerScript : MonoBehaviour
{
    public Button Quest;
    public MainManagerScript MainManager;
    public TMP_Text QuestTitle;
    public TMP_Text QuestDescription;
    public TMP_Text QuestRequirements;
    public TMP_Text QuestReward;
    Quest ChosenQuest;
    bool completedQuest;

    // Start is called before the first frame update
    void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        foreach (var item in MainManager.Quests)
        {
            Button newQuest = Instantiate(Quest,this.transform);
            newQuest.GetComponent<QuestScript>().QuestData = item;
            newQuest.GetComponent<QuestScript>().QuestTitle = QuestTitle;
            newQuest.GetComponent<QuestScript>().QuestDescription = QuestDescription;
            newQuest.GetComponent<QuestScript>().QuestRequirements = QuestRequirements;
            newQuest.GetComponent<QuestScript>().QuestReward = QuestReward;
            
            newQuest.transform.GetChild(0).GetComponent<TMP_Text>().text = item.QuestTitle;
     

        }
    }


    public void CompleteQuest()
    {
        if (completedQuest)
        {
            switch (ChosenQuest.QuestTitle)
            {
                case "Quest Number 1":
                    Debug.Log("Completed Quest1");
                    break;
                default:
                    break;
            }
        }

        
    }

    public void SelectedQuest(Quest _questData)
    {
        completedQuest = false;
       int num =  _questData.QuestRequirements.Count;
        foreach (var item in _questData.QuestRequirements)
        {
            //MainManager.ResourceInventory[item.Key]
            foreach (var j in MainManager.ResourceInventory)
            {
                if (item.Key == j.Key)
                {
                    if (item.Value <= j.Value)
                    {
                        Debug.Log("Match");
                        num -= 1;
                    }
                    else
                    {
                        Debug.Log("Not sufficient");
                    }
                }

            }
        }
        ChosenQuest = _questData;
        if (num == 0)
        {
            
            completedQuest = true;
        }

    }
}
