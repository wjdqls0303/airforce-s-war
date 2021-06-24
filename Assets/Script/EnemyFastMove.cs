using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFastMove : EnemyMove
{
    [SerializeField]
    private GameObject EnemyBullet = null;
    [SerializeField]
    private Transform EnemybulletPosition = null;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Fire());
    }
    private IEnumerator Fire()
    {
        GameObject bullet;
        if (EnemyBullet != null)
        {
            while (true)
            {
                bullet = Instantiate(EnemyBullet, EnemybulletPosition);
                bullet.transform.SetParent(null);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
