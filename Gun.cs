using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : pieces
{
    public GameObject dot;
    GameObject[] Area = new GameObject[80];
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
        //////////////////right
        int i = 0;
        int xp = (int)xyPostions.x+1;
        int yp = (int)xyPostions.y;
        while(Setting.OutLineCheck(xp,yp)==false){
            Collider2D collider = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                ///////////find eatable pieces
                xp++;
                Collider2D col = null;
                while(Setting.OutLineCheck(xp,yp)==false){
                    col = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
                    if(col!=null){
                        break;
                    }else{
                        xp++;
                    }
                }
                if(col!=null){
                    if(col.GetComponent<pieces>().factions!=factions){
                        Vector2 vec = new Vector2(xp,yp)*Setting.cellSize;
                        Area[i]=Instantiate(dot,vec,Quaternion.Euler(0,0,0),transform);
                        Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                        Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                        i++;
                    }
                }
                break;
            }
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            xp++;
            i++;
        }
        ///////////////////////////up
        xp = (int)xyPostions.x;
        yp = (int)xyPostions.y+1;
        while(Setting.OutLineCheck(xp,yp)==false){
            Collider2D collider = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                yp++;
                Collider2D col = null;
                while(Setting.OutLineCheck(xp,yp)==false){
                    col = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
                    if(col!=null){
                        break;
                    }else{
                        yp++;
                    }
                }
                if(col!=null){
                    if(col.GetComponent<pieces>().factions!=factions){
                        Vector2 vec = new Vector2(xp,yp)*Setting.cellSize;
                        Area[i]=Instantiate(dot,vec,Quaternion.Euler(0,0,0),transform);
                        Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                        Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                        i++;
                    }
                }
                break;
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
            Collider2D collider = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                xp--;
                Collider2D col = null;
                while(Setting.OutLineCheck(xp,yp)==false){
                    col = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
                    if(col!=null){
                        break;
                    }else{
                        xp--;
                    }
                }
                if(col!=null){
                    if(col.GetComponent<pieces>().factions!=factions){
                        Vector2 vec = new Vector2(xp,yp)*Setting.cellSize;
                        Area[i]=Instantiate(dot,vec,Quaternion.Euler(0,0,0),transform);
                        Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                        Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                        i++;
                    }
                }
                break;
            }
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            
            xp--;
            i++;
        }
        ///////////////////////down
        xp = (int)xyPostions.x;
        yp = (int)xyPostions.y-1;
        while(Setting.OutLineCheck(xp,yp)==false){
            Collider2D collider = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
            if(collider!=null){
                yp--;
                Collider2D col = null;
                while(Setting.OutLineCheck(xp,yp)==false){
                    col = Physics2D.OverlapCapsule(new Vector2((xp)*Setting.cellSize,(yp)*Setting.cellSize),Vector2.one*Setting.radius,CapsuleDirection2D.Vertical,0);
                    if(col!=null){
                        break;
                    }else{
                        yp--;
                    }
                }
                if(col!=null){
                    if(col.GetComponent<pieces>().factions!=factions){
                        Vector2 vec = new Vector2(xp,yp)*Setting.cellSize;
                        Area[i]=Instantiate(dot,vec,Quaternion.Euler(0,0,0),transform);
                        Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
                        Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
                        i++;
                    }
                }
                break;
            }
            
            Area[i]=Instantiate(dot,transform.position,Quaternion.Euler(0,0,0),transform);
            Area[i].GetComponent<pieces>().xyPostions.x = xp - xyPostions.x;
            Area[i].GetComponent<pieces>().xyPostions.y = yp - xyPostions.y;
            yp--;
            i++;
        }
    }
    public void MuteDots(){
        for(int i=0;i<Area.Length;i++){
            Destroy(Area[i]);
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
