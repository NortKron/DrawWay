using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform boy;
    public Transform chunkGroup;

    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();
    
    private int randomPrefabIndex = 0;
    private int currentPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnedChunks.Add(FirstChunk);
        currentPrefabIndex = 0;
    }

    private void Update()
    {
        if (boy.position.z > spawnedChunks[spawnedChunks.Count - 1].End.position.z - 3)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(GetRandomChunk());

        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.position;
        newChunk.transform.SetParent(chunkGroup);
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private Chunk GetRandomChunk()
    {
        randomPrefabIndex = Random.Range(0, ChunkPrefabs.Length);

        while(currentPrefabIndex == randomPrefabIndex)
        {
            randomPrefabIndex = Random.Range(0, ChunkPrefabs.Length);
            //Debug.Log("Rand cycle ");
        }
        
        currentPrefabIndex = randomPrefabIndex;
        return ChunkPrefabs[randomPrefabIndex];
    }
}
