using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    [SerializeField]
    public GameObject[][] Map; 
    

    private void Update() {
        /*string m = ("");
        for(int i =0;i<8;i++){
            for(int j =0;j<8;j++){
            if(Map[i][j].gameObject!=null)
                m+=Map[i][j].gameObject.tag;
            else
                m+="null ";

        }
        m+='\n';
        }
        Debug.Log(m);*/
    }
}
