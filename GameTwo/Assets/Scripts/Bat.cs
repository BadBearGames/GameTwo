using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

    public float speed = 2.0f;
    public float range = 4.0f;
    private Vector3 worldRangeMax;
    private Vector3 worldRangeMin;

	// Use this for initialization
	void Start () {
        worldRangeMax = new Vector3(range,range,range)+this.transform.position;
        worldRangeMin = this.transform.position - new Vector3(range, range, range);
        print("Max: "+worldRangeMax);
        print("Min: "+worldRangeMin);
	}
	
	// Update is called once per frame
    void Update(){
        //float rangeX = this.transform.position.x+range;
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (this.transform.position.x >= worldRangeMax.x || this.transform.position.x <= worldRangeMin.x || this.transform.position.y >= worldRangeMax.y || this.transform.position.y <= worldRangeMin.y || this.transform.position.z >= worldRangeMax.z || this.transform.position.z <= worldRangeMin.z)
        {
            speed = -speed;
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Destroy(gameObject);
            // Destroy(collision.gameObject);

            //yield return new WaitForSeconds(2);

            // Instantiate(Resources.Load("Player"));
            collision.transform.position = new Vector3(20, -.4f, .5f);
            //Application.LoadLevel("Main");
        }
    }
}
