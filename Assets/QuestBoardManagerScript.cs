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
            newQuest.transform.GetChild(0).GetComponent<TextMeshPro>().text = QuestTitle.text;
     

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
