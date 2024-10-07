using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Movement movePlayers;

    public ViewPanelLogic dicePanel;

    public OptionalPanel optPanel;

    public Player_Information_panel_logic infoPanel;

    public BuildingPanel buildPanel;

    public RegionInformation regInfo;

    public RegionList regList;

    public int finalPos;

    private bool moneyPoint;

    public int playerMoney;

    public Node_Type type;

    public int reg1Price, reg2Price, reg3Price, reg4Price, reg5Price, reg6Price, reg7Price;

    bool buildBool, buildFreeBool;

    public string buildDiceRes;

    public GameObject gameOver, creditScene, creditsBTN, exitCreditsBTN;

    public GameObject optionsButton, tileInfoBTN, regionPriceBTN, tileInfoPanel, optionPanel, exitOptions, regPrices;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = 1500;
        infoPanel.MoneyAmountField.text = playerMoney.ToString();
        optionsButton = GameObject.Find("Panel - Options");
        tileInfoBTN = GameObject.Find("Panel - Tile Info Button");
        regionPriceBTN = GameObject.Find("Panel - Region Prices Button");
        tileInfoPanel = GameObject.Find("Panel - Tile Type Info");
        optionPanel = GameObject.Find("Panel - Option Buttons");
        exitOptions = GameObject.Find("Panel - Exit Options");
        regPrices = GameObject.Find("Panel - Region Prices Information");
        regPrices.SetActive(false);
        optionPanel.SetActive(false);
        tileInfoPanel.SetActive(false);
        optPanel.canvas1.SetActive(false);
        optPanel.canvas2.SetActive(false);
        optPanel.canvas3.SetActive(false);
        optPanel.canvas4.SetActive(false);
        optPanel.canvas5.SetActive(false);
        optPanel.canvas6.SetActive(false);
        optPanel.canvas7.SetActive(false);
        dicePanel.btnD6.SetActive(true);
        dicePanel.btnBuild.SetActive(false);
        dicePanel.cameraBtn.SetActive(true);
        dicePanel.camera1.SetActive(true);
        dicePanel.camera2.SetActive(false);
        buildPanel.askToBuild.SetActive(false);
        buildPanel.askForFreeBuilding.SetActive(false);
        buildPanel.buildBtn1.SetActive(false);
        buildPanel.buildBtn2.SetActive(false);
        buildPanel.buildBtn3.SetActive(false);
        buildPanel.buildBtn4.SetActive(false);
        buildPanel.buildBtn5.SetActive(false);
        buildPanel.buildBtn6.SetActive(false);
        buildPanel.buildBtn7.SetActive(false);
        buildPanel.buildFreeBtn1.SetActive(false);
        buildPanel.buildFreeBtn2.SetActive(false);
        buildPanel.buildFreeBtn3.SetActive(false);
        buildPanel.buildFreeBtn4.SetActive(false);
        buildPanel.buildFreeBtn5.SetActive(false);
        buildPanel.buildFreeBtn6.SetActive(false);
        buildPanel.buildFreeBtn7.SetActive(false);
        buildPanel.building1.SetActive(false);
        buildPanel.building2.SetActive(false);
        buildPanel.building3.SetActive(false);
        buildPanel.building4.SetActive(false);
        buildPanel.building5.SetActive(false);
        buildPanel.building6.SetActive(false);
        buildPanel.building7.SetActive(false);
        buildPanel.building8.SetActive(false);
        buildPanel.building9.SetActive(false);
        buildPanel.building10.SetActive(false);
        buildPanel.building11.SetActive(false);
        buildPanel.building12.SetActive(false);
        buildPanel.building13.SetActive(false);
        buildPanel.building14.SetActive(false);
        buildPanel.building15.SetActive(false);
        buildPanel.building16.SetActive(false);
        buildPanel.building17.SetActive(false);
        buildPanel.building18.SetActive(false);
        buildPanel.building19.SetActive(false);
        buildPanel.building20.SetActive(false);
        buildPanel.building21.SetActive(false);
        buildPanel.building22.SetActive(false);
        buildPanel.building23.SetActive(false);
        buildPanel.building24.SetActive(false);
        buildPanel.building25.SetActive(false);
        buildPanel.building26.SetActive(false);
        buildPanel.building27.SetActive(false);
        buildPanel.building28.SetActive(false);
        gameOver = GameObject.Find("Canvas - Game Over");
        gameOver.SetActive(false);
        creditScene = GameObject.Find("Canvas - Credits");
        creditScene.SetActive(false);
        creditsBTN = GameObject.Find("Panel - Credits Button");
        exitCreditsBTN = GameObject.Find("Exit - Button");
        optionsButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Do();

    }
    
    public void Do(){        
        if (movePlayers.isMoving==false && dicePanel.counter == true)
        {
            dicePanel.btnD6.SetActive(true);
            int steps = dicePanel.finalResult;
            dicePanel.btnD6.SetActive(false);
            StartCoroutine(movePlayers.Move(steps));
            finalPos = movePlayers.Position() + steps;

            if (finalPos >= 27) {
                finalPos = finalPos - 27;
            }
            dicePanel.counter = false;

            if (type.FindTypeOfNode(finalPos).ToString() == "Start")
            {
                dicePanel.btnD6.SetActive(true);
            }

            if (type.FindTypeOfNode(finalPos).ToString() == "Buy")
            {
                optPanel.Activate();
            }
            else {
                optPanel.Deactivate();
            }
            
            if (type.FindTypeOfNode(finalPos).ToString() == "Build") {
                if (infoPanel.regionsOwned.Count > 0)
                {
                    for (int i = 0; i < infoPanel.regionsOwned.Count; i++)
                    {
                        for (int j = 0; j < regList.regionsIOwn.Count; j++)
                        {
                            if (infoPanel.regionsOwned[i] == regList.regionsIOwn[j].regNumber)
                            {
                                if (regList.regionsIOwn[j].buildingsOwned < 4)
                                {
                                    buildBool = true;
                                }
                            }
                        }
                    }
                    if (buildBool == true)
                    {
                        buildBool = false;
                        buildPanel.askToBuild.SetActive(true);
                    }
                    else
                    {
                        dicePanel.btnD6.SetActive(true);
                    }
                }
                else
                {
                    dicePanel.btnD6.SetActive(true);    
                }
            }

            if (type.FindTypeOfNode(finalPos).ToString() == "Entrance")
            {
                dicePanel.btnD6.SetActive(true);
            }

            if (type.FindTypeOfNode(finalPos).ToString() == "FreeBuilding")
            {
                if (infoPanel.regionsOwned.Count > 0)
                {
                    for (int i = 0; i < infoPanel.regionsOwned.Count; i++)
                    {
                        for (int j = 0; j < regList.regionsIOwn.Count; j++)
                        {
                            if (infoPanel.regionsOwned[i] == regList.regionsIOwn[j].regNumber)
                            {
                                if (regList.regionsIOwn[j].buildingsOwned < 4)
                                {
                                    buildFreeBool = true;
                                }
                            }
                        }
                    }
                    if (buildFreeBool == true)
                    {
                        buildFreeBool = false;
                        buildPanel.askForFreeBuilding.SetActive(true);
                    }
                    else
                    {
                        dicePanel.btnD6.SetActive(true);
                    }
                }
                else
                {
                    dicePanel.btnD6.SetActive(true);
                }
            }
        }
    }

    public void GameOver() 
    {
        if (playerMoney < 0)
        {
            gameOver.SetActive(true);
        }
    }

    public void Credits()
    {
        creditScene.SetActive(true);
    }

    public void Exit()
    { 
        creditScene.SetActive(false);
    }

    public void Options() 
    {
        optionsButton.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void ExitOptions()
    {
        optionPanel.SetActive(false);
        optionsButton.SetActive(true);
    }

    public void TileInformation()
    {
        optionPanel.SetActive(false);
        tileInfoPanel.SetActive(true);
    }

    public void ExitTileInfo()
    {
        tileInfoPanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void RegionInfoPanel()
    {
        optionPanel.SetActive(false);
        regPrices.SetActive(true);
    }

    public void ExitRegionPricesPanel()
    {
        regPrices.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
