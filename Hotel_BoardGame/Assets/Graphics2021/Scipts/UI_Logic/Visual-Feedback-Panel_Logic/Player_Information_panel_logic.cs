using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Information_panel_logic : MonoBehaviour
{

    #region Variables

    public TextMeshProUGUI MoneyAmountField;

    public TextMeshProUGUI regionsAreOwned;

    public Movement move;

    public Game infosForGame;

    public List<int> regionsOwned = new List<int>();
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GainMoneyPoint()
    {
        infosForGame.playerMoney += 2000;

        MoneyAmountField.text = infosForGame.playerMoney.ToString();
    }
}
