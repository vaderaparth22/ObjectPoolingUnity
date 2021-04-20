Object Pooling is very important and commonly used in bullet hell games when there are hundreds of bullets are fired.

In this game I used patterns like Object Pooling, Singleton design pattern, Top-Down Main Flow and Factory Pattern, Interface and Inheritance.

Its a simple game where there is a Turret and it fires 3 different kinds of bullets.

Turret.cs file is responsible to fire a bullet.

BulletFactory.cs is reponsible for creating a new bullet if the bullet is not already created.

IPoolable interface is for all the bullets that are to be Pooled and Depooled.

Polygon, Hexagone and Diamond are the bullet types and are accessible using an enum of BulletType.

BulletManager.cs asks for a new bullet from BulletFactory.cs. After returning the bullet, BulletManager sends the object to Turret.cs who is responsible for firing the bullet.

Bullet class is a parent class of Polygon, Hexagone and Diamond class.
