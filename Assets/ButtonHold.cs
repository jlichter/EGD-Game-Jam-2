using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    #region PublicVariables
    public List<string> acceptPlayerTags;       //this should contain Player1, Player2 or both, used for check vaild player, change value in Editor
    #endregion

    #region PrivateVariables
    #endregion

    #region CollisionFunctions

    void OnCollisionEnter(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag))
        {
            Debug.Log("collide with" + obj.gameObject.name + "starts");
            //TODO: insert your function here for state of button pressed down
        }
    }

    void OnCollisionExit(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag))
        {
            Debug.Log("collide with" + obj.gameObject.name + "ends");
            //TODO: insert your function here for state of button released
        }
    }

    #endregion
}
