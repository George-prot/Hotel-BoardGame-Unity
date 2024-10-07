using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Path currentPath;

    public ViewPanelLogic panel;

    public int routPosition;

    public string finalPosition;

    public int steps;

    public bool isMoving;

    static Vector3 nextPos;

    public Vector3 position = nextPos;

    public bool moneyPoint;

    void Update()
    {
        
    }

    public IEnumerator Move(int steps) {

        if (isMoving) {
            yield break;
        }
        isMoving = true;
        while (steps > 0) {

            if (routPosition < currentPath.nodeList.Count-1)
            {
                nextPos = currentPath.nodeList[routPosition + 1].position;
            }
            else { 
                nextPos = currentPath.nodeList[0].position;
            }
                     

            while (MoveToNextNode(nextPos)) {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
            steps--;
            if (nextPos == currentPath.nodeList[0].position)
            {
                routPosition = 0;
            }
            else
            {
                routPosition++;
            }

        }

        isMoving = false;
    }

    public int Position() {
        
            return routPosition;
        
    }

    bool MoveToNextNode(Vector3 targetNode) {
        return targetNode != (transform.position = Vector3.MoveTowards(transform.position, targetNode, 70f * Time.deltaTime));
    }

}
