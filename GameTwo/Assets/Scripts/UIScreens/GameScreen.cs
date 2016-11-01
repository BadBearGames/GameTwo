using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
    #region Fields
    public Text timer;
    public Text score;
    Coin coin;
    int ten;
    #endregion

    void Update()
    {
        ten += 10;
        timer.text = Mathf.RoundToInt(GameManager.Instance.timer).ToString();
       
            score.text = Mathf.RoundToInt(GameManager.Instance.score).ToString();
        
    }
}

