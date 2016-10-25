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
        if(Input.GetMouseButton(0))
        {
            if (currentAmount < 100)
            {
                currentAmount += speed * Time.deltaTime;
                //TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
                //TextLoading.gameObject.SetActive(true);
            }
            else
            {
               
                //TextLoading.gameObject.SetActive(false);
            }
            LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
        }
        else
        {
            LoadingBar.GetComponent<Image>().fillAmount = 0 ;
            currentAmount = 0;
        }
	}
}
