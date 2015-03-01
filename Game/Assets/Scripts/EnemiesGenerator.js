#pragma strict

// Variable to store the enemy prefab
public var enemy : GameObject;

// Variable to know how fast we should create new enemies
public var spawnTime : float = 3;
var x : float = 26.90f;

function Start() {  
    // Call the 'addEnemy' function every 'spawnTime' seconds
    InvokeRepeating("addEnemy", spawnTime, spawnTime);
}

// New function to spawn an enemy
function addEnemy() {  
    // Variables to store the X position of the spawn object
    // See image below
    //var x1 = transform.position.x - renderer.bounds.size.x/2;
    //var x2 = transform.position.x + renderer.bounds.size.x/2;
    //var x : float = 26.90f;
	incX();
    // Randomly pick a point within the spawn object
    
    var spawnPoint = new Vector3(x,-2.96f,0);
    // Create an enemy at the 'spawnPoint' position
    Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    //transform.RotateAround(transform.rotation, new Vector3(0, 270,0), 270);
}

function incX() {
	if (x==26.90) x = 26.90f;
	else x+=40.4f;
}