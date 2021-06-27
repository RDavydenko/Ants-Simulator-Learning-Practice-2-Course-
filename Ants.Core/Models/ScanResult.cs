namespace Ants.Core.Models
{
	public class ScanResult
	{
		public ScanResult(Point coords, Entity entity = null) 
		{
			Coords = coords;
			Entity = entity;
		}

		public Point Coords { get; set; }
		public Entity Entity { get; set; }

		public override string ToString()
		{
			return $"{Entity} {Coords}";
		}
	}
}
