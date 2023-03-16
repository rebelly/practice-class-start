	using System; 
	class  point3d{
		public int x;
		public int y;
		public int z;
		public point3d(){
			x = 0;
			y= 0;
			z = 0;
			}
		public point3d(int x1, int y1, int z1){
			x = x1;
			y = y1;
			z = z1;
		}
		public void move(char axis, int dist){
			if (axis == 'x'){
				x += dist;
				}
			if (axis == 'y'){
				y += dist;
				}
			if (axis == 'z'){
				z += dist;
				}
			}
		public void showpos(){
			Console.WriteLine($"Вы находитесь на координатах: x: {x} y:{y} z:{z}");
			}
	}
	class Program
{

	
    public static void Main()
    {
		point3d pos = new point3d();
		point3d pos1 = new point3d(1,2,3);
		pos1.showpos();
		pos1.move('x', 14);
		pos1.showpos();
    }
}

