using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rarity : MonoBehaviour {

        // Use this for initialization

       Biome[][] biomeArray;

       int rarity_val;

        void Start () {
               //populating array of biomes to pull from
               Biome ice = new Biome();
               ice.name="Ice";
               Biome desert = new Biome();
               desert.name="Desert";
               Biome gas = new Biome();
               gas.name="Gas";
               Biome ocean = new Biome();
               ocean.name="Ocean";
               Biome volcano = new Biome();
               volcano.name="Volcano";
               Biome forest = new Biome();
               forest.name="Forest";
               Biome gem = new Biome();
               gem.name="Gem";
               Biome inhabited = new Biome();
               inhabited.name="Inhabited";
               Biome star = new Biome();
               star.name="Star";
               biomeArray[0][0]=ice;
               biomeArray[0][1]=desert;
               biomeArray[0][2]=gas;
               biomeArray[1][0]=ocean;
               biomeArray[1][1]=volcano;
               biomeArray[2][0]=forest;
               biomeArray[2][1]=gem;
               biomeArray[3][0]=inhabited;
               biomeArray[3][1]=star;

               //randomizing the rarity_val
               int rand = Random.Range(0,100);
               if(rand<=40)
                       rarity_val=0;
               else if(rand<=70)
                       rarity_val=1;
               else if(rand<=90)
                       rarity_val=2;
               else
                       rarity_val=3;
       }
 }
