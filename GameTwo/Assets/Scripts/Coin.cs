using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    #region Fields
    private bool isCollected = false;
    #endregion

    #region Properties
    public bool IsCollected { get { return isCollected; } }
    #endregion

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(25 * Time.deltaTime, 5 * Time.deltaTime, 50 * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other){
        isCollected=true;
        GameManager.Instance.CollectedCoin(this);
        Destroy(this.gameObject);

    }
}
