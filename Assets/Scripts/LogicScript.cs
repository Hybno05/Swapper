using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LogicScript : MonoBehaviour
{
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
        switch (gameObject.transform.tag)
        {
            case "2D":
                gameObject.transform.tag = "TopDown";
                break;
            case "TopDown":
                gameObject.transform.tag = "2D";
                break;
        }
    }
}
