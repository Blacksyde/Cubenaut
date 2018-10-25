using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rarity{

        // Use this for initialization

       Biome[,] biomeArray;

       public int rarity_val;

        public void Init () {
               //populating array of biomes to pull from
               biomeArray = new Biome[4,3];
               biomeArray[0, 0] = new Biome();
               biomeArray[0, 0].name="Ice";
               biomeArray[0, 0].Init();
               biomeArray[0, 1] = new Biome();
               biomeArray[0, 1].name="Desert";
               biomeArray[0, 1].Init();
               biomeArray[0, 2] = new Biome();
               biomeArray[0, 2].name="Gas";
               biomeArray[0, 2].Init();
               biomeArray[1, 0] = new Biome();
               biomeArray[1, 0].name="Ocean";
               biomeArray[1, 0].Init();
               biomeArray[1, 1] = new Biome();
               biomeArray[1, 1].name="Volcano";
               biomeArray[1, 1].Init();
               biomeArray[2, 0] = new Biome();
               biomeArray[2, 0].name="Forest";
               biomeArray[2, 0].Init();
               biomeArray[2, 1] = new Biome();
               biomeArray[2, 1].name="Gem";
               biomeArray[2, 1].Init();
               biomeArray[3, 0] = new Biome();
               biomeArray[3, 0].name="Inhabited";
               biomeArray[3, 0].Init();
               biomeArray[3, 1] = new Biome();
               biomeArray[3, 1].name="Star";
               biomeArray[3, 1].Init();
               /* biomeArray[0, 0]=ice;
               biomeArray[0, 1]=desert;
               biomeArray[0, 2]=gas;
               biomeArray[1, 0]=ocean;
               biomeArray[1, 1]=volcano;
               biomeArray[2, 0]=forest;
               biomeArray[2, 1]=gem;
               biomeArray[3, 0]=inhabited;
               biomeArray[3, 1]=star;*/

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

	   public Biome getBiome(){
               if(rarity_val==0){
                       int rand = Random.Range(1,3);
                       if(rand==1){
                               return biomeArray[0, 0];
                       }
                       else if(rand==2){
                               return biomeArray[0, 1];
                       }
                       else{
                               return biomeArray[0, 2];
                       }
               }
               else if(rarity_val==1){
                       int rand = Random.Range(1,2);
                       if(rand==1){
                               return biomeArray[1, 0];
                       }
                       else{
                               return biomeArray[1, 1];
                       }
               }
               else if(rarity_val==2){
                       int rand = Random.Range(1,2);
                       if(rand==1){
                               return biomeArray[2, 0];
                       }
                       else{
                               return biomeArray[2, 1];
                       }
               }
               else if(rarity_val==3){
                       int rand = Random.Range(1,2);
                       if(rand==1){
                               return biomeArray[3, 0];
                       }
                       else{
                               return biomeArray[3, 1];
                       }
               }
               else
                       return null;
       }
 }
