using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        col.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
