using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCircularDoubleLinkedList : CircularDoubleLinkedList<CustomNode>
{
    public CustomNode peak;
    public override void Add(CustomNode value)
    {
        CustomNode newNode = value;
        count++;

        if (head == null)
        {
            head = newNode;
            last = newNode;
            peak = newNode;

            head.SetNext(head);
            head.SetPrev(head);
            return;
        }
        last.SetNext(newNode);
        newNode.SetPrev(last);
        newNode.SetNext(head);

        head.SetPrev(newNode);

        last = newNode;
        peak = newNode;
    }
    public void MovePeakToPrevTurn()
    {
        CustomNode tem = (CustomNode)peak.Prev;
        peak = tem;
        Debug.Log("El peak se ha movido <-");
    }
    public void MovePeakToNextTurn()
    {
        CustomNode tem = (CustomNode)peak.Next;
        peak = tem;
        Debug.Log("El peak se ha movido ->");
    }
}
