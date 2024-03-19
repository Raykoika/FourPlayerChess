using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class pieces : MonoBehaviour
{
    public int factions;
    public Vector2 xyPostions;
    public GameManager gameManager;
    private void Start() {
        
        /*if(factions!=0){
            gameObject.GetComponent<SpriteRenderer>().color = gameManager.FactiosColors[factions-1];
        }*/
    }
    private void Update() {
        transform.localPosition = new Vector3(Setting.cellSize*xyPostions.x,Setting.cellSize*xyPostions.y);
    }
    protected int GetFaction(GameObject obj){
        return obj.GetComponent<pieces>().factions;

        {/*if(obj.tag=="Pawn"){
            return obj.GetComponent<Pawn>().factions;
        }
        else if(obj.tag=="Horse"){
            return obj.GetComponent<Horse>().factions;
        }
        else if(obj.tag=="ele"){
            return obj.GetComponent<ele>().factions;
        }
        else if(obj.tag=="Veh"){
            return obj.GetComponent<Car>().factions;
        }
        else if(obj.tag=="King"){
            return obj.GetComponent<King>().factions;
        }
        else if(obj.tag=="Gun"){
            return obj.GetComponent<Gun>().factions;
        }
        else{
            return 0;
        }*/
        /////  PLEASE DONT WRITE THIS AGAIN
        /////  ONLY FOR BACKUP
        }
    }

}
