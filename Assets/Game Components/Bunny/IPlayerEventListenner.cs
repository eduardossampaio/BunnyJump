using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerEventListenner
{
    public void OnPlayerDeath();

    public void OnPlayerCollectItem(Collectable collectable);
}