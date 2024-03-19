using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    public float radius;
    GameManager gameManager;
    [SerializeField][ColorUsage(showAlpha:true)]Color EatColor;
    public bool IsEatable;
    [SerializeField]int factions;
    Color originalColor;
    [SerializeField]LayerMask ChessLayer;
    GameObject EatObject;
    private void Awake() {
        //factions = transform.parent.GetComponent<pieces>().factions;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        gameManager = GameObject.Find("Gamemanager").GetComponent<GameManager>();

    }
    private void OnMouseDown() {
        int x; int y;
        ////////////////eat check
        ///
        if(IsEatable&&EatObject!=null){
            if(EatObject.tag=="King"){
                gameManager.Nowfactions[EatObject.GetComponent<King>().factions-1] = 0;
            }
            Destroy(EatObject);
            EatObject = null;
        }
        //////////////////////////////
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
        if(transform.parent.tag=="Sue"){
            x = (int)(transform.parent.GetComponent<Sue>().xyPostions.x + gameObject.GetComponent<pieces>().xyPostions.x);
            y = (int)(transform.parent.GetComponent<Sue>().xyPostions.y + gameObject.GetComponent<pieces>().xyPostions.y);
            transform.parent.GetComponent<Sue>().MoveChange(x,y);
            gameManager.mute();
            gameManager.Turn++;
        }
    }
    private void OnEnable() {
        factions = transform.parent.GetComponent<pieces>().factions;
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        Collider2D col = Physics2D.OverlapCapsule(transform.position,Vector2.one*0.8f,0,0,ChessLayer);
        if(col!=null&&col.GetComponent<pieces>().factions!=factions){
            //Debug.Log(col.GetComponent<pieces>().factions + " , " + col.name + " , " + factions);
            IsEatable = true;
            gameObject.GetComponent<SpriteRenderer>().color = EatColor;
            EatObject = col.gameObject;
        }
        else if(col!=null&&col.transform==transform.parent){
        }
        else if(col!=null&&col.GetComponent<pieces>().factions==factions){
            Debug.Log("block by : " + col.name);
            gameObject.SetActive(false);
        }
    }
    
}
