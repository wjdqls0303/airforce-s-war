using UnityEngine;

public class ButtenMove : MonoBehaviour
{
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float speed = 10;

    void Update()
    {
        if(LeftMove)
        {
            moveVelocity = new Vector3(-0.5f, 0, 0);
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        if(RightMove)
        {
            moveVelocity = new Vector3(0.5f, 0, 0);
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
    }
}
