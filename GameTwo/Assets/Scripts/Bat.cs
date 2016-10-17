using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

    public float speed = 2.0f;
    public float range = 4.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= range || transform.position.x <= -range || transform.position.y >= range || transform.position.y <= -range || transform.position.z >= range || transform.position.z <= -range)
        {
            speed = -speed;
            transform.Translate(Vector2.right * speed * Time.deltaTime);

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
