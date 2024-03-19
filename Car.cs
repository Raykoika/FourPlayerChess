using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Car : pieces
{
    public GameObject dot;
    GameObject[] Area = new GameObject[100];
    private void Start() {
        gameManager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
        gameManager.mute += MuteDots;
        if(factions!=0){
            gameObject.GetComponent<SpriteRenderer>().color = gameManager.FactiosColors[factions-1];
        }
        ColorCheck();
        FindKing();
    }
    private void OnMouseDown() {
        if(gameManager.Turn==factions){
        gameManager.mute();
        MoveableStepCheck();
        }
    }
    void MoveableStepCheck(){
        Array.Clear(Area,0,Area.Length);
        //////////////////right
        int i = 0;
        int xp = (int)xyPostions.x+1;
        int yp = (int)xyPostions.y;
        while(Setting.OutLineCheck(xp,yp)==false){
            Vector2 pos = new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize); 
            Collider2D collider = Physics2D.OverlapCapsule(pos,Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                if(collider.GetComponent<pieces>().factions==factions){
                    break;
                }
                else if(collider.GetComponent<pieces>().factions!=factions){
                    Area[i]=Instantiate(dot,pos,Quaternion.Euler(0,0,0),transform);
                    Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                    Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                    Area[i].GetComponent<DotMovement>().IsEatable = true;
                    i++;
                    break;
                }
            }
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            //Area[i].transform.parent = this.transform;
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            xp++;
            i++;
        }
        ///////////////////////////up
        xp = (int)xyPostions.x;
        yp = (int)xyPostions.y+1;
        while(Setting.OutLineCheck(xp,yp)==false){
            Vector2 pos = new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize); 
            Collider2D collider = Physics2D.OverlapCapsule(pos,Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                if(collider.GetComponent<pieces>().factions==factions){
                    break;
                }
                else if(collider.GetComponent<pieces>().factions!=factions){
                    Area[i]=Instantiate(dot,pos,Quaternion.Euler(0,0,0),transform);
                    Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                    Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                    Area[i].GetComponent<DotMovement>().IsEatable = true;
                    i++;
                    break;
                }
            }
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            yp++;
            i++;
        }
        ///////////////////////left
        xp = (int)xyPostions.x-1;
        yp = (int)xyPostions.y;
        while(Setting.OutLineCheck(xp,yp)==false){
            Vector2 pos = new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize); 
            Collider2D collider = Physics2D.OverlapCapsule(pos,Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                if(collider.GetComponent<pieces>().factions==factions){
                    break;
                }
                else if(collider.GetComponent<pieces>().factions!=factions){
                    Area[i]=Instantiate(dot,pos,Quaternion.Euler(0,0,0),transform);
                    Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                    Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                    Area[i].GetComponent<DotMovement>().IsEatable = true;
                    i++;
                    break;
                }
            }
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            //Area[i].transform.parent = this.transform;
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            xp--;
            i++;
        }
        ///////////////////////down
        xp = (int)xyPostions.x;
        yp = (int)xyPostions.y-1;
        while(Setting.OutLineCheck(xp,yp)==false){
            Vector2 pos = new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize); 
            Collider2D collider = Physics2D.OverlapCapsule(pos,Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                if(collider.GetComponent<pieces>().factions==factions){
                    break;
                }
                else if(collider.GetComponent<pieces>().factions!=factions){
                    Area[i]=Instantiate(dot,pos,Quaternion.Euler(0,0,0),transform);
                    Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                    Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                    Area[i].GetComponent<DotMovement>().IsEatable = true;
                    i++;
                    break;
                }
            }
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            //Area[i].transform.parent = this.transform;
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            yp--;
            i++;
        }
    }
    public void MuteDots(){
        foreach(GameObject obj in Area){
            if(obj!=null)
                Destroy(obj);
        }
        Array.Clear(Area,0,Area.Length);
    }
    public void MoveChange(int x,int y){
        xyPostions.x = x;
        xyPostions.y = y;
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
        gameManager.mute -= MuteDots;
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
