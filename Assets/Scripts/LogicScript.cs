using System.Linq;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;

    void changeMode()
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
