using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
    #region Fields
    public Text timer;
    public Text score;
    Coin coin;
 
    #endregion

    void Update()
    {
        timer.text = Mathf.RoundToInt(GameManager.Instance.timer).ToString(); 
        score.text = Mathf.RoundToInt(GameManager.Instance.score).ToString();    
    }
}

