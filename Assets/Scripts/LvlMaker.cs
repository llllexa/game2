using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlMaker : MonoBehaviour
{
	public GameObject[] Lvls;
	private int lvl;
	public Rigidbody2D rbBox;
	public int hard;

	void Start()
    {
		rbBox = GetComponent<Rigidbody2D>();
		rbBox.AddForce(Vector2.up * 13000);
		LvlRandom();
    }

	public void LvlRandom()
	{
		lvl = Random.Range(0, 2);
		Lvls[lvl].SetActive(true);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Lvls[lvl].SetActive(false);
			Lvls[lvl].transform.position = new Vector3(0, 0, 95);
			transform.position = new Vector3(0, -3000, 0);
			hard = PlayerPrefs.GetInt("hard");
			rbBox = GetComponent<Rigidbody2D>();
			rbBox.AddForce(Vector2.up * 13000);
			LvlRandom();
		}
	}
}
