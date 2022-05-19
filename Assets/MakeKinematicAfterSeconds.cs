using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeKinematicAfterSeconds : MonoBehaviour
{
    bool touched = false;
    void OnCollisionEnter()
    {
        if (!touched)
        {
            StartCoroutine(MakeKinematic());
            touched = true;
        }
    }

    IEnumerator MakeKinematic()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        

    }
}
