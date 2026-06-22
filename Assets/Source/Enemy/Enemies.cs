using System.Collections.Generic;
using UnityEngine;

public static class Enemies
{
    public static EnemyController[] GetEnemyControllers()
    {
        List<EnemyController> res = new();

        EnemyController[] all = Object.FindObjectsByType<EnemyController>(
            FindObjectsSortMode.None
        );

        foreach (var controller in all)
        {
            res.Add(controller);
        }

        return res.ToArray();
    }
}