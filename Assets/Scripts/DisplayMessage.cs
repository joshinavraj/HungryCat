using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMessage : MonoBehaviour
{
	

	private bool timerEnabled = false;
	public float time;
	public Text t;
	private float timeSpent = 0;

	// Use this for initialization
	void Start()
	{
		t.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{	
		

		if (timerEnabled)
		{
			timeSpent += Time.deltaTime;
		}
		if (timeSpent > time)
		{
			
			t.enabled = false;
			timerEnabled = false;
			timeSpent = 0;
		}
	}
	// this show text only player trigger the sphere(game object)
	void OnTriggerEnter2D(Collider2D coll)
	{
		                                  
		t.enabled = true;
		timerEnabled = true;
	}
		// do not show text when exit trigger
	void OnTriggerExit2D(Collider2D coll)
	{
		                                       
		t.enabled = false;
		                                              
	}
}
