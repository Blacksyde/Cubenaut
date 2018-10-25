using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {

	public int val;

	public static Resource getResource(Biome b){
        Resource res=new Resource();
		res.val=-1;

		//Average resource value is based on tier.
		// tier 0: 0-20, tier 1: 20-40, tier 2: 40-60, tier 3: 60-100
		if(b.name=="Ice"){
			res.val=Random.Range(0,20);
		}

		else if(b.name=="Desert"){
			res.val=Random.Range(0,20);
		}

		else if(b.name=="Gas"){
			res.val=Random.Range(0,20);
		}

		else if(b.name=="Ocean"){
			res.val=Random.Range(20,40);
		}

		else if(b.name=="Volcano"){
			res.val=Random.Range(20,40);
		}

		else if(b.name=="Forest"){
			res.val=Random.Range(40,60);
		}

		else if(b.name=="Gem"){
			res.val=Random.Range(40,60);
		}

		else if(b.name=="Inhabited"){
			res.val=Random.Range(60,100);
		}

		else if(b.name=="Star"){
			res.val=Random.Range(60,100);
		}

		return res;
    }
}
