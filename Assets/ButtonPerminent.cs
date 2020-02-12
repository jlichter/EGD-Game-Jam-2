using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPerminent : MonoBehaviour
{

    #region PublicVariables
    public List<string> acceptPlayerTags;       //this should contain Player1, Player2 or both, used for check vaild player, change value in Editor
    #endregion

    #region PrivateVariables
    private bool trigger = false;
    #endregion

    #region CollisionFunctions

    void OnCollisionEnter(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag) && trigger == false)
        {
            trigger = true;
            Debug.Log("collide with" + obj.gameObject.name);
            //TODO: insert your function here
        }
    }

    #endregion
}
