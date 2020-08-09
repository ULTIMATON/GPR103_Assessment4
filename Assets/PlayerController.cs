using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly float jumpCoolDown = 0.5f;
    private bool jumpCoolDownActivated = false;

    public GameObject frogSprite;

    // Update is called once per frame
    void Update()
    {
        if (jumpCoolDownActivated)
        {
            return;
        }
        var horiz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        if (Mathf.Abs(vert) > 0)
        {
            if (vert > 0)
            {
                frogSprite.transform.rotation = Quaternion.identity;
            }
            else
            {
                frogSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sign(horiz) * -180));

                // StartCoroutine(Move());
            }
            //This will allow for it to move on the vertical axis

        }

        else if (Mathf.Abs(horiz) > 0)
        {
            //This will allow for it to move on the horizontal axis
            frogSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sign(horiz) * -90));
            // StartCoroutine(Move());
        }

        /* 
         private IEnumerator Move(vector3 target)
         {
             jumpCoolDownActivated = true;
             var Start = Transform.position;
             var time = of;
             while (time < 1f)
             {
                 CryTransform.position = vector3Lerp(Start, target, time);
                 time = time + time.deltaTime / jumpCoolDown;
                 yield return null;
             }
             transfrom.position = target;
             jumpCoolDownActivated = false;
         }
         */
    }
}
