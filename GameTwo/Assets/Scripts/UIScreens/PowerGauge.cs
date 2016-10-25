using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerGauge : MonoBehaviour {


    public Transform LoadingBar;

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

	// Update is called once per frame
	void Update()
    {
        //if mouse down
        if(Input.GetMouseButton(0))
        {
            //and amount less than 100
            if (currentAmount < 100)
            {
                //add amount 
                currentAmount += speed * Time.deltaTime;
                //For text indictors 
                //TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
                //TextLoading.gameObject.SetActive(true);
            }
            //fill the bar
            LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
        }
        else
        {
            //reset
            LoadingBar.GetComponent<Image>().fillAmount = 0 ;
            currentAmount = 0;
        }
	}
}
