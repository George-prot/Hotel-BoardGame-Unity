using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewPanelLogic : MonoBehaviour
{
    #region Variables
    public GameObject[] Views;

    public TextMeshProUGUI RollTextField;

    public Player_Information_panel_logic playerInfo;

    public bool counter = true;

    public bool buildingDiceBool;

    int rollResult;

    public int finalResult;

    public string buildResult;

    //public bool buildDiceActivated;

    public GameObject btnD6, btnBuild, cameraBtn, camera1, camera2;

    public BuildingPanel build;

    public RegionList regions;

    public Game game;

    public Movement move;

    bool cameraBoolean=false;

    BuildDiceFaceValues BuildDiceResult;

    BuildDiceFaceValues finalBuildDiceResult;

    #endregion

    #region Unity functions

    // Start is called before the first frame update
    void Start()
    {
        btnD6 = GameObject.Find("Button - Roll D6 Dice");

        btnBuild = GameObject.Find("Button - Roll Build Dice");

        cameraBtn = GameObject.Find("Button - Camera");

        camera1 = GameObject.Find("Main Camera");

        camera2 = GameObject.Find("Camera2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Roll D6

    int shuffleTimes, shuffleCounter;

    int shuffleBuild, shuffleBuildCount;

    public void ChangeCamera() 
    {
        if (cameraBoolean == false)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            cameraBoolean = true;
        }
        else {
            camera2.SetActive(false);
            camera1.SetActive(true);
            cameraBoolean = false;
        }
    
    }

    public void RollD6()
    {
        if (move.isMoving == false)
        {
            counter = false;
            ToggleView(0);
            shuffleTimes = Random.Range(5, 20);
            shuffleCounter = 0;
            Invoke("RollD6Repeating", 0.1f);
        }
    }

    public void RollD6Repeating()
    {
        counter = false;
        rollResult = Random.Range(1, 7);
        RollTextField.text = rollResult.ToString();

        shuffleCounter++;
        if (shuffleCounter < shuffleTimes)
        {
            Invoke("RollD6Repeating", 0.1f);
        }
        else if (shuffleCounter == shuffleTimes)
        {
            counter = true;
        }

        if (counter == true)
        {
            finalResult = rollResult;
        }

    }

    #endregion

    #region Roll Build Dice

    public void RollBuild()
    {
        ToggleView(0);
        shuffleBuild = Random.Range(5, 20);
        shuffleBuildCount = 0;
        Invoke("RollBuildRepeating", 0.1f);

    }

    public void RollBuildRepeating()
    {
        int rollResult = Random.Range(1, 7);

        if (rollResult <= 3)
        { //Success
            BuildDiceResult = BuildDiceFaceValues.Success;
        }
        else if (rollResult <= 4)
        { //Fail
            BuildDiceResult = BuildDiceFaceValues.Fail;
        }
        else if (rollResult <= 5)
        { //Double
            BuildDiceResult = BuildDiceFaceValues.Double;
        }
        else
        { //Free
            BuildDiceResult = BuildDiceFaceValues.Free;
        }

        if (BuildDiceResult == BuildDiceFaceValues.Success)
        {
            RollTextField.text = "Success";
        }
        else if (BuildDiceResult == BuildDiceFaceValues.Fail)
        {
            RollTextField.text = "Failed";
        }
        else if (BuildDiceResult == BuildDiceFaceValues.Double)
        {
            RollTextField.text = "Double Cost";
        }
        else if (BuildDiceResult == BuildDiceFaceValues.Free)
        {
            RollTextField.text = "Free Build";
        }

        shuffleBuildCount++;
        if (shuffleBuildCount < shuffleBuild)
        {
            Invoke("RollBuildRepeating", 0.1f);
        }
        else if (shuffleBuildCount == shuffleBuild)
        {
            finalBuildDiceResult = BuildDiceResult;
            buildingDiceBool = true;
        }

        if (buildingDiceBool == true)
        {
            buildingDiceBool = false;
            Buildings();
        }

    }

    #endregion

    #region View Logic
    public void ResetView()
    {

        ToggleView(-1);

    }

    public void ToggleView(int index)
    {

        for (int i = 0; i < Views.Length; i++)
        {

            if (index == i)
            {

                Views[i].SetActive(true);

            }
            else
            {

                Views[i].SetActive(false);

            }

        }

    }
    #endregion

    public void Buildings()
    {
        if (build.reg1 == true)
        {
            build.reg1 = false;
            if (regions.regionsIOwn[0].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building1.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building1.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building1.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[0].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building2.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building2.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building2.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[0].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building3.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building3.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building3.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[0].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building4.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building4.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[0].buildingsOwned += 1;
                    build.building4.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
        else if (build.reg2 == true)
        {
            build.reg2 = false;
            if (regions.regionsIOwn[1].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building5.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building5.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building5.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[1].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building6.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building6.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building6.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[1].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building7.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building7.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building7.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[1].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building8.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building8.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[1].buildingsOwned += 1;
                    build.building8.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
        else if (build.reg3 == true)
        {
            build.reg3 = false;
            if (regions.regionsIOwn[2].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building9.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building9.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building9.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[2].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building10.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building10.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building10.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[2].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building11.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building11.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building11.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[2].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building12.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building12.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[2].buildingsOwned += 1;
                    build.building12.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
        else if (build.reg4 == true)
        {
            build.reg4 = false;
            if (regions.regionsIOwn[3].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building13.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building13.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building13.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[3].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building14.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building14.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building14.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[3].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building15.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building15.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building15.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[3].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building16.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building16.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[3].buildingsOwned += 1;
                    build.building16.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
        else if (build.reg5 == true)
        {
            build.reg5 = false;
            if (regions.regionsIOwn[4].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building17.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building17.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building17.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[4].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building18.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building18.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building18.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[4].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building19.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building19.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building19.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[4].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building20.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building20.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[4].buildingsOwned += 1;
                    build.building20.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
        else if (build.reg6 == true)
        {
            build.reg6 = false;
            if (regions.regionsIOwn[5].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building21.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building21.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building21.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[5].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building22.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building22.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building22.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[5].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building23.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building23.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building23.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[5].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building24.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building24.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[5].buildingsOwned += 1;
                    build.building24.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
        else if (build.reg7 == true)
        {
            build.reg7 = false;
            if (regions.regionsIOwn[6].buildingsOwned == 0)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building25.SetActive(true);
                    game.playerMoney -= 200;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building25.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building25.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[6].buildingsOwned == 1)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building26.SetActive(true);
                    game.playerMoney -= 300;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building26.SetActive(true);
                    game.playerMoney -= 600;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building26.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[6].buildingsOwned == 2)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building27.SetActive(true);
                    game.playerMoney -= 400;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building27.SetActive(true);
                    game.playerMoney -= 800;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building27.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
            else if (regions.regionsIOwn[6].buildingsOwned == 3)
            {
                if (finalBuildDiceResult == BuildDiceFaceValues.Success)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building28.SetActive(true);
                    game.playerMoney -= 500;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Double)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building28.SetActive(true);
                    game.playerMoney -= 1000;
                    playerInfo.MoneyAmountField.text = game.playerMoney.ToString();
                    game.GameOver();
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Fail)
                {
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
                else if (finalBuildDiceResult == BuildDiceFaceValues.Free)
                {
                    regions.regionsIOwn[6].buildingsOwned += 1;
                    build.building28.SetActive(true);
                    btnBuild.SetActive(false);
                    btnD6.SetActive(true);
                }
            }
        }
    }

    public enum BuildDiceFaceValues
    {

        Success, Fail, Double, Free
    }
}