using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	public LineRenderer lineRenderer;
	public float maxZ;
	public int segments;
	public Color color;
	public float posRange;
	public float radius;
	public Vector2 midpoint;

	public float I1;
	public float I2;

	void Start()
	{
		//get line renderer of current component
		lineRenderer = GetComponent<LineRenderer> ();

		//every line needs to have at least 2 points to be relevant
		if (segments < 2) {
			segments = 2;
		}

			//we draw an arch by calculating a midpoint relative to the line renderer original position
			lineRenderer.SetVertexCount (segments);
			midpoint = new Vector2 (Random.Range (-radius, radius), Random.Range (-radius, radius));
			//Debug.Log (segments);
			for (int i = 1; i < segments -1; i++) {
				// 16 si 2 unde maxz = 8	

				I1 = 1;
				I2 = maxZ;

				float z = ((float)i) * maxZ / (float)(segments - 1);
				float x = -midpoint.x * z * z / I2 + z * midpoint.x / I1;
				float y = -midpoint.y * z * z / I2 + z * midpoint.y / I1;

				//every poin in the line renderer between its endings is manipulated according
				//to the midpoint + certain abberations of movement
				lineRenderer.SetPosition (i, new Vector3 (x + Random.Range (-posRange, posRange), (y + Random.Range (-posRange, posRange)), z));
			}
			//line renderer endings remain at 0-0-0 
			lineRenderer.SetPosition (0, new Vector3 (0f, 0f, 0f));
			lineRenderer.SetPosition (segments - 1, new Vector3 (0f, 0f, maxZ));
		
	}
	
	// Update is called once per frame
	void Update () {	
		color.a -= 10f * Time.deltaTime;
		lineRenderer.SetColors (color, color);
		if (color.a <= 0.0f) {
			Destroy(this.gameObject);
		}
	}
}
