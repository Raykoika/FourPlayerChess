using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]Camera cam;
    [SerializeField]float MaxSize;
    [SerializeField]float Minaize;
    [SerializeField]float CurrentSize;
    [SerializeField]float ChangeSpeed;
    [SerializeField]Vector2 MaxPosition;
    Vector3 Screen = new Vector3(9/25,16/25,0);
    Vector3 PreMou;
    Vector3 CurMou;
    Vector3 DleMou;
    void Start()
    {
        PreMou = cam.ScreenToWorldPoint(Input.mousePosition);
        CurMou = cam.ScreenToWorldPoint(Input.mousePosition);
        CurrentSize = MaxSize;
        Screen = new Vector3(3.5f,2,1);
        cam = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        CurMou = CurMou = cam.ScreenToWorldPoint(Input.mousePosition);
        DleMou = (CurMou - PreMou);
        //Debug.Log(BroderCheck());
        cam.orthographicSize = CurrentSize;
        if(Input.mouseScrollDelta.y<0){
            CurrentSize = Mathf.Lerp(CurrentSize,MaxSize,ChangeSpeed*Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position,Vector3.forward*-10,ChangeSpeed*Time.deltaTime);
        }
        if(Input.mouseScrollDelta.y>0){
            CurrentSize = Mathf.Lerp(CurrentSize,Minaize,ChangeSpeed*Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position,cam.ScreenToWorldPoint(Input.mousePosition),ChangeSpeed*Time.deltaTime);
        }
        if(Input.GetMouseButton(2)){
            transform.Translate(-DleMou);
        }
        PreMou = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero,Screen*CurrentSize);
    }
    bool BroderCheck(){
        if((transform.position.x<0)&&Mathf.Abs(transform.position.x-Screen.x*CurrentSize)>Setting.cellSize*20){
            return true;
        }else if((transform.position.x>0)&&Mathf.Abs(transform.position.x+Screen.x*CurrentSize)>Setting.cellSize*20){
            return true;
        }
        else if((transform.position.y<0)&&Mathf.Abs(transform.position.y-Screen.y*CurrentSize)>Setting.cellSize*20){
            return true;
        }
        else if((transform.position.y>0)&&Mathf.Abs(transform.position.y+Screen.y*CurrentSize)>Setting.cellSize*20){
            return true;
        }
        else{
            return false;
        }
        
    }
}
