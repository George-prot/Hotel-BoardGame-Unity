using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalPanel : MonoBehaviour
{
    public GameObject choose;

    public GameObject canvas1, canvas2, canvas3, canvas4, canvas5, canvas6, canvas7;

    public bool yesBool;

    public bool noBool;

    public Game game;

    public Path currPath;

    public NodeList list;

    public Player_Information_panel_logic infos;

    bool notOwned1, notOwned2, notOwned3, notOwned4, notOwned5, notOwned6, notOwned7, fBool;

    bool secNotOwned1, secNotOwned2, secNotOwned3, secNotOwned4, secNotOwned5, secNotOwned6, secNotOwned7, sBool;

    //public NodeRegions regs;

    //Movement move;

    //public NodeRegions regs;

    // Start is called before the first frame update
    void Start()
    {
        choose = GameObject.Find("Choosing-Panel");

        choose.SetActive(false);

        canvas1 = GameObject.Find("Canvas-buy1");

        canvas2 = GameObject.Find("Canvas-buy2");

        canvas3 = GameObject.Find("Canvas-buy3");

        canvas4 = GameObject.Find("Canvas-buy4");

        canvas5 = GameObject.Find("Canvas-buy5");

        canvas6 = GameObject.Find("Canvas-buy6");

        canvas7 = GameObject.Find("Canvas-buy7");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate() 
    {
        for(int i = 0; i < infos.regionsOwned.Count; i++)
        {
            if (list.listOfNodes[game.finalPos].firstRegion == infos.regionsOwned[i])
                fBool = true;
            if (list.listOfNodes[game.finalPos].secondRegion == infos.regionsOwned[i])
                sBool = true;
        }
        if (fBool == false || sBool == false)
        {
            choose.SetActive(true);
        }
        else 
        {
            game.dicePanel.btnD6.SetActive(true);        
        }
        fBool = false;
        sBool = false;
    }

    public void Deactivate()
    {
        choose.SetActive(false);
    }

    public void YesBTN() 
    {
        Deactivate();
        if ((list.listOfNodes[game.finalPos].firstRegion)== 1){
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 1)
                {
                    notOwned1 = true;
                }
            }

            if (notOwned1 == false)
            {
                canvas1.SetActive(true);
            }

        }else if ((list.listOfNodes[game.finalPos].firstRegion) == 2)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 2)
                {
                    notOwned2 = true;
                }
            }

            if (notOwned2 == false)
            {
                canvas2.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].firstRegion) == 3)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 3)
                {
                    notOwned3 = true;
                }
            }

            if (notOwned3 == false)
            {
                canvas3.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].firstRegion) == 4)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 4)
                {
                    notOwned4 = true;
                }
            }
            if (notOwned4 == false)
            {
                canvas4.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].firstRegion) == 5)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 5)
                {
                    notOwned5 = true;
                }
            }
            if (notOwned5 == false)
            {
                canvas5.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].firstRegion) == 6)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 6)
                {
                    notOwned6 = true;
                }
            }
            if (notOwned6 == false)
            {
                canvas6.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].firstRegion) == 7)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 7)
                {
                    notOwned7 = true;
                }
            }
            if (notOwned7 == false)
            {
                canvas7.SetActive(true);
            }
        }
        if ((list.listOfNodes[game.finalPos].secondRegion) == 1)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 1)
                {
                    secNotOwned1 = true;
                }
            }
            if (secNotOwned1 == false)
            {
                canvas1.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].secondRegion) == 2)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 2)
                {
                    secNotOwned2 = true;
                }
            }
            if (secNotOwned2 == false)
            {
                canvas2.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].secondRegion) == 3)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 3)
                {
                    secNotOwned3 = true;
                }
            }
            if (secNotOwned3 == false)
            {
                canvas3.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].secondRegion) == 4)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 4)
                {
                    secNotOwned4 = true;
                }
            }
            if (secNotOwned4 == false)
            {
                canvas4.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].secondRegion) == 5)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 5)
                {
                    secNotOwned5 = true;
                }
            }
            if (secNotOwned5 == false)
            {
                canvas5.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].secondRegion) == 6)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 6)
                {
                    secNotOwned6 = true;
                }
            }

            if (secNotOwned6 == false)
            {
                canvas6.SetActive(true);
            }
        }
        else if ((list.listOfNodes[game.finalPos].secondRegion) == 7)
        {
            for (int i = 0; i < infos.regionsOwned.Count; i++)
            {
                if (infos.regionsOwned[i] == 7)
                {
                    secNotOwned7 = true;
                }
            }
            if (secNotOwned7 == false)
            {
                canvas7.SetActive(true);
            }
        }
    }

    public void NoBTN()
    {
        Deactivate();
        game.dicePanel.btnD6.SetActive(true);
    }

    public void DeactivateCanvasBtn() {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        canvas7.SetActive(false);
    }

    public void Btn1() {
        infos.regionsOwned.Add(1);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '1';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg1Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

    public void Btn2()
    {
        infos.regionsOwned.Add(2);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '2';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg2Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

    public void Btn3()
    {
        infos.regionsOwned.Add(3);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '3';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg3Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

    public void Btn4()
    {
        infos.regionsOwned.Add(4);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '4';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg4Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

    public void Btn5()
    {
        infos.regionsOwned.Add(5);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '5';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg5Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

    public void Btn6()
    {
        infos.regionsOwned.Add(6);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '6';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg6Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

    public void Btn7()
    {
        infos.regionsOwned.Add(7);
        DeactivateCanvasBtn();
        infos.regionsOwned.Sort();
        infos.regionsAreOwned.text = infos.regionsAreOwned.text + '\t' + '7';
        game.dicePanel.btnD6.SetActive(true);
        game.playerMoney = game.playerMoney - game.reg7Price;
        game.GameOver();
        infos.MoneyAmountField.text = game.playerMoney.ToString();
    }

}
