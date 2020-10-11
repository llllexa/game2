using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBase : MonoBehaviour
{
	public Rigidbody2D rbBox;
	public int hard;
	
    void Start()
    {
		hard = PlayerPrefs.GetInt("hard");
		rbBox = GetComponent<Rigidbody2D>();
		rbBox.AddForce(Vector2.up * 13000);

    }
}