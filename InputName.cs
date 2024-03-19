using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InputName : MonoBehaviour
{
    [SerializeField]TMP_InputField field;
    [SerializeField]GameManager gameManager;

    public void InName(int i){
        if(String.IsNullOrEmpty(field.text)==false){
            gameManager.namChange(i,field.text);
        }
        else{
            gameManager.namChange(i,field.placeholder.gameObject.GetComponent<TextMeshProUGUI>().text);
        }
        
    }
    
}
