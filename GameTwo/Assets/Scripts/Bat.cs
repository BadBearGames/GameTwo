using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

    public float speed = 2.0f;
    public float range = 4.0f;
    private Vector3 worldRange;
	// Use this for initialization
	void Start () {
        worldRange = new Vector3(range,range,range)+transform.position;
	}
	
	// Update is called once per frame
    void Update(){
        //float rangeX = this.transform.position.x+range;
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (this.transform.position.x >= worldRange.x || this.transform.position.x <= -worldRange.x || this.transform.position.y >= worldRange.y || this.transform.position.y <= -worldRange.y || this.transform.position.z >= worldRange.z || this.transform.position.z <= -worldRange.z)
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
