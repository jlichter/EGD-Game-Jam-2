using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTimeOut : MonoBehaviour
{
    #region PublicVariables
    public List<string> acceptPlayerTags;       //this should contain Player1, Player2 or both, used for check vaild player, change value in Editor
    public float Timeout = 0.0f;
    #endregion

    #region PrivateVariables
    private bool _canRunAgain = true;
    #endregion

    #region CollisionFunctions

    void OnCollisionEnter(Collision obj)
    {
        if (acceptPlayerTags.Contains(obj.gameObject.tag) && _canRunAgain == true)
        {
            _canRunAgain = false;
            Debug.Log("collide with" + obj.gameObject.name);
            //TODO: insert your function here for state of button pressed down
            StartCoroutine(SetTimeOut(Timeout));
        }
    }

    #endregion

    #region IEnumratorFunctions
    //If you want to use the info from collision obj, just pass that obj in as a parameter
    IEnumerator SetTimeOut(float _timeout)
    {
        yield return new WaitForSeconds(_timeout);
        _canRunAgain = true;
        Debug.Log("Time out finished");
        //TODO: insert your function here for state of button release
    }
    #endregion
}
