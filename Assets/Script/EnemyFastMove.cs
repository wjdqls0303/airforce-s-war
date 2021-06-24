using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFastMove : EnemyMove
{
    private float speed = 7f;

    protected override void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
