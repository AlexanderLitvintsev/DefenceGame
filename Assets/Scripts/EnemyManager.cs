using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


    public GameObject objectToSpawn;
    int flag = 0;

  
    void Start () {
        SpawnWaves();
    }
	
	
	void Update () {

        if (flag == 0)
        {
            SpawnWaves();
        }

    }

    private IEnumerator Delay()
    {

        yield return new WaitForSeconds(Random.Range(2,5));
        flag = 0;
    }

    void SpawnWaves()
    {
            Vector3 spawnPosition = new Vector3(10, Random.Range(-3, 2), 0);
            spawnPosition.z = -2.0f;

        GameObject objectInstance = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        //    objectInstance.GetComponent<Animation>().Play("zb_dead1");
    //    objectInstance.GetComponent<ubzb_mol_skinchanger>().change_skin(2);
      
            flag = 1;
            StartCoroutine(Delay());
                
    }

}
