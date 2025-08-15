using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heugabel : Bullet
{
    protected override int CooldownTime()
    {
        return 1;
    }

    protected override bool IsPiercing()
    {
        return false;
    }
}
