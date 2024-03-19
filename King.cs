using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : pieces
{
    [SerializeField]
    GameObject[] dots;
    public delegate void KingDead();
    public KingDead kingDead;

    private void Start() {
        gameManager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
        gameManager.mute += dotMute;
        if(factions!=0){
            gameObject.GetComponent<SpriteRenderer>().color = gameManager.FactiosColors[factions-1];
        }
        ColorCheck();
    }
    
    private void OnMouseDown() {
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("C");
            Destroy(gameObject);
        }
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
            Vector2 vec = new Vector2(xyPostions.x+dots[i].GetComponent<pieces>().xyPostions.x,xyPostions.y+dots[i].GetComponent<pieces>().xyPostions.y);
            if(Setting.OutLineCheck(vec.x,vec.y)==false&&Nsquare(vec.x,vec.y)==false){
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
        gameManager.Nowfactions[factions-1] = 0;
        if(kingDead!=null)
            kingDead();
        kingDead = null;
        gameManager.mute -= dotMute;
    }
    bool Nsquare(float x,float y){
        if(factions==1){
            if(Mathf.Abs(x)>1||y>-6){
                return true;
            }
            else{
                return false;
            }
        }
        else if(factions==2){
            if(Mathf.Abs(y)>1||x<6){
                return true;
            }
            else{
                return false;
            }
        }
        else if(factions==3){
            if(Mathf.Abs(x)>1||y<6){
                return true;
            }
            else{
                return false;
            }
        }
        else{
            if(Mathf.Abs(y)>1||x>-6){
                return true;
            }
            else{
                return false;
            }
        }
    }
}
