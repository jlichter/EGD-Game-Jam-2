using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    #region PublicVariables
    public List<string> acceptPlayerTags;       //this should contain Player1, Player2 or both, used for check vaild player, change value in Editor
    public GameObject targetPlatform;
    public float t_x;
    public float t_y;
    public float t_z;
    public float out_x;
    public float out_y;
    public float out_z;
    public GameManager gameManager;
  
    #endregion

    #region PrivateVariables
    #endregion

    #region CollisionFunctions

    void OnCollisionEnter(Collision obj)
    {
        Debug.Log("here!");
        if (acceptPlayerTags.Contains(obj.gameObject.tag))
        {
            Debug.Log("collide with" + obj.gameObject.name + "starts");
            if(targetPlatform != null) {
                Quaternion targetAngle= Quaternion.Euler(t_x, t_y, t_z);
                targetPlatform.transform.rotation = Quaternion.Slerp(targetPlatform.transform.rotation, targetAngle, 1.0f);
            }
            //TODO: insert your function here for state of button pressed down
        }
    }

    void OnCollisionExit(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag))
        {
            Debug.Log("collide with" + obj.gameObject.name + "ends");
            //TODO: insert your function here for state of button released
            if (targetPlatform != null) {
                Quaternion targetAngle = Quaternion.Euler(out_x, out_y, out_z);
                targetPlatform.transform.rotation = Quaternion.Slerp(targetPlatform.transform.rotation, targetAngle, 1.0f);
            }
        }
    }
    void Rotate(GameObject target, float x, float y, float z) {
        Quaternion targetAngle = Quaternion.Euler(x, y, z);
    }
    //void RotateLongPlat() {
      //  LongPlatform.transform.Rotate()
    //}

    #endregion
}
