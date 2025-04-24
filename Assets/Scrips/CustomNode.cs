using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomNode : Node<CustomNode>
{
    PlayerMovement playerGO;

    public CustomNode(PlayerMovement playerGO) : base(null)
    {
        this.playerGO = playerGO;
    }
}
