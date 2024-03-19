using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDot : MonoBehaviour
{
    public float radius;
    GameManager gameManager;
    private void Start() {
        gameManager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
    }
    private void OnMouseDown() {
        int x; int y;
        if(transform.parent.tag=="Pawn"){
            x = (int)(transform.parent.GetComponent<Pawn>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<Pawn>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<Pawn>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
        }
        if(transform.parent.tag=="Horse"){
            x = (int)(transform.parent.GetComponent<Horse>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<Horse>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<Horse>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
        }
        if(transform.parent.tag=="ele"){
            x = (int)(transform.parent.GetComponent<ele>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<ele>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<ele>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
        }
        if(transform.parent.tag=="Veh"){
            x = (int)(transform.parent.GetComponent<Car>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<Car>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<Car>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
        }
        if(transform.parent.tag=="King"){
            x = (int)(transform.parent.GetComponent<King>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<King>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<King>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
            
        }
        if(transform.parent.tag=="Gun"){
            x = (int)(transform.parent.GetComponent<Gun>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<Gun>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<Gun>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
