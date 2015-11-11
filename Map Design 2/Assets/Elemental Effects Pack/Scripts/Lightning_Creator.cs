using UnityEngine;
using System.Collections;


//This script is used to instantiate a number of electric arcs
//with a certain frequency and a certain quantity
//it also sets the lightning prefab line renderer's attributes


public class Lightning_Creator : MonoBehaviour {

	public Lightning lightning_prefab;

	public float maxZ;
	public int points;
	public Color color = Color.white;
	public float posRange;
	public float radius;
	public Vector2 midpoint;

	public int ArcMultiplier;


	IEnumerator Start () {
		while (true) {
			Process_Lightning();
			for (int i=0;i<ArcMultiplier;i++)
			{
				if(lightning_prefab)
				{
					Instantiate (lightning_prefab, this.transform.position, Quaternion.identity);
				}
			}
			yield return null;
		}
	}

	public void Process_Lightning()
	{
		if (lightning_prefab) {
			//line renderer need at least 1 segment to process
			if (points < 2) {
				points = 2;
			}
			lightning_prefab.maxZ = maxZ;
			lightning_prefab.segments = points;
			lightning_prefab.color = color;
			lightning_prefab.posRange = posRange;
			lightning_prefab.radius = radius;
			lightning_prefab.midpoint = midpoint;
		}
	}
}
