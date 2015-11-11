using UnityEngine;
using System.Collections;

//this script is used to traverse a collection of game objects
//and activate them one at a time for a certain duration of time
//the traversion is done in repetition.

public class presentation : MonoBehaviour {


	public float Duration;
	public GameObject[] children;
	private int i;	
	void Start () {
		children = new GameObject[transform.childCount];
		OriginalDuration = Duration;		
		foreach(Transform child in transform){			
			children[i++] = child.gameObject;			
		}
	}

	public bool activated=true;
	public float OriginalDuration;
	private int j;

	public void SetElement()
	{
		Debug.Log (j);
		if (Duration > 0)
		{
			if (activated==true)
			{
				children[j].SetActive(true);
			}
			Duration -= Time.deltaTime;
			activated=false;
		}
		else{
			Duration=OriginalDuration;
			activated=true;
			children[j].SetActive(false);
			if(j<children.Length-1)
			{
				j=j+1;
			}
			else{
				j=0;
			}
		}
	}

	void Update()
	{			
		if (children.Length > 0) {
			SetElement();
		}
	}
}
