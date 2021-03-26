using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

        [SerializeField]
        float lifetime = 3;
        float timer = 0;

        void Update()
        {
                timer += Time.deltaTime;
                if (timer >= lifetime)
                        Destroy(gameObject);
        }
}
