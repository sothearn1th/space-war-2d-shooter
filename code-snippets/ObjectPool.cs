//...
/*OTHER IMPLEMENTED CODES*/


    /// <summary>
    /// Pre-instantiates a fixed number of enemies for each prefab type and stores them in pools.
    /// This avoids Instantiate() spikes during gameplay by reusing disabled objects.
    /// Helps performance
    /// </summary>
    private void InitializePools()
    {
        for (int typeIndex = 0; typeIndex < enemyPrefabs.Count; typeIndex++)
        {
            GameObject prefab = enemyPrefabs[typeIndex];
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < amountPerType; i++)
            {
                GameObject enemy = Instantiate(prefab);
                enemy.SetActive(false);
                pool.Add(enemy);
            }
            enemyPools[typeIndex] = pool;
        }
    }

    /// <summary>
    /// Returns an inactive enemy from the specified type's array.
    /// </summary>
    /// Required: typeIndex = the index of the gameobject in the array
    /// Returns: 
    public static GameObject GetEnemyFromPool(int typeIndex)
    {
        if (!enemyPools.ContainsKey(typeIndex))
        {
            Debug.LogWarning($"Enemy pool for index {typeIndex} not found.");
            return null;
        }

        foreach (GameObject enemy in enemyPools[typeIndex])
        {
            if (!enemy.activeInHierarchy)
                return enemy;
        }

        Debug.LogWarning($"No available enemies in pool for type {typeIndex}.");
        return null;
    }


/* OTHER IMPLEMENTED CODES*/
///...