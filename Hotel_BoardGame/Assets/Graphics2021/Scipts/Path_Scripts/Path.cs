using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    Transform[] pathNodes;
    public List<Transform> nodeList = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        FillNodes();

        for (int i = 0; i < nodeList.Count; i++)
        {
            Vector3 currentNode = nodeList[i].position;
            if (i > 0) {
                Vector3 prevNode = nodeList[i - 1].position;
                Gizmos.DrawLine(prevNode, currentNode);
            }
        }
        Gizmos.DrawLine(nodeList[nodeList.Count-1].position, nodeList[0].position);
    }

    void FillNodes() {
        nodeList.Clear();

        pathNodes = gameObject.GetComponentsInChildren<Transform>();


        foreach (Transform node in pathNodes) {
            if (node != this.transform) {
                nodeList.Add(node);
            }
        }
    }

}
