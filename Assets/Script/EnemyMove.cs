using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int score = 1;
    [SerializeField]
    private int hp = 5;
    [SerializeField]
    protected float speed = 3f;

    protected Gamemanager gameManager = null;
    private Animator animator = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;

    private bool isDamaged = false;
    private bool isDead = false;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) return;
        Move();
        CheckLimit();
    }
    protected virtual void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void CheckLimit()
    {
        if (transform.position.y < Gamemanager.Instance.MinPosition.y)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < Gamemanager.Instance.MinPosition.x - 2f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > Gamemanager.Instance.MaxPosition.x + 2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp > 1)
            {
                if (isDamaged) return;
                isDamaged = true;
                StartCoroutine(Damaged());
                return;
            }
            if (isDead) return;
            isDead = true;
            Gamemanager.Instance.AddScore(score);
            StartCoroutine(Dead());
        }
    }
    public IEnumerator Damaged()
    {
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        isDamaged = false;
    }
    public IEnumerator Dead()
    {
        col.enabled = false;
        animator.Play("enemy_airplain_destroy_1");
        spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
