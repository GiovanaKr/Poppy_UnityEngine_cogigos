using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [HideInInspector]
    public bool active = false;

    void Update()
    {
        if(active){
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = worldPosition;
        }
        if (Input.GetMouseButtonUp(0)){
            active = false;
        }
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            active = true;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0){
            transform.Rotate(new Vector3(0,0,-4), Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0){
            transform.Rotate(new Vector3(0,0,4), Space.Self);
        }
    }
}