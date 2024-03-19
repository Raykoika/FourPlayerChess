using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : pieces
{
    [SerializeField]GameObject dot;
    [SerializeField]GameObject[] dots;
    [SerializeField]GameObject[] Arrow;
    bool CorssedLine;
    private void Start() {
        foreach(GameObject obj in Arrow){
            obj.SetActive(false);
        }
        gameManager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
        CorssedLine=false;
        gameManager.mute += MuteDot;
        ColorCheck();
        FindKing();
    }
    private void OnMouseDown() {
        if(gameManager.Turn==factions){
            gameManager.mute();
            FindWalkablePath(); 
        }
    }
    void FindWalkablePath(){
        if(CorssedLine==false){    
            if(factions==1&&xyPostions.y>0){
                CorssedLine = true;
            }
            if(factions==2&&xyPostions.x<0){
                CorssedLine = true;
            }
            if(factions==3&&xyPostions.y<0){
                CorssedLine = true;
            }
            if(factions==4&&xyPostions.x>0){
                CorssedLine = true;
            }
        }
        if(CorssedLine){
            foreach(GameObject obj in Arrow){
                obj.SetActive(false);
            }
        }
        if(CorssedLine==false){
            if(Setting.OutLineCheck(xyPostions.x+dots[factions-1].GetComponent<pieces>().xyPostions.x,xyPostions.y+dots[factions-1].GetComponent<pieces>().xyPostions.y)==false)
                dots[factions-1].SetActive(true);
        }
        else{
            for(int i =0;i<dots.Length;i++){
            if(Setting.OutLineCheck(xyPostions.x+dots[i].GetComponent<pieces>().xyPostions.x,xyPostions.y+dots[i].GetComponent<pieces>().xyPostions.y)==false)
                dots[i].SetActive(true);
        }
        }
        int x;
        x = (int)xyPostions.x + 1;
    }
    public void MoveChange(int x,int y){
        xyPostions.x = x;
        xyPostions.y = y;
    }
    void MuteDot(){
        for(int i =0;i<dots.Length;i++){
            dots[i].SetActive(false);
        }
    }
    void ColorCheck(){
        if(factions!=0){
            SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
            if(spr!=null){
                spr.color = gameManager.FactiosColors[factions-1];
                foreach(GameObject dot in Arrow){
                    dot.GetComponent<SpriteRenderer>().color = gameManager.FactiosColors[factions-1];
                }
            }
            Arrow[factions-1].SetActive(true);
        }
    }
    private void KingDead(){
        gameObject.SetActive(false);
    }
    private void OnDestroy() {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("King");
        foreach(GameObject o in obj){
            if(o.GetComponent<King>().factions==factions){
                o.GetComponent<King>().kingDead-=KingDead;
            }
        }
        gameManager.mute -= MuteDot;
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
