
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyManager : MonoBehaviour
     {
          public  EnemyDataContainer data;
          public GameObject dropMoney;
          private float _dropRate = 0.1f;
          private float _dropChance;
          
          protected void DropMoneyOnDeath(float chance)
          {
               
               if (chance <= _dropRate)
               {
                    Instantiate(dropMoney,transform.position,Quaternion.Euler(-90,0,-90));
               }
               
          }
     }

