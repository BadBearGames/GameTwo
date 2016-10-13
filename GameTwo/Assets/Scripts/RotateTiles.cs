using UnityEngine;
using System.Collections;

public class RotateTiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 8, 0 * Time.deltaTime);
	}
}
