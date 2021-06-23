using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenEvent : MonoBehaviour
{
    GameObject P;
    ButtenMove buttenmove;
    void Start()
    {
        P = GameObject.Find("Player");
        buttenmove = P.GetComponent<ButtenMove>();
    }
    public void LeftBtnDown()
    {
        buttenmove.LeftMove = true;
    }
    public void LeftBtnUp()
    {
        buttenmove.LeftMove = false;
    }
    public void RightBtnDown()
    {
        buttenmove.RightMove = true;
    }
    public void RightBtnUp()
    {
        buttenmove.RightMove = false;
    }
}
