using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;

public class Ball : MonoBehaviour
{
	public float speed;
    private float _startPos;
	private Vector3 a;
	public GameObject objLose;
	public GameObject obj;
	public GameObject gem;
	public GameObject ps1;
	public int Gems;
	public int GemsNow;
	public int lifes;
	public Text GemT;
	public ParticleSystem pss;
	public bool tp;
	public int ballSelect;
	private SpriteRenderer spriteR;
    public Sprite[] sprites;

	void Start()
	{
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		ballSelect = PlayerPrefs.GetInt("ballSelect");
		switch(ballSelect)
		{
			case 1:
				GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
				spriteR.sprite = sprites[0];
				break;
				
			case 2:
				GetComponent<SpriteRenderer>().color = new Color(1f,0.816515f,0f,1f);
				spriteR.sprite = sprites[0];
				break;
				
			case 3:
				GetComponent<SpriteRenderer>().color = new Color(0f,0.3465471f,1f,1f);
				spriteR.sprite = sprites[0];
				break;
				
			case 4:
				GetComponent<SpriteRenderer>().color = new Color(1f,0f,0.5562973f,1f);
				spriteR.sprite = sprites[0];
				break;
				
			case 5:
				GetComponent<SpriteRenderer>().color = new Color(0.3207f,0.3207f,0.3207f,1f);
				spriteR.sprite = sprites[1];
				break;
				
			case 6:
				GetComponent<SpriteRenderer>().color = new Color(1f,0.0550321f,0f,1f);
				spriteR.sprite = sprites[1];
				break;
			
			case 7:
				GetComponent<SpriteRenderer>().color = new Color(0f,0.8058f,1f,1f);
				spriteR.sprite = sprites[1];
				break;
				
			case 8:
				GetComponent<SpriteRenderer>().color = new Color(0.0407862f,1f,0f,1f);
				spriteR.sprite = sprites[1];
				break;
				
			case 9:
				GetComponent<SpriteRenderer>().color = new Color(1f,0.465483f,0f,1f);
				spriteR.sprite = sprites[2];
				break;
				
			case 10:
				GetComponent<SpriteRenderer>().color = new Color(0.9163541f,1f,0f,1f);
				spriteR.sprite = sprites[2];
				break;
				
			case 11:
				GetComponent<SpriteRenderer>().color = new Color(1f,0.4705882f,0.61960f,1f);
				spriteR.sprite = sprites[2];
				break;
				
			case 12:
				GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
				spriteR.sprite = sprites[2];
				break;
				
			case 13:
				GetComponent<SpriteRenderer>().color = new Color(0.12f,0.6f,0.35f,1f);
				break;
				
			case 14:
				GetComponent<SpriteRenderer>().color = new Color(0.12f,0.6f,0.35f,1f);
				break;
				
			case 15:
				GetComponent<SpriteRenderer>().color = new Color(0.12f,0.6f,0.35f,1f);
				break;
				
			case 16:
				GetComponent<SpriteRenderer>().color = new Color(0.12f,0.6f,0.35f,1f);
				break;
		}
		tp = true;
		lifes = 5;
		speed = 19f;			   // Лучше не трогай
		GemsNow = 0;
		PlayerPrefs.SetInt("GemsNow", GemsNow);
	}
	
	private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    a = new Vector3(touch.position.x - _startPos, 0, 0);
                    transform.Translate(a * speed * Time.deltaTime);
					_startPos = touch.position.x;
                    break;
				case TouchPhase.Ended:
					if(tp == true)
					{
						//Time.timeScale = 0.5f;
						//tp = false;
						//StartCoroutine(Tep());
						
					}
                    break;
            }
        }
    }
	
	    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			Instantiate(ps1, new Vector3(other.transform.position.x, other.transform.position.y, ps1.transform.position.z), Quaternion.identity);
			if (lifes > 0)
			{
				lifes--;

			}
			else 
			{
				tp = false;
				objLose.SetActive(true);
				Time.timeScale = 0;
			}
			other.transform.position = new Vector3(0, 500, ps1.transform.position.z);
		}
		if(other.tag == "Gem")
		{
			GemsNow++;
			PlayerPrefs.SetInt("GemsNow", GemsNow);
			GemT.text = GemsNow.ToString();
		}
		if (other.tag == "Life")
		{
			lifes++;
		}
	}
	
	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
		objLose.SetActive(false);
	}
	
	IEnumerator Tep()
	{
		yield return new WaitForSeconds(2f);
		Time.timeScale = 1;
		yield return new WaitForSeconds(5f);
		tp = true;
	}
}