using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke("Explode", fuse);
    }

    void Update() 
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
    // // Update is called once per frame
    // void Explode()
    // {
    //     Debug.Log('BOOM' + firePower);
    //     Instantiate(fire, transform.position, Quaternion.identity);
    //     Destroy(GameObject);
    // }

    public void Explode()
    {
        FindObjectOfType<MapDestroyer>().Explode(transform.position);
        Destroy(gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
