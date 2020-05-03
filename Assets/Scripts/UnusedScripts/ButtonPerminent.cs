using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPerminent : MonoBehaviour
{

    #region PublicVariables
    public List<string> acceptPlayerTags;       //this should contain Player1, Player2 or both, used for check vaild player, change value in Editor
    public GameObject targetPlatform;
    public float t_x;
    public float t_y;
    public float t_z;
    #endregion

    #region PrivateVariables
    private bool trigger = false;
    #endregion

    #region CollisionFunctions

    void OnCollisionEnter(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag) && trigger == false)
        {
            if (targetPlatform != null) {
                Quaternion targetAngle = Quaternion.Euler(t_x, t_y, t_z);
                targetPlatform.transform.rotation = Quaternion.Slerp(targetPlatform.transform.rotation, targetAngle, 1.0f);
            }
            trigger = true;
            Debug.Log("collide with" + obj.gameObject.name);
            //TODO: insert your function here
        }
    }

    #endregion
}
