using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ele : pieces
{
    [SerializeField]
    GameObject[] dots;

    private void Start() {
        gameManager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
        gameManager.mute += dotMute;
        if(factions!=0){
            gameObject.GetComponent<SpriteRenderer>().color = gameManager.FactiosColors[factions-1];
        }
        ColorCheck();
        FindKing();
    }
    private void OnMouseDown() {
        if(gameManager.Turn==factions){
        gameManager.mute();
        dotDisply();
        }
    }
    public void dotMute(){
        for(int i =0;i<dots.Length;i++){
            dots[i].SetActive(false);
        }
    }
    void dotDisply(){
        for(int i =0;i<dots.Length;i++){
            //bolck check
            Vector2 mid = (dots[i].transform.position + transform.position)/2;
            Collider2D col = Physics2D.OverlapCapsule(mid,Vector2.one*0.8f,0,0);
            if(col==null){
                if(Setting.OutLineCheck(xyPostions.x+dots[i].GetComponent<pieces>().xyPostions.x,xyPostions.y+dots[i].GetComponent<pieces>().xyPostions.y)==false)
                    dots[i].SetActive(true);
            }
        }
    }
    public void MoveChange(int x,int y){
        //Map.Map[(int)xyPostions.x][(int)xyPostions.y]=null;
        xyPostions.x = x;
        xyPostions.y = y;
        //Map.Map[x][y] = this.gameObject;
    }
    void ColorCheck(){
        if(factions!=0){
            SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
            if(spr!=null){
                spr.color = gameManager.FactiosColors[factions-1];
            }
        }
    }
    private void OnDestroy() {
        gameManager.mute -= dotMute;
        GameObject[] obj = GameObject.FindGameObjectsWithTag("King");
        foreach(GameObject o in obj){
            if(o.GetComponent<King>().factions==factions){
                o.GetComponent<King>().kingDead-=KingDead;
            }
        }
    }
    private void KingDead(){
        gameObject.SetActive(false);
    }
    void FindKing(){
        GameObject[] obj = GameObject.FindGameObjectsWithTag("King");
        foreach(GameObject o in obj){
            if(o.GetComponent<King>().factions==factions){
                o.GetComponent<King>().kingDead+=KingDead;
            }
        }
    }
}
