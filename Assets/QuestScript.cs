using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{
    public Quest QuestData;
    public TMP_Text QuestTitle;
    public TMP_Text QuestDescription;
    public TMP_Text QuestRequirements;
    public TMP_Text QuestReward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void QuestSelected()
    {
        QuestTitle.text = QuestData.QuestTitle;
        QuestDescription.text = QuestData.QuestDescription;
        QuestRequirements.text = QuestData.QuestRequirement;
        QuestReward.text = QuestData.QuestReward;
    }


}
