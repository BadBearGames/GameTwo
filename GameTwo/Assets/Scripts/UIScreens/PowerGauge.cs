using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerGauge : MonoBehaviour {

    InputManager input;
    public Transform LoadingBar;

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

	// Update is called once per frame
	void Update()
    {

         //if mouse down
        if (Input.GetMouseButton(0))
        {
            //and amount less than 100
            //if (currentAmount < 100)
            //{
            //    //add amount 
            //    currentAmount += speed * Time.deltaTime;
            //    //For text indictors 
            //    //TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            //    //TextLoading.gameObject.SetActive(true);
            //}
            //fill the bar
            // LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

            if (LoadingBar.GetComponent<RectTransform>().transform.localScale.x < 8)
            {
                LoadingBar.GetComponent<RectTransform>().transform.localScale += new Vector3(.2f, .2f, .2f);
            }

        }
        else
        {
            //reset
            //LoadingBar.GetComponent<Image>().fillAmount = 0 ;
            LoadingBar.GetComponent<RectTransform>().transform.localScale = new Vector3(0, 0, 0);

        }
	}
}
