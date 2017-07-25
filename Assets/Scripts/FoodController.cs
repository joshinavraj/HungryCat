using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FoodController : MonoBehaviour {

	//when game object collide with player , scene will change to finalScene
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.name.Equals("player")){
			SceneManager.LoadScene("finalScene");
		}
	}

}
