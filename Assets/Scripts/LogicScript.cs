using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public InputActionReference changeModeAction;

    void Update()
    {
        if (changeModeAction.action.WasPressedThisFrame())
        {
            ChangeMode();
        }
    }

    void ChangeMode()
    {
        switch (player.tag)
        {
            case "2D":
                player.tag = "TopDown";
                break;
            case "TopDown":
                player.tag = "2D";
                break;
        }
    }
}
