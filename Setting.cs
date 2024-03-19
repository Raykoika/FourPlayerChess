using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public static class Setting 
{
    public static int OutlineBorder = 8;
    public static int InLineBorder = 4;
    public static float cellSize = 2.15f; 
    public static float radius = 0.4f;
    public static bool OutLineCheck(float x,float y){
        if((Mathf.Abs(x)>InLineBorder&&Mathf.Abs(y)>InLineBorder)||(Mathf.Abs(x)>OutlineBorder||Mathf.Abs(y)>OutlineBorder)){
            return true;
        }
        /*else if(Physics2D.OverlapCapsule(new Vector2(cellSize*x,cellSize*y),Vector2.one*radius,0,0)){

            return true;
        }*/
        else{
            return false;
        }
    }
}
