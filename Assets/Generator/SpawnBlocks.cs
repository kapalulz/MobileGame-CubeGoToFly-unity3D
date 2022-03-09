using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] public GameObject[] prefab;
    [SerializeField] private float range = 5;
    [SerializeField] public float respontTime = 2;
    [SerializeField] private float height = -1;

    private IEnumerator Start()
    {
        while (true)
        {
            var position = transform.position;

            Vector2 randomPos = new Vector2(position.x + Random.Range(-range, range), position.y + height);
            Vector2 noRandomPosMinus = new Vector2(position.x - 2.36f, position.y + height);
            Vector2 noRandomPosPlus = new Vector2(position.x + 2.36f, position.y + height);

            int randomNumber = Random.Range(0, 2);
            var cubes = prefab[Random.Range(0, prefab.Length)];

            if (cubes == prefab[0])
            {
                if (randomNumber == 1)
                    cubes.transform.position = noRandomPosMinus;
                else
                    cubes.transform.position = noRandomPosPlus;
            }
            else
                cubes.transform.position = randomPos;

            Instantiate(cubes);
            if (Timer.time < 1)
                yield return new WaitForSeconds(1);

            yield return new WaitForSeconds((1 / Timer.time) * 5 + 1);


        }
    }
}
