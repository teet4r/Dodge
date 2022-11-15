using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReturnable
{
    IEnumerator Return();

    float returnTime { get; set; }
}
