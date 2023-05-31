using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhp : MonoBehaviour {
    public int enemyhp;
    public int currenthp;
    private Animator anim;
    private bool dead;

    private Collider2D col;
    private Collider2D hurtcol;

    private SpriteRenderer spriterend;
    void Start()
    {
        currenthp = enemyhp;
        anim = transform.parent.GetComponent<Animator>();
        col = transform.parent.GetComponent<Collider2D>();
        hurtcol = GetComponent<Collider2D>();
        spriterend= transform.parent.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (currenthp <= 0)
        {
            //Destroy(transform.parent.gameObject);
            dead = true;
            anim.SetBool("dead", dead);
            col.enabled = false;
            hurtcol.enabled = false;
            StartCoroutine("killswitch");
        }
    }

    public void takedamage(int damage)
    {
        currenthp -= damage;
        StartCoroutine("hitconfirm");
    }

    IEnumerator killswitch()
    {
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }

    IEnumerator hitconfirm()
    {
        if (currenthp > 0)
        {
            spriterend.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriterend.enabled = true;
        }
    }
}
