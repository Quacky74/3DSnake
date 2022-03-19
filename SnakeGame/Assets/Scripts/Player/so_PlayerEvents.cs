using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerEvents", menuName = "Scriptable/PlayerEvents")]
public class so_PlayerEvents : ScriptableObject
{
    public event Action<Collectable> OnHitCollectable;
    public event Action<List<Collectable>, bool> OnGameOver; 
    public event Action OnHitWall;

    public void HitCollectable(Collectable collectable)
    {
        OnHitCollectable?.Invoke(collectable);
    }

    public void GameOver(List<Collectable> collectables, bool IsTimeUp)
    {
        OnGameOver?.Invoke(collectables, IsTimeUp);
    }

    public void HitWall()
    {
        OnHitWall?.Invoke();
    }
}
