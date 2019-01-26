using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 EnemyPosition = this.transform.position;
        Vector3 position = DataManager.Instance.Player.transform.position;
        Vector2 CartesianPosition = Vector2.Lerp(new Vector2(EnemyPosition.x,EnemyPosition.z),new Vector2(position.x,position.z),Time.deltaTime);
        this.transform.position = new Vector3(CartesianPosition.x,EnemyPosition.y,CartesianPosition.y);
    }
}
