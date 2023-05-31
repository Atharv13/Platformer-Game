using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
	public Rigidbody2D rb;
	public Animator anim;
	public Transform feet;
	public LayerMask groundLayers;
	private float airtimecounter;
	public gamemanager gm;
	public livesmanager lm;
	public moneymanager mm;
    [SerializeField] private LayerMask ground;
	[SerializeField] private float speed = 3f;
	[SerializeField] private float jumpspeed = 3f;
	private float airtime = 0f;
    public Vector3 tp_offset;
    public GameObject tp_offset_access;
    private tp tp_script;
    private bool ctrlactive;
	private bool isdead;
	private Collider2D playercol;
	public GameObject[] childObjs;
	public float shockforce;
    public bool bgmmusicaccess=false;
    private int track = 0;

    private GameObject current_tp;


    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		lm=FindObjectOfType<livesmanager>();
		mm = FindObjectOfType<moneymanager>();
		playercol= GetComponent<Collider2D>();
        tp_script = tp_offset_access.GetComponent<tp>();
        ctrlactive = true;

	}

	private void Update()
	{
		if (ctrlactive == true)
		{
			moveplayer();
			jump();
		}

        if (Input.GetKeyDown(KeyCode.T) && tp_script.tpwithoffset==true)
        {
            if(current_tp != null)
            {
                Vector3 tp_position = current_tp.GetComponent<tp>().GetDestination().position;
                Vector3 targetpostion = tp_position + tp_offset;
                transform.position = targetpostion;
            }
        }

        else if (Input.GetKeyDown(KeyCode.T) && tp_script.tpwithoffset == null)
        {
            if (current_tp != null)
            {
                transform.position = current_tp.GetComponent<tp>().GetDestination().position;
            }
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Collectable")
		{
			Destroy(collision.gameObject);
            mm.addmoney();
		}

        if (collision.tag == "musicdisc")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemies")
		{
			lm.takelife();
            playerdeath();
		}

        if (collision.gameObject.tag == "rockbottom")
        {
            lm.takelife();
            playerdeath();
        }

        if (collision.gameObject.tag == "Finish")
		{
			Debug.Log("yayyyyyyyyyyy!");
			gm.Victory();
		}

		if (collision.gameObject.tag == "boona")
		{
			mm.takemoney();
            if (mm.moneycounter < 300)
            {
                lm.takelife();
            }
            FindObjectOfType<soundmanager>().Play("boona_laugh");
            playerdeath();
		}

		if (collision.gameObject.tag == "raita")
		{
			playerdeath();
            StartCoroutine("QueueGameOver");
		}

        if (collision.gameObject.tag == "tp")
        {
            current_tp = collision.gameObject;
        }

        if (collision.tag == "way1")
        {
            Destroy(GameObject.FindGameObjectWithTag("way2"));
        
        }

        if (collision.tag == "way2")
        {
            Destroy(GameObject.FindGameObjectWithTag("way1"));
        }

        if (collision.tag == "book")
        {
            lm.takelife();
            playerdeath();
        }

        if (collision.tag == "flyingbook")
        {
            Destroy(GameObject.FindGameObjectWithTag("flyingbook"));
            Debug.Log("SKateboard unocked");
            mm.addmoney();
            mm.addmoney();
            mm.addmoney();
            mm.addmoney();
            mm.addmoney();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tp")
        {
            if (collision.gameObject == current_tp)
            {
                current_tp = null;
            }
        }
    }
    public void playerdeath()
    {
		isdead = true;
        FindObjectOfType<soundmanager>().Play("damage");
        anim.SetBool("dead", isdead);
		ctrlactive = false;
		playercol.enabled = false;
		foreach(GameObject child in childObjs)
			child.SetActive(false);
		rb.gravityScale = 2f;
		rb.AddForce(transform.up * shockforce, ForceMode2D.Impulse);

		StartCoroutine("PlayerRespawn");  
	}
	IEnumerator PlayerRespawn()
    {
        FindObjectOfType<soundmanager>().Play("respawn");
        yield return new WaitForSeconds(1.5f);
		isdead = false;
		anim.SetBool("dead", isdead);
		playercol.enabled = true;
		foreach (GameObject child in childObjs)
			child.SetActive(true);
		rb.gravityScale = 1f;

		yield return new WaitForSeconds(0.1f);
		ctrlactive = true;
        gm.Replay();
	}

	IEnumerator QueueGameOver()
	{

        yield return new WaitForSeconds(1.5f);
		gm.GameOver();
	}

	public bool isgrounded()
	{
		Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayers);
		if (groundCheck != null)
		{
			return true;
		}
		return false;
	}

	void moveplayer()
	{
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
		anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		if (rb.velocity.x < 0)
		{
			transform.localScale = new Vector2(-2.5f, 2.5f);
		}
		else if (rb.velocity.x > 0)
		{
			transform.localScale = new Vector2(2.5f, 2.5f);
		}

	}

	void jump()
	{
		if (isgrounded())
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
			}
		}
		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			if (airtimecounter > 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
				airtimecounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
		{
			airtimecounter = 0;
		}

		if (isgrounded())
		{
			airtimecounter = airtime;
		}

		anim.SetBool("Grounded", isgrounded());
		anim.SetFloat("Speedy", rb.velocity.y);
	}
}

