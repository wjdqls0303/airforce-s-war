using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    protected float speed = 50f;
    protected Gamemanager gamemanager = null;
    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(transform.position.y > gamemanager.MaxPosition.y)
        {
            Destroy(gameObject);
        }
    }
}
