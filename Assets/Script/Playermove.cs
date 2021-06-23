using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;
    [SerializeField]
    private float firelate = 0.3f;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletPosition = null;

    Vector3 moveVelocity = Vector3.zero;
    private Vector2 targetPosition = Vector2.zero;
    private Gamemanager gameManager = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isDamaged = false;
    void Start() 
    {
        gameManager = FindObjectOfType<Gamemanager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if(transform.position.x > gameManager.MinPosition.x)
        {
            moveVelocity = new Vector2(-0.5f, 0);
            transform.position += moveVelocity * 7 * Time.deltaTime;
        }
        if (transform.position.x < gameManager.MaxPosition.x)
        {
            moveVelocity = new Vector2(0.5f, 0);
            transform.position += moveVelocity * 7 * Time.deltaTime;
        }
    }

    private IEnumerator Fire()
    {
        GameObject bullet;
        if(bulletPrefab != null)
        {
            while (true)
            {
                bullet = Instantiate(bulletPrefab, bulletPosition);
                bullet.transform.SetParent(null);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamaged) return;
        isDamaged = true;
        StartCoroutine(Damage());
    }

    private IEnumerator Damage()
    {
        gameManager.Dead();
        for(int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        isDamaged = false;
    }
    public void OnClickLeftmove()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    public void OnClickRightmove()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
