using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpellDark()
    {
        CommonArea.isSpellDark = true;
    }
    public void SpellPoison()
    {
        CommonArea.isSpellPoison = true;
    }
    public void SpellFire()
    {
        CommonArea.isSpellFire = true;
    }

    public void SpellLast()
    {
        CommonArea.isSpellLast = true;
    }
}
