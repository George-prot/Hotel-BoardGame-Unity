using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Type : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NodeType FindTypeOfNode(int pos)
    {
        NodeType nodeType = 0;

        if (pos == 0)
        { //Start
            nodeType = NodeType.Start;
        }
        else if (pos == 1 || pos == 3 || pos == 5 || pos == 10 || pos == 12 || pos == 14 || pos == 17 || pos == 19 || pos == 22 || pos == 23 || pos == 26)
        { //Build
            nodeType = NodeType.Build;
        }
        else if (pos == 2 || pos == 4 || pos == 7 || pos == 9 || pos == 11 || pos == 13 || pos == 15 || pos == 18 || pos == 20 || pos == 24)
        { //Buy
            nodeType = NodeType.Buy;
        }
        else if (pos == 6 || pos == 16 || pos == 25)
        { //Entrance
            nodeType = NodeType.Entrance;
        }
        else if (pos == 8 || pos == 21)
        { //FreeBuilding 
            nodeType = NodeType.FreeBuilding;
        }

        return nodeType;

    }

    public enum NodeType
    {
        Start, Build, Buy, Entrance, FreeBuilding
    }

}
