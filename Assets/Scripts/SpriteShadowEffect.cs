using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadowEffect : MonoBehaviour
{
    

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.parent.position.x, 0.0225f, transform.parent.position.z);
    }
    public void EnlargeMethod()
    {
        var originalScale = transform.localScale;
        var targetScale = originalScale + new Vector3(.4f, .4f, .4f);
       

    }
   

    public IEnumerator LerpScale(float time)
    {
        var originalScale = transform.localScale;
        var targetScale = originalScale + new Vector3(.4f, .4f, .4f);
        var originalTime = time;

        while(time > 0.0f)
        {
            time -= Time.deltaTime;
        }
        yield return transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
        
    }
}
