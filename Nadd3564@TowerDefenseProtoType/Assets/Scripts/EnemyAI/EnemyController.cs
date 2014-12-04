using UnityEngine;
using System.Collections;

public class EnemyController : AdvancedFSM 
{
	public GameObject Bullet;
	private int health;
	private CharaStatus status;
	
	protected override void Initialize()
	{
		health = 100;
		
		elapsedTime = 0.0f;
		shootRate = 2.0f;

		status = GetComponent<CharaStatus> ();
		GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;

		if (!playerTransform)
			print("プレーヤーが存在しません。タグ 'Player'　を追加してください。");
		
		//turret = gameObject.transform.GetChild(0).transform;
		//bulletSpawnPoint = turret.GetChild(0).transform;
		
		InitFSM();
	}
	
	protected override void FSMUpdate()
	{
		elapsedTime += Time.deltaTime;
	}
	
	protected override void FSMFixedUpdate()
	{
		CurrentState.Reason(playerTransform, transform);
		CurrentState.Act(playerTransform, transform);
	}
	
	public void SetTransition(Transition t) 
	{ 
		PerformTransition(t); 
	}
	
	private void InitFSM()
	{
		//ポイントのリスト
		pointList = GameObject.FindGameObjectsWithTag("DefensePoint");
		
		Transform[] waypoints = new Transform[pointList.Length];
		int i = 0;
		foreach(GameObject obj in pointList)
		{
			waypoints[i] = obj.transform;
			i++;
		}
		
		SearchState search = new SearchState(waypoints);
		search.AddTransition(Transition.SawPlayer, FSMStateID.Approaching);
		search.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		search.AddTransition (Transition.ReachPlayer, FSMStateID.Attacking);
		
		ApproachState app = new ApproachState(waypoints);
		app.AddTransition(Transition.LostPlayer, FSMStateID.Searching);
		app.AddTransition(Transition.ReachPlayer, FSMStateID.Attacking);
		app.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		AttackState attack = new AttackState(waypoints);
		attack.AddTransition(Transition.LostPlayer, FSMStateID.Searching);
		attack.AddTransition(Transition.SawPlayer, FSMStateID.Approaching);
		attack.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		DeadState dead = new DeadState();
		dead.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		AddFSMState(search);
		AddFSMState(app);
		AddFSMState(attack);
		AddFSMState(dead);
	}


	public void Damage(float damage)
	{
		//ヒットエフェクト
		/*CreateHitEffect ();
		EffectPos ();
		Destroy (effect, 0.3f);*/
		
		//HPを減らす
		status.DamageHP(damage);

		if(status.getHP() <= 0.0f)
			Destroy(gameObject);
		//死体を攻撃できないようにし、体力0なので倒れる
		/*try{
			eController.Down();
		}catch (UnityException e){
			Debug.Log("SaveExceptionLog : " + e);
			TextReadWriteManager write = new TextReadWriteManager();
			write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
		}*/
	}
	
	void OnCollisionEnter(Collision collision)
	{
		//hpを減少させます
		if (collision.gameObject.tag == "Bullet")
		{
			health -= 50;
			
			if (health <= 0)
			{
				Debug.Log("Switch to Dead State");
				SetTransition(Transition.NoHealth);
				Explode();
			}
		}
	}
	
	protected void Explode()
	{
		float rndX = Random.Range(10.0f, 30.0f);
		float rndZ = Random.Range(10.0f, 30.0f);
		for (int i = 0; i < 3; i++)
		{
			rigidbody.AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
			rigidbody.velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
		}
		
		Destroy(gameObject, 1.5f);
	}
	
	public void ShootBullet()
	{
		if (elapsedTime >= shootRate)
		{
			Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			elapsedTime = 0.0f;
		}
	}
}