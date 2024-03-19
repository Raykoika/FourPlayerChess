using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnText : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField]TextMeshProUGUI text;
    void Start()
    {
        
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.Turn!=0){
            text.color = gameManager.FactiosColors[gameManager.Turn-1];
            text.text = gameManager.FactionName[gameManager.Turn-1] + "的回合";
        }
        else{
            
        }
    }
}
