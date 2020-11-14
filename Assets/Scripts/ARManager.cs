using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Vuforia;

public class ARManager : MonoBehaviour
{



    void Start()
    {
        

        StartCoroutine(waitSeconds());

    }
    // Update is called once per frame
    void Update()
    {
      

    }

    private IEnumerator waitSeconds()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.2f);

            foreach (GameObject c in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                if (c.GetComponent<PhotonView>() != null)
                {
                    if (!c.GetComponent<PhotonView>().IsMine)
                    {
                        Destroy(c.gameObject);
                    }
                }
            }

        }
    }
}
