using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public SpriteRenderer canon1, canon1sin, canon2, canon3, canon3sin;
    public SpriteRenderer crack1, crack2, crack3, mast, mastBroken, sail, sailBroken;

    List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    private void Start()
    {
        sprites.Add(canon1);
        sprites.Add(canon1sin);
        sprites.Add(canon2);
        //sprites.Add(canon2sin);
        sprites.Add(canon3);
        sprites.Add(canon3sin);
        sprites.Add(crack1);
        sprites.Add(crack2);
        sprites.Add(crack3);
        sprites.Add(mast);
        sprites.Add(mastBroken);
        sprites.Add(sail);
        sprites.Add(sailBroken);
    }


    public void RefreshStat(float integrity)
    {
        foreach (SpriteRenderer r in sprites)
            r.gameObject.SetActive(false);

        if (integrity >= 0.7f)
        {
            canon1.gameObject.SetActive(true);
            canon2.gameObject.SetActive(true);
            canon3.gameObject.SetActive(true);
            mast.gameObject.SetActive(true);
            sail.gameObject.SetActive(true);
        }
        else if (integrity >= 0.4f)
        {
            canon1.gameObject.SetActive(true);
            crack1.gameObject.SetActive(true);
            canon2.gameObject.SetActive(true);
            crack3.gameObject.SetActive(true);

            mast.gameObject.SetActive(true);
            sail.gameObject.SetActive(true);
        }
        else if (integrity >= 0.2f)
        {
            crack1.gameObject.SetActive(true);
            canon2.gameObject.SetActive(true);
            crack2.gameObject.SetActive(true);
            crack3.gameObject.SetActive(true);
            mast.gameObject.SetActive(true);
            sailBroken.gameObject.SetActive(true);

            if (Log.instance) Log.instance.ShowMessage("We need more wood t' keep this afloat");
        }
        else if (integrity >= 0)
        {
            crack1.gameObject.SetActive(true);
            canon2.gameObject.SetActive(true);
            crack2.gameObject.SetActive(true);
            crack3.gameObject.SetActive(true);
            mastBroken.gameObject.SetActive(true);

            if (Log.instance) Log.instance.ShowMessage("We sink!");
        }
    }
}
