using GameKit.Managers;
public class GameParameters : SharedManager<GameParameters>
{
   public const int gridSize = 1;
   public int GrassCount { get; set; }

   public void CollectGrass()
   {
      GrassCount++;
   }

   public void GrassOut()
   {
      GrassCount = 0;
   }

   public bool SpendGrass(int value)
   {
      if (GrassCount >= value)
      {
         GrassCount -= value;
         return true;
      }
      return false;
   }
}
