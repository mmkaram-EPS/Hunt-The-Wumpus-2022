using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Mobs{
    // Start is called before the first frame update
    //public Trivia tr;
    public GameObject holePB;
    public GameObject playerDied;
    public Player p;
    public TriviaManager t;
    public MobManager m;

    //public RoomGeneration rg
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D other){
        StartCoroutine(whenPlayerNew(p));
    }
    public override void animate(){
        //kinda useless unless we wanna like animate falling lmao
    }
    IEnumerator whenPlayerNew(Player p){
        yield return new WaitForSeconds (3);
        t.LoadTrivia(3, 2, m.MobInput, "hole");
        yield return false;
    }
    public override void whenPlayer(Player p){

    }

    public override int move()
    {
        return -1;
    }
}